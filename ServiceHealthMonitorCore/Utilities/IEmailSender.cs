using ServiceHealthMonitorCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Utilities
{
    public interface IEmailSender
    {
        Task<int> SendEmail(Message message);
        public bool TestSmtpConnection(EmailConfiguration emailConfiguration);
    }
}
