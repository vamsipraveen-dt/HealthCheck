using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using ServiceHealthMonitorCore.Domain.Repositories;
using ServiceHealthMonitorCore.Domain.Models.RegistrationAuthority;
using ServiceHealthMonitorCore.Persistence.Repositories;

namespace ServiceHealthMonitorCore.Persistence.Repositories
{
    public class SubscriberRepository : GenericRepository<SubscriberView, ra_0_2Context>,
        ISubscriberRepository
    {
        private readonly ILogger _logger;
        public SubscriberRepository(ra_0_2Context context,
            ILogger logger) : base(context, logger)
        {
            _logger = logger;
        }

        public async Task<SubscriberView> GetSubscriberInfo(SubscriberView SubInfo)
        {
            try
            {
                return await Context.SubscriberViews.AsNoTracking().SingleOrDefaultAsync(ss => ss.SubscriberUid == SubInfo.SubscriberUid);
            }
            catch(Exception error)
            {
                _logger.LogError("GetSubscriberInfo::Database exception {0}", error);
                return null;
            }
        }

        public async Task<SubscriberView> GetSubscriberInfoByEmail(string emailId)
        {
            try
            {
                return await Context.SubscriberViews.AsNoTracking().SingleOrDefaultAsync(ss => ss.Email == emailId);
            }
            catch (Exception error)
            {
                _logger.LogError("GetSubscriberInfoByEmail::Database exception {0}", error);
                return null;
            }
        }

        public async Task<SubscriberView> GetSubscriberInfoByPhone(string phoneNo)
        {
            try
            {
                return await Context.SubscriberViews.AsNoTracking().SingleOrDefaultAsync(ss => ss.MobileNumber == phoneNo);
            }
            catch (Exception error)
            {
                _logger.LogError("GetSubscriberInfoByPhone::Database exception {0}", error);
                return null;
            }
        }

        public async Task<SubscriberView> GetSubscriberInfoBySUID(string Suid)
        {
            try
            {
                return await Context.SubscriberViews.AsNoTracking().SingleOrDefaultAsync(ss => ss.SubscriberUid == Suid);
            }
            catch (Exception error)
            {
                _logger.LogError("GetSubscriberInfoBySUID::Database exception {0}", error);
                return null;
            }
        }

        public async Task<SubscriberView> GetSubscriberInfobyDocType(string docType, string docNumber)
        {
            try
            {
                return await Context.SubscriberViews.AsNoTracking().SingleOrDefaultAsync(ss => ss.IdDocType == docType && ss.IdDocNumber == docNumber);
            }
            catch (Exception error)
            {
                _logger.LogError("GetSubscriberInfobyDocType::Database exception {0}", error);
                return null;
            }
        }
    }
}
