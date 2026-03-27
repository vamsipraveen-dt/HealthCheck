using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Domain.Services.Communication.ServiceHistory
{
    public class ServiceHistoryDetails
    {
        public string status { get; set; }
        public DateTime datetime { get; set; }
        public string description { get; set; }
    }
}
