using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Domain.Repositories
{
    public interface ISHUnitOfWork: IGenericUnitOfWork
    {
        IServiceHistoryRepository ServiceHistory { get; }

        IConfigurationRepository Configuration { get; }
    }
}
