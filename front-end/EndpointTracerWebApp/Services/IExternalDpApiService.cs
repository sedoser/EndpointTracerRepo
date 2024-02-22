using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndpointTracerWebApp.Dtos;

namespace EndpointTracerWebApp.Services
{
    public interface IExternalDpApiService
    {
        Task<List<ExternalDpDtoWithoutEndpointDetails>> GetExternalDpsAsync();
        Task<bool> RemoveAsync(int externalDpId); 
        Task<ExternalDpDtoWithEndpointDetails> GetbyIdAsync(int externalDpId);
        Task<bool> UpdateAsync(ExternalDpDtoWithEndpointDetails externalDp);
        Task<ExternalDpDtoWithEndpointDetails> AddAsync(ExternalDpDtoWithEndpointDetails externalDp);
    }      
}