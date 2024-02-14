using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointTracer.Biz.Exceptions
{
     public class EmptyDpInputException : Exception
    {
        public EmptyDpInputException()
            : base("DpName property cannot be empty.")
        {
        }
        public EmptyDpInputException(string message)
            : base(message)
        {
        }
        public EmptyDpInputException(string message, Exception inner)
            : base(message, inner)
        {
        }        
    }
}