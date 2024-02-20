using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointTracer.Api.Dtos
{
    public class CertificatesDetailsDto
    {
        public int CertificateId { get; set; }
        public string Pem { get; set; } = string.Empty;
        public DateTime ExpirationDate{ get; set; }
        public DateTime CreatedAt { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;  
    }
}