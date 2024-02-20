using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndpointTracer.Model.Entities;

namespace EndpointTracer.Api.Dtos
{
    public class ExternalDpReturnToWebAppDto
    {
        public int Id { get; set; }
        public string DpName { get; set; } = null!;

        public string ManagementUrl { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Description { get; set; } = null!;
        List<EndpointAddressesDetailsDto> EndpointAddresses { get; set; } = new List<EndpointAddressesDetailsDto>();
        List<CertificatesDetailsDto> Certificates { get; set; } = new List<CertificatesDetailsDto>();
    }
}