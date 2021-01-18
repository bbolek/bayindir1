using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloRestNetCore.Models;

namespace HelloRestNetCore.Services.Interfaces
{
    public interface IDatabaseService
    {
        public Guid Save(Customer customer);
    }
}
