using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointTracer.Api.Dtos
{
    public class EndpointAddressesDetailsDto
    {
        public int EndpointAddressId { get; set; }  
        public string Endpoint { get; set; } = null!;
        public string Datapower { get; set; } = null!;
        public string Env { get; set; } = null!;
    }
}