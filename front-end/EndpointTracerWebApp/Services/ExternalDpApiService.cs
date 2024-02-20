using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndpointTracerWebApp.Dtos;

namespace EndpointTracerWebApp.Services
{
    public class ExternalDpApiService : IExternalDpApiService
    {
        private readonly HttpClient _client;

        public ExternalDpApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ExternalDpDto> GetbyIdAsync(int externalDpId)
        {
            var response = await _client.GetFromJsonAsync<ExternalDpDto>(_client.BaseAddress + "ExternalDp/" + externalDpId);
            return response!;
        }

        public async Task<List<ExternalDpDto>> GetExternalDpsAsync()
        {
            var response = await _client.GetFromJsonAsync<List<ExternalDpDto>>(_client.BaseAddress + "ExternalDp");
            return response!;
        }

        public async Task<bool> RemoveAsync(int externalDpId)
        {
            var response = await _client.DeleteAsync(_client.BaseAddress + "ExternalDp/" + externalDpId);
            return response.IsSuccessStatusCode;
        }
    }
}