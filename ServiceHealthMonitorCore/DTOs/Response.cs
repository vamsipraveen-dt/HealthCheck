using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.DTOs
{
    public class APIStatusResponse
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string ServiceDescription { get; set; }
        public string Address { get; set; }
    }

    public class Response
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string result { get; set; }
    }

    public class TimestampResponse
    {
        public string message { get; set; }
        public string statusCode { get; set; }
    }

    public class TestServiceResponse
    {
        public bool success { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
