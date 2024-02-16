using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using EndpointTracer.Api.Dtos;
using EndpointTracer.Biz;
using EndpointTracer.Biz.Exceptions;
using EndpointTracer.Model;
using EndpointTracer.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EndpointTracer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalDpController : ControllerBase
    {
        private readonly IExternalDpService _externalDpService;

        public ExternalDpController(IExternalDpService externalDpService)
        {
            _externalDpService = externalDpService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnDto>>> GetAllAsync()
        {
            var externaDps = await _externalDpService.GetAllAsync();

            List<ReturnDto> returnDtos = new List<ReturnDto>();

            foreach (var externaDp in externaDps)
            {
                ReturnDto returnDto = new ReturnDto
                {
                    DpName = externaDp.DpName,
                    ManagementUrl = externaDp.ManagementUrl,
                    Type = externaDp.Type,
                    Description = externaDp.Description
                };
                returnDtos.Add(returnDto);
            }
            return Ok(returnDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExternalDp>> GetByIdAsync(int id)
        {
            var externalDp = await _externalDpService.GetByIdAsync(id);

            return Ok(externalDp);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ExternalDpCreationDtoWithAddresses requestDto)
        {
            ExternalDp externalDp = new ExternalDp
            {
                DpName = requestDto.DpName,
                ManagementUrl = requestDto.ManagementUrl,
                Type = requestDto.Type,
                Description = requestDto.Description
            };
            var createdExternalDp = await _externalDpService.AddAsync(externalDp);

            return Created($"api/{createdExternalDp.ExternalDpId}", createdExternalDp);
        }

        [HttpPut]
        public async Task<ActionResult<ExternalDp>> Update(ExternalDp externalDp)
        {
            await _externalDpService.Update(externalDp);

            return Ok(externalDp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _externalDpService.RemoveAsync(id);

            return Ok();
        }
    }
}