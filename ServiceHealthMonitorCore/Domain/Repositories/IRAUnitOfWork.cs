using ServiceHealthMonitorCore.Domain.Repositories;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Domain.Repositories
{
    public interface IRAUnitOfWork : IGenericUnitOfWork
    {
        ISubscriberRepository Subscriber { get; }
    }
}
