using System;
using HelloRestNetCore.Models;
using HelloRestNetCore.Services.Interfaces;

namespace HelloRestNetCore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDatabaseService _databaseService;
        private readonly EverytimeNew _obj;

        public CustomerService(IDatabaseService databaseService, EverytimeNew obj)
        {
            _databaseService = databaseService;
            _obj = obj;
        }

        public Guid CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            Console.WriteLine(_obj.date);
            Console.Write(customer.FirstName);
            return _databaseService.Save(customer);
        }
    }
}
