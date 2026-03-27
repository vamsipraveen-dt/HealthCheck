using ServiceHealthMonitorCore.Domain.Models.ServiceHealth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Domain.Repositories
{
    public interface IServiceHistoryRepository: IGenericRepository<ServiceHistory>
    {
        Task<ServiceHistory> GetServiceHistoryByName(string name);
        Task<bool> IsServiceHistoryExistsByNameAsync(string name);
    }
}
