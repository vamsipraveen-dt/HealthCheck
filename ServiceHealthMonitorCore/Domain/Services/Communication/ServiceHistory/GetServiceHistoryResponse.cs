using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Domain.Services.Communication.ServiceHistory
{
    public class GetServiceHistoryResponse
    {
        public GetServiceHistoryResponse(IList<ServiceHistoryDetails> _serviceHistory)
        {
            serviceHistory = _serviceHistory;
        }
        public IList<ServiceHistoryDetails> serviceHistory { get; set; }
    }
}
