using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ServiceHealthMonitorCore.DTOs;
using ServiceHealthMonitorCore.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ServiceHealthMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIStatusController : ControllerBase
    {
        private readonly ILogger<APIStatusController> _logger;
        public IConfiguration configuration;
        private readonly IHealthCheck _healthCheck;

        public APIStatusController(ILogger<APIStatusController> logger,
            IConfiguration _configuration, IHealthCheck healthCheck)
        {
            _logger = logger;
            configuration = _configuration;
            _healthCheck = healthCheck;
        }

        [Route("PKITimeStamp")]
        [HttpGet]
        public async Task<IActionResult> PKITimeStamp()
        {
            var response = await _healthCheck.GenerateTimeStampReq();
            return Ok(response);
        }
    }
}