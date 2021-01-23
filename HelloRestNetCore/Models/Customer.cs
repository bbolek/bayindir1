using System.Collections.Generic;

namespace HelloRestNetCore.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }

        public List<CustomerAddress> Addresses;

    }
}
