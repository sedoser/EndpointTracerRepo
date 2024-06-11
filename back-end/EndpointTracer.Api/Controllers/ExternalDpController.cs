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
        public async Task<ActionResult<IEnumerable<ExternalDpReturnToWebAppDto>>> GetAllAsync()
        {
            var externaDps = await _externalDpService.GetAllAsync();
            //var externalDp = mapper.Map<ExternalDp>(requestDto);
            List<ExternalDpReturnToWebAppDto> returnDtos = new List<ExternalDpReturnToWebAppDto>();

            foreach (var externaDp in externaDps)
            {
                ExternalDpReturnToWebAppDto returnDto = new ExternalDpReturnToWebAppDto
                {
                    Id = externaDp.ExternalDpId,
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
                //Schedule tasks. => Quartz, Hangfire, etc.
            //IMapper mapper = new Mapper(); ctor injection -d    
            //var externalDp = mapper.Map<ExternalDp>(requestDto);
            ExternalDp externalDp = new ExternalDp
            {
                DpName = requestDto.DpName,
                ManagementUrl = requestDto.ManagementUrl,
                Type = requestDto.Type,
                Description = requestDto.Description,
                EndpointAddresses = requestDto.EndpointAddresses.Select(x => new EndpointAddress
                {
                    Endpoint = x.Endpoint,
                    Datapower = x.Datapower,
                    Env = x.Env
                }).ToList(),
                Certificates = requestDto.Certificates.Select(x => new Certificate
                {
                    Pem = x.Pem,
                    ExpirationDate = x.ExpirationDate,
                    CreatedAt = x.CreatedAt,
                    Type = x.Type,
                    Desc = x.Desc
                }).ToList(),
            };
            var createdExternalDp = await _externalDpService.AddAsync(externalDp);

            return Created($"api/{createdExternalDp.ExternalDpId}", createdExternalDp);
        }

        [HttpPut]
        public async Task<ActionResult<ExternalDp>> Update(ExternalDpUpdateDto externalDpDto)
        {
            ExternalDp externalDp = new ExternalDp
            {
                ExternalDpId = externalDpDto.ExternalDpId,
                DpName = externalDpDto.DpName,
                ManagementUrl = externalDpDto.ManagementUrl,
                Type = externalDpDto.Type,
                Description = externalDpDto.Description,
                EndpointAddresses = externalDpDto.EndpointAddresses.Select(x => new EndpointAddress
                {
                    EndpointAddressId = x.EndpointAddressId,
                    Endpoint = x.Endpoint,
                    Datapower = x.Datapower,
                    Env = x.Env
                }).ToList(),
                Certificates = externalDpDto.Certificates.Select(x => new Certificate
                {
                    CertificateId = x.CertificateId,
                    Pem = x.Pem,
                    ExpirationDate = x.ExpirationDate,
                    CreatedAt = x.CreatedAt,
                    Type = x.Type,
                    Desc = x.Desc
                }).ToList(),
            };
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