using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using EndpointTracer.Biz;
using EndpointTracer.Model;
using Microsoft.AspNetCore.Mvc;

namespace EndpointTracer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService _certificateService;

        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService; 
        } 
        [HttpPost(Name = "Add")]
        public async Task AddAsync(Certificate certificate)
        {
            await _certificateService.AddAsync(certificate);
        }
        [HttpGet(Name = "GetAll")]
         public async Task<ActionResult<Certificate>> GetAllAsync()
        {
            return Ok(await _certificateService.GetAllAsync());
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<Certificate>> GetByIdAsync(int id)
        {
            try
            {
                var certificate = await _certificateService.GetByIdAsync(id);
                return Ok(certificate);
            }
            catch(KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete(Name = "Remove")]
        public void Remove(Certificate certificate)
        {
            _certificateService.Remove(certificate);
        }
        [HttpPut(Name = "Update")]
        public async Task Update(Certificate certificate)
        {
            var existingCertificate = await _certificateService.GetByIdAsync(certificate.CertificateId);
            if (existingCertificate == null)
            {
                throw new KeyNotFoundException($"A certificate with the ID {certificate.CertificateId} was not found.");
            }
        }
    }
}