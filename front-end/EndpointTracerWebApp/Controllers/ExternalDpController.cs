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
        public async Task<IActionResult> Index()//karisik olmus olabilir sadelestirilebilir
        {
            var externalDps = await _externalDpService.GetExternalDpsAsync();
            /*
            var externalDpDetailed = new ExternalDpDtoWithEndpointDetails();
            var externalDpViewModel = new ExternalDpViewModel
            {
                ExternalDps = externalDps,
                ExternalDpDetailed = externalDpDetailed
            };
            */
            /*
            List<ExternalDpDtoWithEndpointDetails> externalDpsDetailedList = new List<ExternalDpDtoWithEndpointDetails>();
            foreach (var externalDp in externalDps)
            {
                var externalDpId = externalDp.Id;
                var externalDpDetailed = await _externalDpService.GetbyIdAsync(externalDpId);
                externalDpsDetailedList.Add(externalDpDetailed);
            }
            */
            var externalDpViewModel = new ExternalDpViewModel
            {
                ExternalDps = externalDps,
                //ExternalDpsDetailed = externalDpsDetailedList
            };
            
            return View(externalDpViewModel);
        }
        
        [HttpGet("{externalDpId}")]
        public async Task<IActionResult> GetByIdAsync(int externalDpId)
        {
            var externalDp = await _externalDpService.GetbyIdAsync(externalDpId);
            return PartialView("_ExternalDpPartialView" , externalDp);
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