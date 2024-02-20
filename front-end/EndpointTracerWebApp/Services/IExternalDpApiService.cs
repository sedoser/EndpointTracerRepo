using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndpointTracerWebApp.Dtos;

namespace EndpointTracerWebApp.Services
{
    public interface IExternalDpApiService
    {
        Task<List<ExternalDpDto>> GetExternalDpsAsync();
        Task<bool> RemoveAsync(int externalDpId); 
        Task<ExternalDpDto> GetbyIdAsync(int externalDpId);
    }      
}