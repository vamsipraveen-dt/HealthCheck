using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceHealthMonitorCore.Domain.Models.ServiceHealth;
using ServiceHealthMonitorCore.Domain.Repositories;
using ServiceHealthMonitorCore.Domain.Services;
using ServiceHealthMonitorCore.Domain.Services.Communication;
using ServiceHealthMonitorCore.Domain.Services.Communication.ServiceHistory;
using ServiceHealthMonitorCore.DTOs;

namespace ServiceHealthMonitorCore.Services
{
    public class ServiceHistoryService: IServiceHistoryService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ServiceHistoryService> _logger;
        private readonly ISHUnitOfWork _shUnitOfWork;

        public ServiceHistoryService(ILogger<ServiceHistoryService> logger,
            IConfiguration configuration,
            ISHUnitOfWork shUnitOfWork)
        {
            _configuration = configuration;
            _logger = logger;
            _shUnitOfWork = shUnitOfWork;
        }

        public async Task<ServiceResult> GetServiceHistoryAsync(string serviceName)
        {
            try
            {
                _logger.LogDebug("--> GetServiceHistoryAsync");

                // Validate Input Parameters
                if (string.IsNullOrEmpty(serviceName))
                    return new ServiceResult("Service Name is not valid string");

                // Get Service History
                var serviceHistory = await _shUnitOfWork.ServiceHistory.
                    GetServiceHistoryByName(serviceName);
                if(null == serviceHistory)
                    return new ServiceResult("Service Not Found");

                // Convert Plain data string to object
                var serviceHistoryObj = JsonConvert.DeserializeObject<IList<
                    ServiceHistoryDetails>>(serviceHistory.History);
                if (null == serviceHistoryObj)
                {
                    _logger.LogError("Convert Plain data string to object Failed");
                    return new ServiceResult("Internal Error Occured"); ;
                }

                return new ServiceResult(new GetServiceHistoryResponse(
                    serviceHistoryObj));
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServiceHistoryAsync  Exception :  {0}", ex.Message);
                return new ServiceResult("An error occurred while getting service history");
            }
        }

        public async Task<ServiceResult> CreateServiceHistoryAsync(
            CreateServiceHistoryDTO request)
        {
            try
            {
                _logger.LogDebug("--> CreateServiceHistoryAsync");

                // Validate Input Parameters
                if (null == request)
                    return new ServiceResult("Invalid Input Parameters");

                if (string.IsNullOrEmpty(request.name))
                    return new ServiceResult("Service Name is not valid");

                if (null == request.serviceHistory)
                    return new ServiceResult("Service History is not valid");

                // Get Service History
                var isExists = await _shUnitOfWork.ServiceHistory.
                    IsServiceHistoryExistsByNameAsync(request.name);
                if (isExists)
                    return new ServiceResult("Service Name already Exists");

                // Convert Object to String
                var history = JsonConvert.SerializeObject(request.serviceHistory);

                var serviceHistory = new ServiceHistory();
                serviceHistory.Name = request.name;
                serviceHistory.History = history;
                serviceHistory.CreatedDate= DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
                serviceHistory.ModifiedDate= DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);

                // Create Record in Database
                await _shUnitOfWork.ServiceHistory.AddAsync(serviceHistory);
                await _shUnitOfWork.SaveAsync();

                return new ServiceResult(null, "Service History Created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServiceHistoryAsync  Exception :  {0}", ex.Message);
                return new ServiceResult("An error occurred while getting service history");
            }
        }

        public async Task<ServiceResult> UpdateServiceHistoryAsync(
            UpdateServiceHistoryRequest request)
        {
            try
            {
                _logger.LogDebug("--> UpdateServiceHistoryAsync");

                // Validate Input Parameters
                if (null == request)
                    return new ServiceResult("Invalid Input Parameters");

                if (string.IsNullOrEmpty(request.name))
                    return new ServiceResult("Service Name is not valid");

                if (null == request.serviceStatus|| null == request.serviceStatus.status)
                    return new ServiceResult("Service Status is not valid");

                // Get Service History
                var serviceHistoryInDb = await _shUnitOfWork.ServiceHistory
                    .GetServiceHistoryByName(request.name);
                if (null == serviceHistoryInDb)
                {
                    var history = new List<ServiceHistoryDetails>();
                    history.Add(request.serviceStatus);
                    _logger.LogInformation("Service History not found");
                    var serviceHistory = new ServiceHistory
                    {
                        Name = request.name,
                        History = JsonConvert.SerializeObject(history),
                        CreatedDate = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified),
                        ModifiedDate = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified)
                    };

                    // Create New Service History
                    await _shUnitOfWork.ServiceHistory.AddAsync(serviceHistory);
                    await _shUnitOfWork.SaveAsync();
                    return new ServiceResult(null);
                }

                // Convert String to Object
                var historyInDb = JsonConvert.DeserializeObject<IList<
                    ServiceHistoryDetails>>(serviceHistoryInDb.History);

                // Get Service History Count From Configuration
                var ServiceHistoryCount = _configuration.GetValue<int>(
                    "ServiceMonitorConfig:ServiceHistoryCount");

                // Remove First Element if History Count is reached
                if (historyInDb.Count == ServiceHistoryCount)
                    historyInDb.RemoveAt(0);

                // Add Current Status in History
                historyInDb.Add(request.serviceStatus);

                var UpdatedserviceHistory = new ServiceHistory
                {
                    Id = serviceHistoryInDb.Id,
                    Name = request.name,
                    History = JsonConvert.SerializeObject(historyInDb),
                    CreatedDate = serviceHistoryInDb.CreatedDate,
                    ModifiedDate = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified)
                };

                // Update Record in Database
                _shUnitOfWork.ServiceHistory.Update(UpdatedserviceHistory);
                await _shUnitOfWork.SaveAsync();
                return new ServiceResult(null);
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateServiceHistoryAsync  Exception :  {0}",
                    ex.Message);
                return new ServiceResult("An error occurred while "+
                    "Updating service history");
            }
        }
    }
}