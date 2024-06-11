using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EndpointTracerWebApp.Dtos;
using EndpointTracerWebApp.Models;
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

            var externalDpViewModel = new ExternalDpViewModel
            {
                ExternalDps = externalDps,
            };

            return View(externalDpViewModel);
        }

        [HttpGet("{externalDpId}")]
        public async Task<IActionResult> GetByIdAsync(int externalDpId)
        {
            var externalDp = await _externalDpService.GetbyIdAsync(externalDpId);
            return PartialView("_ExternalDpPartialView", externalDp);
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
        [HttpPut("Update")]
        public async Task<ActionResult<ExternalDpUpdateDto>> UpdateAsync([FromForm] ExternalDpUpdateDto externalDp)
        {
            var updatedExternalDp = await _externalDpService.UpdateAsync(externalDp);
            return Ok(updatedExternalDp);
        }
        [HttpPost("Add")]
        public async Task<ActionResult<ExternalDpDtoWithEndpointDetails>> AddAsync([FromBody] ExternalDpDtoWithEndpointDetails externalDp)
        {
            var addedExternalDp = await _externalDpService.AddAsync(externalDp);
            return PartialView("_ExternalDpPartialView", addedExternalDp);
        }
    }
}