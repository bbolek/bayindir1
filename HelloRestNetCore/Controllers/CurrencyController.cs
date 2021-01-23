using System.Collections.Generic;
using HelloRestNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloRestNetCore.Controllers
{
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        public List<Currency> Get([FromRoute] string name)
        {
            var currencies = new List<Currency>()
            {
                new Currency()
                {
                    IsUp = true,
                    Name = "USD",
                    Sign = "$",
                    Value = 7.4m
                },
                new Currency()
                {
                    IsUp = false,
                    Name = "TL",
                    Sign = "₺",
                    Value = 1m
                }
            };

            return currencies;
        }
    }
}
