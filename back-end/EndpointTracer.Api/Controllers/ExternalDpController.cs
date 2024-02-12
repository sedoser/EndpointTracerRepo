using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using EndpointTracer.Biz;
using EndpointTracer.Biz.Exceptions;
using EndpointTracer.Model;
using EndpointTracer.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost("Add")]//SOR: iki tane application exception varsa. biri savechanges biri updating.
        public async Task<IActionResult> AddAsync(ExternalDp externalDp)//requestDto
        {
            //ExternapDpCreationDto => {EXternapDp create etmek için gerekli ve yeterli olan prop'lar olsun}

            //ExternalDp externalDp = new(){ // //}; 
            try
            {
                await _externalDpService.AddAsync(externalDp);
                return Ok();// Created();
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ExternalDp externalDp)
        {
            try
            {
                 await _externalDpService.Update(externalDp);
                return Ok();
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


        [HttpGet("GetAll")]
         public async Task<ActionResult<ExternalDp>> GetAllAsync()
        {
            // var externalDps = await _externalDpService.GetAllAsync())
            // retunDto , List<REtunrDto> returnDtos = new(){

           // }
           /*

           foreach item externaDps 

           {
                REturnDto derturnDto = new(){
                    
                }

returnDtos.Add(returnDto);
           }

           return OK(returnDtos);
           */
            return Ok(await _externalDpService.GetAllAsync());
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<ExternalDp>> GetByIdAsync(int id)
        {
            try
            {
                var externalDp = await _externalDpService.GetByIdAsync(id);
                return Ok(externalDp);
            }
            catch(IdNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Remove/{externalDpId}")]
        public async Task<IActionResult> Remove(int externalDpId)
        {
            await _externalDpService.RemoveAsync(externalDpId);

            return Ok();
        }
        
    }
}