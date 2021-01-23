using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using HelloRestNetCore.Models;
using HelloRestNetCore.Services.Interfaces;

namespace HelloRestNetCore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDatabaseService _databaseService;
        private readonly EverytimeNew _obj;
        private readonly IMapper _mapper;

        public CustomerService(IDatabaseService databaseService, EverytimeNew obj, IMapper mapper)
        {
            _databaseService = databaseService;
            _obj = obj;
            _mapper = mapper;
        }

        public Guid CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            var person = new Person()
            {
                FirstName = "Burak",
                LastName = "Bolek",
                PersonAddresses = new List<PersonAddress>()
                {
                    new PersonAddress()
                    {
                        Line1 = null,
                        PersonCity = "Eskisehir"
                    },
                    new PersonAddress()
                    {
                        Line1 = "Cadde2",
                        PersonCity = "Eskisehir"
                    }
                },
                PersonAge = 36
            };

            var mappedCustomer = _mapper.Map<Customer>(person);

            return _databaseService.Save(customer);
        }
    }
}
