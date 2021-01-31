using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace HelloRestNetCore.Infrastructure
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                Console.WriteLine("I am a pre exception");
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine("I am an exception");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var isUI = context.Request.Headers.ContainsKey("Jobzag-UI");
            var statusCode = (int) HttpStatusCode.InternalServerError;
            var message = "An error occurred.";

            switch (exception)
            {
                case ValidationException _:
                case ArgumentNullException _:
                    statusCode = (int) HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
                case ExternalException _:
                    statusCode = (int) HttpStatusCode.FailedDependency;
                    message = exception.Message;
                    break;
                default:
                    _logger.LogError($"API error: {exception}");
                    break;
            }

            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(new CustomErrorResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }

    public class CustomErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
