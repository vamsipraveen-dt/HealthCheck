using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ServiceHealthMonitorCore.DTOs;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Utilities
{
    public interface IHealthCheck
    {
        public Task CheckServicesHealth();
        public Task<APIStatusResponse> GenerateTimeStampReq();
    }
}
