using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServerHealthMonitor.Services;
using ServiceHealthMonitorCore.Domain.Models.ServiceHealth;
using ServiceHealthMonitorCore.Domain.Repositories;
using ServiceHealthMonitorCore.Domain.Services;
using ServiceHealthMonitorCore.Domain.Services.Communication.ServiceHistory;
using ServiceHealthMonitorCore.DTOs;
using System.Globalization;
using System.Net.Http.Json;

namespace ServiceHealthMonitorCore.Utilities
{
    public class HealthCheck : IHealthCheck
    {
        private readonly ILogger<HealthCheck> _logger;
        private readonly IConfiguration _configuration;
        private readonly HealthCheckService _healthCheckService;
        private readonly IEmailSender _emailSender;
        private readonly ISHUnitOfWork _shUnitOfWork;
        private readonly IServiceHistoryService _serviceHistoryService;
        private readonly SystemHealthService _systemHealthService;
        private readonly IWebHostEnvironment _env;

        public HealthCheck(IConfiguration configuration,
        ILogger<HealthCheck> logger,
        HealthCheckService healthCheckService,
        IEmailSender emailSender,
        ISHUnitOfWork sHUnitOfWork,
        IServiceHistoryService serviceHistoryService,
        IWebHostEnvironment env,
        SystemHealthService systemHealthService
        )
        {
            _logger = logger;
            _emailSender = emailSender;
            _configuration = configuration;
            _healthCheckService = healthCheckService;
            _shUnitOfWork = sHUnitOfWork;
            _serviceHistoryService = serviceHistoryService;
            _systemHealthService = systemHealthService;
            _env = env;
        }


        private string GetServiceDisplayAddress(HealthReportEntry entry)
        {
            var displayName = entry.Tags.ElementAtOrDefault(4);
            var type = entry.Tags.ElementAtOrDefault(2);
            var url = entry.Tags.ElementAtOrDefault(3);

            if (type == "SYSTEM_MONITOR")
            {
                return $"{displayName} (System)";
            }

            return $"{displayName}({Helper.GetAddressFromUrl(url, type)})";
        }

        public async Task<APIStatusResponse> GenerateTimeStampReq()
        {
            APIStatusResponse response = new APIStatusResponse();
            response.Description = String.Empty;
            response.Status = HealthStatus.Unhealthy.ToString();

            try
            {
                response.Name = _configuration.GetValue<string>("PKITimeStampService:Name");
                response.DisplayName = _configuration.GetValue<string>("PKITimeStampService:DisplayName");
                response.Type = _configuration.GetValue<string>("PKITimeStampService:Type");
                response.Url = _configuration.GetValue<string>("PKITimeStampService:Url");
                response.ServiceDescription = _configuration.GetValue<string>("PKITimeStampService:ServiceDescription");
                response.Status = "UnHealthy";
                Uri urlObj = new Uri(response.Url);
                response.Address = urlObj.Authority;

                var data = new Dictionary<string, string>
                {
                   { "data_hash", _configuration.GetValue<string>("PKITimeStampService:data_hash")},
                   { "algo",  _configuration.GetValue<string>("PKITimeStampService:algo")}
                };

                var content = new FormUrlEncodedContent(data);
                var httpClientHandler = new HttpClientHandler();

                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => { return true; };

                var client = new HttpClient(httpClientHandler);
                client.BaseAddress = new Uri(response.Url);

                var apiResponse = await client.PostAsync(response.Url, content);
                if (apiResponse == null)
                {
                    _logger.LogError("Invalid Response From TimeStamp Server");
                    response.Description = "Invalid Response from TimeStamp server";
                    return response;
                }
                if (apiResponse.IsSuccessStatusCode)
                {
                    var timestampResponse = await apiResponse.Content.ReadFromJsonAsync<TimestampResponse>();
                    var statusCode = timestampResponse.statusCode;
                    if ("901" == statusCode)
                    {
                        if (timestampResponse.message.Length < 256)
                        {
                            response.Description = "TimeStamp Server Response Message Length is not valid";
                            _logger.LogWarning("TimeStamp Server Response Message Length is not valid");
                        }
                        else
                        {
                            _logger.LogInformation("TimeStamp Server is up and running");
                            response.Status = "Healthy";
                        }
                    }
                    else
                    {
                        _logger.LogWarning("TimeStamp Server Returned Wrong Status Code:", timestampResponse.statusCode);
                        _logger.LogWarning("TimeStamp Server Issue:", timestampResponse.message);
                        response.Description = timestampResponse.message;
                    }
                    return response;
                }
                else
                {
                    _logger.LogError("Request Failed/Invalid Response from server");
                    response.Description = apiResponse.ReasonPhrase;
                    return response;
                }
            }
            catch (Exception error)
            {
                _logger.LogError("GenerateTimeStampReq Failed: " + error.Message);
                response.Description = error.Message;
                return response;
            }
        }

