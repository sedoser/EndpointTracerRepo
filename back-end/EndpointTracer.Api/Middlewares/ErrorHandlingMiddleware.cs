using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using EndpointTracer.Biz.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EndpointTracer.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;


        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            
        }

        private static  Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            var stackTrace = string.Empty;
            string message = "";
            var exceptionType = exception.GetType();

            if (exceptionType == typeof(EmptyDpInputException))
            {
                message = exception.Message;
                statusCode = HttpStatusCode.BadRequest;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(ArgumentNullException))
            {
                message = exception.Message;
                statusCode = HttpStatusCode.BadRequest;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(ApplicationException))
            {
                message = exception.Message;
                statusCode = HttpStatusCode.InternalServerError;
                stackTrace = exception.StackTrace;
            } 
            else if (exceptionType == typeof(IdNotFoundException))
            {
                message = exception.Message;
                statusCode = HttpStatusCode.NotFound;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(ValidationException))
            {
                message = exception.Message;
                statusCode = HttpStatusCode.BadRequest;
                stackTrace = exception.StackTrace;
            }
            else
            {
                message = "An error occurred.";
                statusCode = HttpStatusCode.InternalServerError;
                stackTrace = exception.StackTrace;
            }

        return Task.CompletedTask;  
        }
    }
    
}