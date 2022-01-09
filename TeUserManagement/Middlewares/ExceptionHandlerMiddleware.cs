using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TeUserManagement.Domain.Helpers.Exceptions;
using TeUserManagement.Models.Responses;

namespace TeUserManagement.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var customExceptionStatusCode = context.Response.StatusCode == StatusCodes.Status200OK 
                ? StatusCodes.Status500InternalServerError 
                : context.Response.StatusCode;

            if (exception is ICustomException customException)
            {
                context.Response.StatusCode = StatusCodes.Status200OK;
                customExceptionStatusCode = customException.StatusCode;
            }

            var resp = GenericResponse<string>.GenerateResponse(customExceptionStatusCode, message: exception.Message);
            await context.Response.WriteAsync(JsonSerializer.Serialize(resp));
        }
    }
}