        public async Task<APIStatusResponse> GetRamMonitor()
        {
            APIStatusResponse response = new APIStatusResponse();
            response.Description = String.Empty;
            response.Status = HealthStatus.Unhealthy.ToString();

            try
            {
                response.Name = _configuration.GetValue<string>("SystemMonitor:RAM:Name");
                response.DisplayName = _configuration.GetValue<string>("SystemMonitor:RAM:DisplayName");
                response.Type = _configuration.GetValue<string>("SystemMonitor:RAM:Type");
                response.Url = _configuration.GetValue<string>("SystemMonitor:RAM:Url");
                response.ServiceDescription = _configuration.GetValue<string>("SystemMonitor:RAM:ServiceDescription");
                response.Status = "UnHealthy";

                var sysHealthResponse = await _systemHealthService.GetAll();
                if (sysHealthResponse == null)
                {
                    _logger.LogError("Failed to get System Health");
                    response.Description = "Failed to get System Health";
                    return response;
                }

                if (sysHealthResponse.Success == false)
                {
                    _logger.LogError("Failed to get System Health: " + sysHealthResponse.Message);
                    response.Description = "Failed to get System Health: " + sysHealthResponse.Message;
                    return response;
                }

                var systemHealthData = (SystemHealthDto)sysHealthResponse.Result;

                string ramLimitString = _configuration.GetValue<string>("SystemMonitor:RAM:LimitPercent");

                if (!int.TryParse(ramLimitString, out int ramLimitPercent) || ramLimitPercent <= 0)
                {
                    ramLimitPercent = 80;
                    _logger.LogWarning("SystemMonitor:RAM:LimitPercent not found or invalid. Defaulting limit to {DefaultLimit}%.", ramLimitPercent);
                }

                if (systemHealthData.Ram.UsagePercent < ramLimitPercent)
                {
                    _logger.LogInformation("System RAM Usage is Healthy (Current: {Usage}%, Limit: {Limit}%)", systemHealthData.Ram.UsagePercent, ramLimitPercent);
                    response.Status = "Healthy";
                    return response;
                }
                else
                {
                    _logger.LogWarning("System RAM Usage is High: " + systemHealthData.Ram.UsagePercent);
                    response.Description = "System RAM Usage is High: " + systemHealthData.Ram.UsagePercent + "% (Limit: " + ramLimitPercent + "%)";
                    return response;
                }
            }
            catch (Exception error)
            {
                _logger.LogError("GetRamMonitor Failed: " + error.Message);
                response.Description = error.Message;
                return response;
            }
        }

