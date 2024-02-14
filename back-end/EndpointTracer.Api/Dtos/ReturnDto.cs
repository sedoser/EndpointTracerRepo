using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointTracer.Api.Dtos
{
    public class ReturnDto
    {
        public string DpName { get; set; } = null!;

        public string ManagementUrl { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}