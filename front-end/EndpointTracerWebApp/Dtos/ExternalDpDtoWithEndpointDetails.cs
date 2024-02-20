using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointTracerWebApp.Dtos
{
    public class ExternalDpDtoWithEndpointDetails
    {
        public int Id { get; set; }
        public string DpName { get; set; } = null!;

        public string ManagementUrl { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Description { get; set; } = null!; 
        public List<EndpointAddressesDetailsDto> EndpointAddresses { get; set; } = new List<EndpointAddressesDetailsDto>();
        public List<CertificatesDetailsDto> Certificates { get; set; } = new List<CertificatesDetailsDto>();
    }
}