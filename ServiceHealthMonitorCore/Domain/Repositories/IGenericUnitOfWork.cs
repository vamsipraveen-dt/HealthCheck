using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Domain.Repositories
{
    public interface IGenericUnitOfWork
    {
        void Save();
        Task SaveAsync();
        public void DisableDetectChanges();
        public void EnableDetectChanges();
    }
}
