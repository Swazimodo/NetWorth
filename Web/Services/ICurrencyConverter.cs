using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetWorth.Web.Services
{
    public interface ICurrencyConverter
    {
        double ConvertToUSD(string currencyAbbrv, double value);
        double ConvertFromUSD(string currencyAbbrv, double value);
    }
}