        public async Task<APIStatusResponse> GetDiskInfoMonitor()
        {
            APIStatusResponse response = new APIStatusResponse();
            response.Description = String.Empty;
            response.Status = HealthStatus.Unhealthy.ToString();

            try
            {
                response.Name = _configuration.GetValue<string>("SystemMonitor:Disk:Name");
                response.DisplayName = _configuration.GetValue<string>("SystemMonitor:Disk:DisplayName");
                response.Type = _configuration.GetValue<string>("SystemMonitor:Disk:Type");
                response.Url = _configuration.GetValue<string>("SystemMonitor:Disk:Url");
                response.ServiceDescription = _configuration.GetValue<string>("SystemMonitor:Disk:ServiceDescription");
                response.Status = "UnHealthy";

                var sysHealthResponse = await _systemHealthService.GetAll();
                if (sysHealthResponse == null)
                {
                    _logger.LogError("Failed to get System Health");
                    response.Description = "Failed to get System Health";
                    return response;
                }

                if (sysHealthResponse.Success == false)
                {
                    _logger.LogError("Failed to get System Health: " + sysHealthResponse.Message);
                    response.Description = "Failed to get System Health: " + sysHealthResponse.Message;
                    return response;
                }

                var systemHealthData = (SystemHealthDto)sysHealthResponse.Result;

                string diskLimitString = _configuration.GetValue<string>("SystemMonitor:Disk:LimitPercent");

                if (!int.TryParse(diskLimitString, out int diskLimitPercent) || diskLimitPercent <= 0)
                {
                    diskLimitPercent = 80;
                    _logger.LogWarning("SystemMonitor:Disk:LimitPercent not found or invalid. Defaulting limit to {DefaultLimit}%.", diskLimitPercent);
                }

                if (systemHealthData.Disk.UsagePercent < diskLimitPercent)
                {
                    _logger.LogInformation("System Disk Usage is Healthy (Current: {Usage}%, Limit: {Limit}%)", systemHealthData.Disk.UsagePercent, diskLimitPercent);
                    response.Status = "Healthy";
                    return response;
                }
                else
                {
                    _logger.LogWarning("System Disk Usage is High: " + systemHealthData.Disk.UsagePercent);
                    response.Description = "System Disk Usage is High: " + systemHealthData.Disk.UsagePercent + "% (Limit: " + diskLimitPercent + "%)";
                    return response;
                }
            }
            catch (Exception error)
            {
                _logger.LogError("Get System Disk Info Failed: " + error.Message);
                response.Description = error.Message;
                return response;
            }
        }

        public async Task<APIStatusResponse> GetCpuMonitor()
        {
            APIStatusResponse response = new APIStatusResponse();
            response.Description = String.Empty;
            response.Status = HealthStatus.Unhealthy.ToString();
            try
            {
                response.Name = _configuration.GetValue<string>("SystemMonitor:CPU:Name");
                response.DisplayName = _configuration.GetValue<string>("SystemMonitor:CPU:DisplayName");
                response.Type = _configuration.GetValue<string>("SystemMonitor:CPU:Type");
                response.Url = _configuration.GetValue<string>("SystemMonitor:CPU:Url");
                response.ServiceDescription = _configuration.GetValue<string>("SystemMonitor:CPU:ServiceDescription");
                response.Status = "UnHealthy";
                var sysHealthResponse = await _systemHealthService.GetAll();
                if (sysHealthResponse == null)
                {
                    _logger.LogError("Failed to get System Health");
                    response.Description = "Failed to get System Health";
                    return response;
                }
                if (sysHealthResponse.Success == false)
                {
                    _logger.LogError("Failed to get System Health: " + sysHealthResponse.Message);
                    response.Description = "Failed to get System Health: " + sysHealthResponse.Message;
                    return response;
                }
                var systemHealthData = (SystemHealthDto)sysHealthResponse.Result;

                string cpuLimitString = _configuration.GetValue<string>("SystemMonitor:CPU:LimitPercent");

                if (!int.TryParse(cpuLimitString, out int cpuLimitPercent) || cpuLimitPercent <= 0)
                {
                    cpuLimitPercent = 80;
                    _logger.LogWarning("SystemMonitor:CPU:LimitPercent not found or invalid. Defaulting limit to {DefaultLimit}%.", cpuLimitPercent);
                }

                if (systemHealthData.Cpu.UsagePercent < cpuLimitPercent)
                {
                    _logger.LogInformation("System CPU Usage is Healthy (Current: {Usage}%, Limit: {Limit}%)", systemHealthData.Cpu.UsagePercent, cpuLimitPercent);
                    response.Status = "Healthy";
                    return response;
                }
                else
                {
                    _logger.LogWarning("System CPU Usage is High: " + systemHealthData.Cpu.UsagePercent);
                    response.Description = "System CPU Usage is High: " + systemHealthData.Cpu.UsagePercent + "% (Limit: " + cpuLimitPercent + "%)";
                    return response;
                }
            }
            catch (Exception error)
            {
                _logger.LogError("Get System CPU Info Failed: " + error.Message);
                response.Description = error.Message;
                return response;
            }
        }

