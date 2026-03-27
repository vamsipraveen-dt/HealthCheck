using ServiceHealthMonitorCore.Domain.Services.Communication.ServiceHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.DTOs
{
    public class CreateServiceHistoryDTO
    {
        public string name { get; set; }
        public IList<ServiceHistoryDetails> serviceHistory { get; set; }
    }
}
