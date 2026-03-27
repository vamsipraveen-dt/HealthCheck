using ServiceHealthMonitorCore.Domain.Services.Communication;
using ServiceHealthMonitorCore.Domain.Services.Communication.ServiceHistory;
using ServiceHealthMonitorCore.DTOs;

namespace ServiceHealthMonitorCore.Domain.Services
{
    public interface IServiceHistoryService
    {
        Task<ServiceResult> GetServiceHistoryAsync(string serviceName);
        Task<ServiceResult> CreateServiceHistoryAsync(CreateServiceHistoryDTO request);
        Task<ServiceResult> UpdateServiceHistoryAsync(UpdateServiceHistoryRequest request);
    }
}