using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointTracer.Api.Dtos
{
    public class ExternalDpCreationDtoWithAddresses
    {
       // [Required] FluentValidation
        public string DpName { get; set; } = null!;

        public string ManagementUrl { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Description { get; set; } = null!;
        public List<EndpointAddressesDetailsDto> EndpointAddresses { get; set; } = null!;
        public List<CertificatesDetailsDto> Certificates { get; set; } = null!;
    }
}