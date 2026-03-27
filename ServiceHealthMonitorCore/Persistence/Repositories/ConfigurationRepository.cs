using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServiceHealthMonitorCore.Domain.Models.ServiceHealth;
using ServiceHealthMonitorCore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Persistence.Repositories
{
    public class ConfigurationRepository : GenericRepository<Configuration,
        service_healthContext>, IConfigurationRepository
    {
        private readonly ILogger _logger;
        public ConfigurationRepository(service_healthContext context,
            ILogger logger) : base(context, logger)
        {
            _logger = logger;
        }

        public async Task<Configuration> GetConfigurationByName(string name)
        {
            try
            {
                return await Context.Configurations.AsNoTracking().
                    SingleOrDefaultAsync(u => u.Name == name);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetConfigurationByName::Database exception: {0}",
                    ex.Message);
                return null;
            }
        }
    }
}
