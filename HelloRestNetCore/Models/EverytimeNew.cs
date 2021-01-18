using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRestNetCore.Models
{
    public class EverytimeNew
    {
        public EverytimeNew()
        {
            date = Guid.NewGuid();
        }

        public Guid date { get; set; }
    }
}
