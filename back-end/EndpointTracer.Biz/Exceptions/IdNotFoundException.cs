using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EndpointTracer.Biz.Exceptions
{
    public class IdNotFoundException : Exception
    {
        public int ExternalDpId { get; }
        public IdNotFoundException(int externalDpId)
            : base($"An ExternalDp with the ID {externalDpId} was not found.")
        {
            ExternalDpId = externalDpId;
        }
        public IdNotFoundException(string message)
            : base(message)
        {
        }
        public IdNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }        
    }
}