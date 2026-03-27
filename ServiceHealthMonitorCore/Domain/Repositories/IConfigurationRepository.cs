using ServiceHealthMonitorCore.Domain.Models.ServiceHealth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Domain.Repositories
{
    public interface IConfigurationRepository:IGenericRepository<Configuration>
    {
        Task<Configuration> GetConfigurationByName(string name);
    }
}