        public async Task SendEmailAndPushNotification(string services)
        {
            string env = _configuration["Environment"];
            string initialMessage = "The following Services are not accessible/responding:\n";
            string endMessage = "*Kindly check the above services.\nThanks.";
            string logoUrl = _configuration["ServiceMonitorConfig:LogoUrl"];
            var healthcheckEnvironmentName = _configuration["HealthcheckEnvironment"];

            DateTime utcNow = DateTime.UtcNow;
            DateTime istTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcNow, "Asia/Kolkata");
            DateTime ugandaTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcNow, "Africa/Kampala");
            DateTime uaeTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcNow, "Asia/Dubai");

            string checkedTimeMessage = "";
            if (env == "UAE")
            {
                checkedTimeMessage = $@"<p>Checked Time: {uaeTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)} UAE | {istTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)} IST</p>";
            }
            else
            {
                checkedTimeMessage = $@"<p>Checked Time: {ugandaTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)} EAT | {istTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)} IST</p>";
            }

            string servicesList = string.Join("", services.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(service => $"<li>{service}</li>"));
            string response = $@"<p>{healthcheckEnvironmentName} Services Monitor Report</p>
                            <p>{initialMessage.Replace("\n", "<br />")}</p>
                            <ul>{servicesList}</ul>
                            {checkedTimeMessage}
                            <p>{endMessage.Replace("\n", "<br />")}</p>
                            <img src='{logoUrl}' width='13%'>";

            _logger.LogWarning("{0}", response);

            var mailBody = string.Format("Hi {0},\n\n{1}", "Admin", response);
            var reportRecieverMailIds = _configuration.GetSection("ServiceMonitorConfig:ReportRecieverMails").Get<string[]>();
            if (0 == reportRecieverMailIds.Count())
            {
                _logger.LogError("No Report Reciever MailIds Found");
                return;
            }

            var message = new Message(reportRecieverMailIds, healthcheckEnvironmentName + " Services Monitor Report", mailBody);

            var sendEmailresult = await _emailSender.SendEmail(message);
            if (0 != sendEmailresult)
            {
                _logger.LogError("SendEmail Failed");
            }
        }

        public async Task<TestServiceResponse> TestServiceManually(string type, string url)
        {
            var testServiceResponse = new TestServiceResponse();
            testServiceResponse.success = true;
            testServiceResponse.Status = HealthStatus.Unhealthy.ToString();

            try
            {
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => { return true; };

                var client = new HttpClient(httpClientHandler);
                client.BaseAddress = new Uri(url);

                var apiResponse = await client.GetAsync(url);
                if (apiResponse == null)
                {
                    _logger.LogError("Invalid Response From Server");
                    return testServiceResponse;
                }
                if (apiResponse.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Service returned success status code");
                    testServiceResponse.Status = HealthStatus.Healthy.ToString();
                    return testServiceResponse;
                }
                else
                {
                    _logger.LogError("Service failed,returned status code : {0}", apiResponse.ReasonPhrase);
                    testServiceResponse.Description = apiResponse.ReasonPhrase;
                    return testServiceResponse;
                }
            }
            catch (Exception error)
            {
                _logger.LogError("Service Failed: " + error.Message);
                testServiceResponse.Description = error.Message;
                return testServiceResponse;
            }
        }

        public async Task CheckServicesHealth()
        {
            string services = String.Empty;
            string reportStatus = HealthStatus.Unhealthy.ToString();
            IEnumerable<KeyValuePair<string, HealthReportEntry>>? reportEntries = default;
            var max_service_retry = 0;
            var maxServiceRetryCount = _configuration.GetValue<int>("ServiceMonitorConfig:MaxServiceRetry");
            var serviceRetryFreqInSec = _configuration.GetValue<int>("ServiceMonitorConfig:ServiceRetryFrequencyInSec");

            try
            {
                _logger.LogDebug("Check Service Health");

                // Check all services status
                var report = await _healthCheckService.CheckHealthAsync();
                if (null == report)
                {
                    _logger.LogError("CheckHealthAsync Failed: ");
                    return;
                }

                // Initialize the Timer
                var timer = new PeriodicTimer(TimeSpan.FromSeconds(serviceRetryFreqInSec));
                APIStatusResponse response = null;

                // 1. PKI TimeStamp Service Check
                var isPKIAvailable = _configuration.GetValue<string>("PKITimeStampService:Name");
                if (isPKIAvailable != null)
                {
                    max_service_retry = 0;
                    do
                    {
                        _logger.LogWarning("Testing Service Url Manually:{0} and attemp No:{1}",
                            "Timestamp Service", max_service_retry + 1);

                        response = null;
                        response = await GenerateTimeStampReq();
                        max_service_retry++;

                        if (null != response && HealthStatus.Healthy.ToString() == response.Status)
                        {
                            _logger.LogWarning("{0} is running when checked manually at attempts {1}",
                                "Timestamp Service", max_service_retry);
                            break;
                        }

                        if (max_service_retry == maxServiceRetryCount)
                        {
                            _logger.LogWarning("{0} is not running when checked manually also for configured attempts",
                                "Timestamp Service");
                            break;
                        }
                    } while (await timer.WaitForNextTickAsync());

                    if (null != response)
                    {
                        var timeStampServiceStatus = HealthStatus.Unhealthy;
                        if (response.Status == HealthStatus.Healthy.ToString())
                            timeStampServiceStatus = HealthStatus.Healthy;

                        var tags = new[] {
                            _configuration.GetValue<string>("PKITimeStampService:Name"),
                            string.Empty,
                            _configuration.GetValue<string>("PKITimeStampService:Type"),
                            _configuration.GetValue<string>("PKITimeStampService:Url"),
                            _configuration.GetValue<string>("PKITimeStampService:DisplayName"),
                            _configuration.GetValue<string>("PKITimeStampService:ServiceDescription")
                        };

                        var timeStampServiceReport = new HealthReportEntry(
                            timeStampServiceStatus, response.Description,
                            TimeSpan.FromSeconds(0), null, null, tags);

                        reportEntries = report.Entries.Append(new KeyValuePair<string, HealthReportEntry>(
                             _configuration.GetValue<string>("PKITimeStampService:Name"), timeStampServiceReport));

                        if (report.Status == HealthStatus.Healthy && timeStampServiceStatus == HealthStatus.Healthy)
                            reportStatus = "Healthy";
                    }
                    else
                    {
                        _logger.LogError("GenerateTimeStampReq Failed");
                        return;
                    }
                }
                else
                {
                    reportEntries = report.Entries;
                }


                // 2. System Health Monitoring (RAM, CPU, Disk)
                bool checkSystemHealthConfig = _configuration.GetValue("SystemMonitor:Monitor", false);
                if (checkSystemHealthConfig)
                {
                    max_service_retry = 0;
                    do
                    {
                        _logger.LogWarning("Testing System Manually:{0} and attempt No:{1}",
                            "RAM Monitor", max_service_retry + 1);

                        response = null;
                        response = await GetRamMonitor();
                        max_service_retry++;

                        if (null != response && HealthStatus.Healthy.ToString() == response.Status)
                        {
                            _logger.LogWarning("{0} is running when checked manually at attempts {1}",
                                "RAM Monitor", max_service_retry);
                            break;
                        }

                        if (max_service_retry == maxServiceRetryCount)
                        {
                            _logger.LogWarning("{0} is not running when checked manually also for configured attempts",
                                "RAM Monitor");
                            break;
                        }
                    } while (await timer.WaitForNextTickAsync());

                    if (null != response)
                    {
                        var ramStatus = response.Status == HealthStatus.Healthy.ToString() ? HealthStatus.Healthy : HealthStatus.Unhealthy;

                        var tags = new[] {
                            _configuration.GetValue<string>("SystemMonitor:RAM:Name"),
                            string.Empty,
                            _configuration.GetValue<string>("SystemMonitor:RAM:Type"),
                            _configuration.GetValue<string>("SystemMonitor:RAM:Url"),
                            _configuration.GetValue<string>("SystemMonitor:RAM:DisplayName"),
                            _configuration.GetValue<string>("SystemMonitor:RAM:ServiceDescription")
                        };

                        var ramReport = new HealthReportEntry(ramStatus, response.Description, TimeSpan.FromSeconds(0), null, null, tags);
                        reportEntries = reportEntries.Append(new KeyValuePair<string, HealthReportEntry>(
                            _configuration.GetValue<string>("SystemMonitor:RAM:Name"), ramReport));

                        if (reportStatus == "Healthy" && ramStatus != HealthStatus.Healthy) reportStatus = "Unhealthy";
                    }
                    else
                    {
                        _logger.LogError("RAM Monitor Failed (No Response)");
                    }


                    max_service_retry = 0;
                    do
                    {
                        _logger.LogWarning("Testing System Manually:{0} and attempt No:{1}",
                            "CPU Monitor", max_service_retry + 1);

                        response = null;
                        response = await GetCpuMonitor();
                        max_service_retry++;

                        if (null != response && HealthStatus.Healthy.ToString() == response.Status)
                        {
                            _logger.LogWarning("{0} is running when checked manually at attempts {1}",
                                "CPU Monitor", max_service_retry);
                            break;
                        }

                        if (max_service_retry == maxServiceRetryCount)
                        {
                            _logger.LogWarning("{0} is not running when checked manually also for configured attempts",
                                "CPU Monitor");
                            break;
                        }
                    } while (await timer.WaitForNextTickAsync());

                    if (null != response)
                    {
                        var cpuStatus = response.Status == HealthStatus.Healthy.ToString() ? HealthStatus.Healthy : HealthStatus.Unhealthy;

                        var tags = new[] {
                            _configuration.GetValue<string>("SystemMonitor:CPU:Name"),
                            string.Empty,
                            _configuration.GetValue<string>("SystemMonitor:CPU:Type"),
                            _configuration.GetValue<string>("SystemMonitor:CPU:Url"),
                            _configuration.GetValue<string>("SystemMonitor:CPU:DisplayName"),
                            _configuration.GetValue<string>("SystemMonitor:CPU:ServiceDescription")
                        };

                        var cpuReport = new HealthReportEntry(cpuStatus, response.Description, TimeSpan.FromSeconds(0), null, null, tags);
                        reportEntries = reportEntries.Append(new KeyValuePair<string, HealthReportEntry>(
                            _configuration.GetValue<string>("SystemMonitor:CPU:Name"), cpuReport));

                        if (reportStatus == "Healthy" && cpuStatus != HealthStatus.Healthy) reportStatus = "Unhealthy";
                    }
                    else
                    {
                        _logger.LogError("CPU Monitor Failed (No Response)");
                    }


                    max_service_retry = 0;
                    do
                    {
                        _logger.LogWarning("Testing System Manually:{0} and attempt No:{1}",
                            "Disk Monitor", max_service_retry + 1);

                        response = null;
                        response = await GetDiskInfoMonitor();
                        max_service_retry++;

                        if (null != response && HealthStatus.Healthy.ToString() == response.Status)
                        {
                            _logger.LogWarning("{0} is running when checked manually at attempts {1}",
                                "Disk Monitor", max_service_retry);
                            break;
                        }

                        if (max_service_retry == maxServiceRetryCount)
                        {
                            _logger.LogWarning("{0} is not running when checked manually also for configured attempts",
                                "Disk Monitor");
                            break;
                        }
                    } while (await timer.WaitForNextTickAsync());

                    if (null != response)
                    {
                        var diskStatus = response.Status == HealthStatus.Healthy.ToString() ? HealthStatus.Healthy : HealthStatus.Unhealthy;

                        var tags = new[] {
                            _configuration.GetValue<string>("SystemMonitor:Disk:Name"),
                            string.Empty,
                            _configuration.GetValue<string>("SystemMonitor:Disk:Type"),
                            _configuration.GetValue<string>("SystemMonitor:Disk:Url"),
                            _configuration.GetValue<string>("SystemMonitor:Disk:DisplayName"),
                            _configuration.GetValue<string>("SystemMonitor:Disk:ServiceDescription")
                        };

                        var diskReport = new HealthReportEntry(diskStatus, response.Description, TimeSpan.FromSeconds(0), null, null, tags);
                        reportEntries = reportEntries.Append(new KeyValuePair<string, HealthReportEntry>(
                            _configuration.GetValue<string>("SystemMonitor:Disk:Name"), diskReport));

                        if (reportStatus == "Healthy" && diskStatus != HealthStatus.Healthy) reportStatus = "Unhealthy";
                    }
                    else
                    {
                        _logger.LogError("Disk Monitor Failed (No Response)");
                    }
                }

                var lastServiceReportConfig = await _shUnitOfWork.Configuration.GetConfigurationByName("SERVICE_DETAILS");
                if (null == lastServiceReportConfig)
                {
                    _logger.LogInformation("Last Services Status Report Not Available");
                    return;
                }

                var lastServiceReport = JsonConvert.DeserializeObject<Services_Status>(lastServiceReportConfig.Data);
                if (null == lastServiceReport)
                {
                    _logger.LogError("Failed to convert Service Status Report String to Object");
                    return;
                }

                if (lastServiceReport.Status == HealthStatus.Healthy.ToString())
                {
                    if (reportStatus == HealthStatus.Healthy.ToString())
                    {
                        _logger.LogInformation("Current Status Report, Last Status Report is Healthy");
                        return;
                    }
                }

                var UpdatedStatusReport = new Services_Status();
                UpdatedStatusReport.Services = new List<members>();

                foreach (var entry in reportEntries)
                {
                    string serviceStatus = HealthStatus.Unhealthy.ToString();
                    string description = String.Empty;
                    if (entry.Value.Status == HealthStatus.Healthy)
                        serviceStatus = HealthStatus.Healthy.ToString();

                    var serviceAddress = GetServiceDisplayAddress(entry.Value);


                    if (entry.Value.Status == HealthStatus.Unhealthy)
                    {
                        _logger.LogWarning("{0} is not running", serviceAddress);

                        if (null != entry.Value.Exception && null != entry.Value.Exception.Message)
                            _logger.LogWarning("Service Exception Message:{0}", entry.Value.Exception.Message);

                        var type = entry.Value.Tags.ElementAtOrDefault(2);
                        bool isSystemMonitor =
                             entry.Key == _configuration.GetValue<string>("PKITimeStampService:Name") ||
                             entry.Key == _configuration.GetValue<string>("SystemMonitor:RAM:Name") ||
                             entry.Key == _configuration.GetValue<string>("SystemMonitor:CPU:Name") ||
                             entry.Key == _configuration.GetValue<string>("SystemMonitor:Disk:Name");

                        if ((type == "LOAD_BALANCER" || type == "REST_SERVICE") && !isSystemMonitor)
                        {
                            max_service_retry = 0;
                            TestServiceResponse testServiceResponse = null;

                            do
                            {
                                _logger.LogWarning("Testing Service Url Manually:{0} and attemp No:{1}",
                                    entry.Value.Tags.ElementAtOrDefault(3),
                                    max_service_retry + 1);

                                testServiceResponse = null;
                                testServiceResponse = await TestServiceManually(type, entry.Value.Tags.ElementAtOrDefault(3));
                                max_service_retry++;

                                if (null != testServiceResponse && HealthStatus.Healthy.ToString() == testServiceResponse.Status)
                                {
                                    _logger.LogWarning("{0} is running when checked manually at attempts {1}",
                                        serviceAddress, max_service_retry);
                                    break;
                                }

                                if (max_service_retry == maxServiceRetryCount)
                                {
                                    _logger.LogWarning("{0} is not running when checked manually also for configured attempts",
                                        serviceAddress);
                                    break;
                                }
                            } while (await timer.WaitForNextTickAsync());

                            if (null != testServiceResponse && HealthStatus.Healthy.ToString() == testServiceResponse.Status)
                            {
                                serviceStatus = HealthStatus.Healthy.ToString();
                                _logger.LogWarning("{0} is running when checked manually", serviceAddress);
                            }
                            else
                            {
                                if (null != testServiceResponse && null != testServiceResponse.Description)
                                    description = testServiceResponse.Description;
                            }
                        }
                        else
                        {
                            if (null != entry.Value.Description)
                                description = entry.Value.Description;
                        }
                    }

                    var lastServiceStatus = lastServiceReport.Services.SingleOrDefault(m => m.Name == entry.Key);
                    if (lastServiceStatus != null)
                    {
                        if (serviceStatus != lastServiceStatus.Status)
                        {
                            var updateServiceHistoryReq = new UpdateServiceHistoryRequest
                            {
                                name = entry.Key,
                                serviceStatus = new ServiceHistoryDetails()
                                {
                                    datetime = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified),
                                    status = serviceStatus,
                                    description = description,
                                }
                            };
                            await _serviceHistoryService.UpdateServiceHistoryAsync(updateServiceHistoryReq);
                        }
                    }
                    else
                    {
                        var updateServiceHistoryReq = new UpdateServiceHistoryRequest
                        {
                            name = entry.Key,
                            serviceStatus = new ServiceHistoryDetails()
                            {
                                datetime = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified),
                                status = serviceStatus,
                                description = description,
                            }
                        };
                        await _serviceHistoryService.UpdateServiceHistoryAsync(updateServiceHistoryReq);
                    }

                    var UpdatedStatus = new members();
                    UpdatedStatus.Name = entry.Value.Tags.ElementAtOrDefault(0);
                    UpdatedStatus.DisplayName = entry.Value.Tags.ElementAtOrDefault(4);
                    UpdatedStatus.ServiceDescription = entry.Value.Tags.ElementAtOrDefault(5);
                    UpdatedStatus.Description = description;
                    UpdatedStatus.Status = serviceStatus;
                    UpdatedStatus.Duration = entry.Value.Duration.ToString();
                    UpdatedStatus.Url = entry.Value.Tags.ElementAtOrDefault(3);
                    UpdatedStatus.Type = entry.Value.Tags.ElementAtOrDefault(2);
                    UpdatedStatus.Address = Helper.GetAddressFromUrl(
                        entry.Value.Tags.ElementAtOrDefault(3),
                        entry.Value.Tags.ElementAtOrDefault(2));
                    UpdatedStatusReport.Services.Add(UpdatedStatus);

                    //if (serviceStatus == HealthStatus.Unhealthy.ToString())
                    //{
                    //    services = services + serviceAddress + "\n";
                    //}
                    if (serviceStatus == HealthStatus.Unhealthy.ToString())
                    {
                        var type = entry.Value.Tags.ElementAtOrDefault(2);

                        if (type == "SYSTEM_MONITOR")
                        {
                            services += $"{serviceAddress} → {description}\n";
                        }
                        else
                        {
                            services += serviceAddress + "\n";
                        }
                    }

                }

                if (services.Length > 0)
                {
                    await   SendEmailAndPushNotification(services);
                }
                else
                {
                    reportStatus = "Healthy";
                    _logger.LogWarning("All Services are running");
                }

                var UpdatedStatusReportConfig = new Configuration();
                UpdatedStatusReportConfig.Id = lastServiceReportConfig.Id;
                UpdatedStatusReportConfig.Name = lastServiceReportConfig.Name;
                UpdatedStatusReport.Status = reportStatus;
                UpdatedStatusReportConfig.Data = JsonConvert.SerializeObject(UpdatedStatusReport);
                UpdatedStatusReportConfig.CreatedDate = lastServiceReportConfig.CreatedDate;
                UpdatedStatusReportConfig.ModifiedDate =
    DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);



                _shUnitOfWork.Configuration.Update(UpdatedStatusReportConfig);
                await _shUnitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("CheckServicesHealth Failed: " + ex.Message);
            }

            return;
        }
    }
}