using System;
using HelloRestNetCore.Models;

namespace HelloRestNetCore.Services.Interfaces
{
    public interface ICustomerService
    {
        Guid CreateCustomer(Customer customer);
    }
}
