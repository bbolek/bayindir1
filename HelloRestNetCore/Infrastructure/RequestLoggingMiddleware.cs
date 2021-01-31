using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace HelloRestNetCore.Infrastructure
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                Console.WriteLine("I am a pre logger");
                await _next(context);
            }
            finally
            {
                Console.WriteLine("I am a logger");
                Console.WriteLine($"Request {context.Request?.Method} {context.Request?.Path.Value} => {context.Response?.StatusCode}");
            }
        }
    }
}
