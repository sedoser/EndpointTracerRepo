using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EndpointTracerWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EndpointTracerWebApp.Controllers
{
    [Route("[controller]")]
    public class ExternalDpController : Controller
    {
        private readonly ILogger<ExternalDpController> _logger;
        private readonly IExternalDpApiService _externalDpService;


        public ExternalDpController(ILogger<ExternalDpController> logger, IExternalDpApiService externalDpService)
        {
            _logger = logger;
            _externalDpService = externalDpService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var externalDps = await _externalDpService.GetExternalDpsAsync();
            return View(externalDps);
        }
        
        [HttpGet("Error")]
        public IActionResult Error()
        {
            return View();
        }

        [HttpDelete("{externalDpId}")]
        public async Task<IActionResult> RemoveAsync(int externalDpId)
        {
            await _externalDpService.RemoveAsync(externalDpId);
            return NoContent();
        }
    }
}