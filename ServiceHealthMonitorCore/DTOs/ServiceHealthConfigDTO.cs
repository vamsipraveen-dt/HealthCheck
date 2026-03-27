using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.DTOs
{
    public class members
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string ServiceDescription { get; set; }
    }

    public class Services
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
        public bool Clustered { get; set; }
        public string ServiceDescription { get; set; }
        public string Address { get; set; }
        public IList<members> members { get; set; }
    }

    public class Services_Status
    {
        public string Status { get; set; }
        public IList<members> Services { get; set; }
    }





    public class AppsettingsConfig
    {
        public string HealthcheckEnvironment { get; set; }
        public string Environment { get; set; }
        public string logoURL { get; set; }
        public MailConfig MailConfig { get; set; }
        public bool EncryptionEnabled { get; set; }
        public ServiceMonitorConfig ServiceMonitorConfig { get; set; }
        //public PKITimeStampService PKITimeStampService { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public HealthChecksUI HealthChecksUI { get; set; }
        public List<Services> Services { get; set; }
    }

    public class MailConfig
    {
        public string FromMailAddress { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Usessl { get; set; }
    }

    public class ServiceMonitorConfig
    {
        public bool Monitor { get; set; }
        public List<string> ReportRecieverMails { get; set; }
        public int MonitorForEveryInMinutes { get; set; }
        public int ServiceRetryFrequencyInSec { get; set; }
        public int MaxServiceRetry { get; set; }
        public int ServiceHistoryCount { get; set; }
        public string LogoUrl { get; set; }
    }

    public class PKITimeStampService
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string ServiceDescription { get; set; }
        public string data_hash { get; set; }
        public string algo { get; set; }
    }

    public class ConnectionStrings
    {
        public string RAConnString { get; set; }
        public string ServiceHealthConnString { get; set; }
    }

    public class HealthChecksUI
    {
        public List<HealthCheckEntry> HealthChecks { get; set; }
        public int EvaluationTimeInSeconds { get; set; }
    }

    public class HealthCheckEntry
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }


}
