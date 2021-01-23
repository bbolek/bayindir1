using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRestNetCore.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int PersonAge { get; set; }

        public List<PersonAddress> PersonAddresses;
    }
}
