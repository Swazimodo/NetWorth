using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetWorth.Web.Models;

namespace NetWorth.Web.Services
{
    public interface ICountryRepository
    {
        List<Country> GetAll();
        Country GetByCurrencyAbbrv(string abbreviation);
    }
}
