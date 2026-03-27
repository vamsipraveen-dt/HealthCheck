using System.Threading.Tasks;

using ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;
using ServiceHealthMonitorCore.Domain.Repositories;

namespace ServiceHealthMonitorCore.Domain.Repositories
{
    public interface ISubscriberRepository : IGenericRepository<SubscriberView>
    {
        Task<SubscriberView> GetSubscriberInfo(SubscriberView SubInfo);
        Task<SubscriberView> GetSubscriberInfoByEmail(string emailId);
        Task<SubscriberView> GetSubscriberInfoByPhone(string phoneNo);
        Task<SubscriberView> GetSubscriberInfoBySUID(string Suid);
        Task<SubscriberView> GetSubscriberInfobyDocType(string docType, string docNumber);
    }
}
