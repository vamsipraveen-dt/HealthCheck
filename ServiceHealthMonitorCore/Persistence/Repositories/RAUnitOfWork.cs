using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using ServiceHealthMonitorCore.Domain.Models;
using ServiceHealthMonitorCore.Domain.Repositories;
using ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;
using ServiceHealthMonitorCore.Persistence.Repositories;

namespace ServiceHealthMonitorCore.Persistence.Repositories
{
    public class RAUnitOfWork : GenericUnitOfWork<ra_0_2Context>, IRAUnitOfWork
    {
        private ILogger _logger;
        private ISubscriberRepository _subscriber;

        public RAUnitOfWork(ra_0_2Context raContext,
            ILogger logger) : base(raContext)
        {
            _logger = logger;
        }

        public ISubscriberRepository Subscriber
        {
            get { return _subscriber = _subscriber ?? new SubscriberRepository(Context, _logger); }
        }
    }
}
