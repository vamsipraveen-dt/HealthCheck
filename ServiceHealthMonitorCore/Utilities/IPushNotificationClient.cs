using FirebaseAdmin.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Utilities
{
    public interface IPushNotificationClient
    {
        public Task<string> SendServiceMonitorReport(
            string token, string report);

        public Task<BatchResponse> SendMulticastServiceMonitorReport(
                List<string> tokens, string report);
    }
}