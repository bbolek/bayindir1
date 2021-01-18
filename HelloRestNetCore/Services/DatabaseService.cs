using System;
using HelloRestNetCore.Models;
using HelloRestNetCore.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace HelloRestNetCore.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly RequestDetails _details;
        private IConfiguration _configuration;
        private readonly EverytimeNew _obj;

        public DatabaseService(RequestDetails details, IConfiguration configuration, EverytimeNew obj)
        {
            _details = details;
            _configuration = configuration;
            _obj = obj;
        }

        public Guid Save(Customer customer)
        {
            var deger = _configuration["Burak"];
            Console.WriteLine(_obj.date);
            Console.Write(_details.ipAddress);
            return Guid.NewGuid();
        }
    }
}
