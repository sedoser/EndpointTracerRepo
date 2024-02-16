using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using EndpointTracer.Core.Dto;
using EndpointTracer.Core.Exceptions;
using Microsoft.AspNetCore.Http;


namespace EndpointTracer.Core.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionMiddleware(RequestDelegate next)
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

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ExceptionDto exceptionDto = new ExceptionDto();

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(CustomException))
            {
                exceptionDto.Message = "Bad request.";
                exceptionDto.Code = 400;
                exceptionDto.InnerMessage = exception.Message;
            }
            else if (exceptionType == typeof(UowException))
            {
                exceptionDto.Message = "Error while saving changes.";
                exceptionDto.Code = 500;
                exceptionDto.InnerMessage = exception.Message;
            }
            else
            {
                exceptionDto.Message = "An error occurred.";
                exceptionDto.Code = 500;
                exceptionDto.InnerMessage = exception.Message;
            }

            await context.Response.WriteAsync(JsonSerializer.Serialize(exceptionDto));

        }
    }
}
