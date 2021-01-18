using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using HelloRestNetCore.Models;
using HelloRestNetCore.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace HelloRestNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private ICustomerService _customerService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            ICustomerService customerService, 
            RequestDetails request, 
            IHttpContextAccessor httpContextAccessor)
        {
            _customerService = customerService;
            _logger = logger;
            request.ipAddress = httpContextAccessor.HttpContext?.Connection.RemoteIpAddress;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var customer = new Customer();
            var customerId = _customerService.CreateCustomer(customer);
            _logger.LogInformation("Guid : " + customerId);
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
