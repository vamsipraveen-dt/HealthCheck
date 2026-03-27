using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Utilities
{
    public class PushNotificationClient: IPushNotificationClient
    {
        // Initialize logger.
        private readonly ILogger<PushNotificationClient> _logger;
        private static FirebaseMessaging firebaseMessaging;
        private readonly IConfiguration configuration;
        public static bool initLibrary = false;

        public PushNotificationClient(ILogger<PushNotificationClient> logger,
            IConfiguration Configuration)
        {
            _logger = logger;
            configuration = Configuration;
            _logger.LogDebug("-->PushNotificationClient");

            if (false == initLibrary)
            {
                _logger.LogInformation("Library not Initialized");
                try
                {
                    var defaultApp = FirebaseApp.Create(new AppOptions()
                    {
                        Credential = GoogleCredential.FromFile("firebase-adminsdk.json"),
                    });
                }
                catch(Exception ex)
                {
                    _logger.LogError("Failed to initialize PushNotification"+
                        " Library: {0}",
                        ex.Message);
                    throw;
                }

                firebaseMessaging = FirebaseMessaging.DefaultInstance;
                initLibrary = true;
                _logger.LogInformation("PushNotification Library Initialized");
            }

            _logger.LogDebug("<--PushNotificationClient");
        }

        public async Task<string> SendServiceMonitorReport(
            string token, string report)
        {
            _logger.LogDebug("-->SendServiceMonitorReport");

            string result = null;

            // Validate input parameters
            if (null == token || null == report)
            {
                _logger.LogError("Invalid Input Parameter");
                return result;
            }

            var message = new Message()
            {
                Token = token,
                Data = new Dictionary<string, string>()
                {
                    ["ServiceMonitorReport"] = report,
                    ["Title"] = "Services Monitor Report",
                    ["Body"] = "Click on notification to see report",
                    ["urlImage"] = configuration.GetValue<string>(
                        "ServiceMonitorConfig:LogoUrl")
                },

                Android = new AndroidConfig()
                {
                    Priority = Priority.High,
                },

                Apns = new ApnsConfig()
                {
                    Aps = new Aps()
                    {
                        Sound = "default",

                        Alert = new ApsAlert()
                        {
                            Title = "Authentication Request",
                            Body = "Please approve or deny",
                        },
                        
                        MutableContent = true,
                        
                    },
                },
            };

            try
            {
                _logger.LogDebug("Sending Push Notification");
                result = await firebaseMessaging.SendAsync(message);
                if (null == result)
                {
                    _logger.LogError("Send Notification Failed");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("SendServiceMonitorReport Failed: {0}",
                    ex.Message);
                return result;
            }

            _logger.LogInformation("Send Notification Response:{0}",result);
            _logger.LogDebug("<--SendServiceMonitorReport");
            return result;
        }

        public async Task<BatchResponse> SendMulticastServiceMonitorReport(
        List<string> tokens, string report)
        {
            _logger.LogDebug("-->SendServiceMonitorReport");

            BatchResponse result = null;

            // Validate input parameters
            if (null == tokens || null == report)
            {
                _logger.LogError("Invalid Input Parameter");
                return result;
            }

            var message = new MulticastMessage()
            {
                Tokens = tokens,
                Data = new Dictionary<string, string>()
                {
                    ["ServiceMonitorReport"] = report,
                    ["Title"] = "Services Monitor Report",
                    ["Body"] = "Click on notification to see report",
                    ["urlImage"] = configuration.GetValue<string>(
                        "ServiceMonitorConfig:LogoUrl")
                },

                Android = new AndroidConfig()
                {
                    Priority = Priority.High,
                },

                Apns = new ApnsConfig()
                {
                    Aps = new Aps()
                    {
                        Sound = "default",

                        Alert = new ApsAlert()
                        {
                            Title = "Services Monitor Report",
                            Body = "Click on notification to see report",
                        },

                        MutableContent = true,

                    },
                },
            };

            try
            {
                _logger.LogDebug("Sending Push Notification");
                result = await firebaseMessaging.SendMulticastAsync(message);
                if (null == result)
                {
                    _logger.LogError("Send Notification Failed");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("SendServiceMonitorReport Failed: {0}",
                    ex.Message);
                return result;
            }

            _logger.LogInformation("Send Notification Response:{0}", result);
            _logger.LogDebug("<--SendServiceMonitorReport");
            return result;
        }
    }
}
