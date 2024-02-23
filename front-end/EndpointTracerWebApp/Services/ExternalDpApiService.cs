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

        

        public async Task<ExternalDpDtoWithEndpointDetails> GetbyIdAsync(int externalDpId)
        {
            var response = await _client.GetFromJsonAsync<ExternalDpDtoWithEndpointDetails>(_client.BaseAddress + "ExternalDp/" + externalDpId);
            return response!;
        }

        public async Task<List<ExternalDpDtoWithoutEndpointDetails>> GetExternalDpsAsync()
        {
            var response = await _client.GetFromJsonAsync<List<ExternalDpDtoWithoutEndpointDetails>>(_client.BaseAddress + "ExternalDp");
            return response!;
        }

        public async Task<bool> RemoveAsync(int externalDpId)
        {
            var response = await _client.DeleteAsync(_client.BaseAddress + "ExternalDp/" + externalDpId);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateAsync(ExternalDpDtoWithEndpointDetails externalDp)
        {
            var response = await _client.PutAsJsonAsync(_client.BaseAddress + "ExternalDp", externalDp);

            var responseStr = await response.Content.ReadAsStringAsync();   

            return response.IsSuccessStatusCode;
        }
        public async Task<ExternalDpDtoWithEndpointDetails> AddAsync(ExternalDpDtoWithEndpointDetails externalDp)
        {
            var response = await _client.PostAsJsonAsync(_client.BaseAddress + "ExternalDp", externalDp);

            var responseString = await response.Content.ReadAsStringAsync();
            
            return response.Content.ReadFromJsonAsync<ExternalDpDtoWithEndpointDetails>().Result;
        }
    }
}