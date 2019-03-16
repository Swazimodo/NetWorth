using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetWorth.Web.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyAbbrv { get; set; }
        public double ExchangeRateToUSD { get; set; }
    }
}
