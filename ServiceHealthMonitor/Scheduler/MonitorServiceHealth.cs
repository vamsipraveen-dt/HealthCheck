using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Quartz;
using ServiceHealthMonitorCore.Utilities;

namespace ServiceHealthMonitor.Scheduler
{
    public class MonitorServiceHealth : IJob
    {
        private readonly ILogger<MonitorServiceHealth> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHealthCheck _healthCheck;
        public MonitorServiceHealth(IConfiguration configuration,
        ILogger<MonitorServiceHealth> logger,
        IHealthCheck healthCheck)
        {
            _logger = logger;
            _configuration = configuration;
            _healthCheck = healthCheck;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogWarning("MonitorServices Cron Started");
            await MonitorServices();
            _logger.LogWarning("MonitorServices Cron Ended");
        }

        private async Task MonitorServices()
        {
            try
            {
                await _healthCheck.CheckServicesHealth();
            }
            catch (Exception e)
            {
                _logger.LogError("MonitorServices Failed: " + e.Message);
            }
        }
    }
}
