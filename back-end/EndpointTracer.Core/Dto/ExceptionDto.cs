using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointTracer.Core.Dto
{
    public class ExceptionDto
    {
        public string Message { get; set; }

        public string InnerMessage { get; set; }

        public int Code { get; set; }

        public ExceptionDto()
        {

        }
        
        public ExceptionDto(string message, string innerMessage, int code)
        {
            Message = message;
            InnerMessage = innerMessage;
            Code = code;
        }
    }
}