using Microsoft.AspNetCore.Mvc;
using ServiceHealthMonitorCore.Domain.Services;
using ServiceHealthMonitorCore;
using ServiceHealthMonitorCore.DTOs;

namespace ServiceHealthMonitor.Controllers
{
    [Route("api")]
    [ApiController]
    [AllowAnonymous]
    public class ServiceHistoryController : Controller
    {
        private readonly ILogger<ServiceHistoryController> _logger;
        private readonly IServiceHistoryService _serviceHistoryService;

        public ServiceHistoryController(ILogger<ServiceHistoryController> logger,
            IServiceHistoryService serviceHistoryService)
        {
            _logger = logger;
            _serviceHistoryService = serviceHistoryService;
        }

        [HttpGet]
        [Route("servicehistory/{name}")]
        public async Task<IActionResult> GetServiceHistory(string name)
        {
            APIResponse response = null;

            var result = await _serviceHistoryService.GetServiceHistoryAsync(name);
            if (!result.Success)
            {
                response = new APIResponse
                {
                    Success = result.Success,
                    Message = result.Message,
                    Result = result.Result
                };
            }
            else
            {
                response = new APIResponse
                {
                    Success = result.Success,
                    Message = result.Message,
                    Result = result.Result
                };
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("servicehistory")]
        public async Task<IActionResult> CreateServiceHistory(
            CreateServiceHistoryDTO request)
        {
            APIResponse response = null;

            var result = await _serviceHistoryService.CreateServiceHistoryAsync(request);
            if (!result.Success)
            {
                response = new APIResponse
                {
                    Success = result.Success,
                    Message = result.Message,
                    Result = result.Result
                };
            }
            else
            {
                response = new APIResponse
                {
                    Success = result.Success,
                    Message = result.Message,
                    Result = result.Result
                };
            }

            return Ok(response);
        }

    }
}
