using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndpointTracerWebApp.Dtos;

namespace EndpointTracerWebApp.Models
{
    public class ExternalDpViewModel
    {
        public List<ExternalDpDtoWithoutEndpointDetails> ExternalDps { get; set; }
        //public List<ExternalDpDtoWithEndpointDetails> ExternalDpsDetailed { get; set; }
    }
}