using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using ServiceHealthMonitorCore.Domain.Repositories;

namespace ServiceHealthMonitorCore.Persistence.Repositories
{
    public class GenericUnitOfWork<TContext> : IGenericUnitOfWork
        where TContext : DbContext
    {
        protected readonly TContext Context;

        public GenericUnitOfWork(TContext context)
        {
            this.Context = context;
        }

        public void DisableDetectChanges()
        {
            Context.ChangeTracker.AutoDetectChangesEnabled = false;
            return;
        }

        public void EnableDetectChanges()
        {
            Context.ChangeTracker.AutoDetectChangesEnabled = true;
            return;
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
