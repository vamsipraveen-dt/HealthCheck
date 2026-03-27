using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ServiceHealthMonitorCore.Domain.Models.ServiceHealth;
using ServiceHealthMonitorCore.Domain.Repositories;

namespace ServiceHealthMonitorCore.Persistence.Repositories
{
    public class SHUnitOfWork : GenericUnitOfWork<service_healthContext>, ISHUnitOfWork
    {
        private ILogger<SHUnitOfWork> _logger;
        private IServiceHistoryRepository _serviceHistory;
        private IConfigurationRepository _configuration;

        public SHUnitOfWork(service_healthContext context,
            ILogger<SHUnitOfWork> logger) : base(context)
        {
            _logger = logger;
        }

        public IServiceHistoryRepository ServiceHistory
        {
            get { return _serviceHistory ??= new ServiceHistoryRepository(
                Context, _logger); }
        }

        public IConfigurationRepository Configuration
        {
            get
            {
                return _configuration ??= new ConfigurationRepository(
              Context, _logger);
            }
        }
    }
}
