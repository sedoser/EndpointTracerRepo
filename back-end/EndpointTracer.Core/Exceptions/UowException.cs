using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointTracer.Core.Exceptions
{
    public class UowException : Exception
    {
        public UowException(string message, Exception innerException) : base(message, innerException) {}
        
    }
}