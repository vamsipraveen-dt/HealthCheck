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
    public class ServiceHistoryRepository : GenericRepository<ServiceHistory,
        service_healthContext>, IServiceHistoryRepository
    {
        private readonly ILogger _logger;
        public ServiceHistoryRepository(service_healthContext context,
            ILogger logger) : base(context, logger)
        {
            _logger = logger;
        }

        public async Task<ServiceHistory> GetServiceHistoryByName(string name)
        {
            try
            {
                return await Context.ServiceHistories.AsNoTracking().
                    SingleOrDefaultAsync(u => u.Name == name);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServiceHistoryByName::Database exception: {0}",
                    ex.Message);
                return null;
            }
        }

        public async Task<bool> IsServiceHistoryExistsByNameAsync(string name)
        {
            try
            {
                return await Context.ServiceHistories.AsNoTracking().AnyAsync(
                    u => u.Name == name);
            }
            catch (Exception ex)
            {
                _logger.LogError("IsServiceHistoryExistsByNameAsync::Database exception: {0}",
                    ex.Message);
                throw;
            }
        }

    }
}
