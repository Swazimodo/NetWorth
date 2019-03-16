using System.Collections.Generic;
using NetWorth.Web.Models;

namespace NetWorth.Web.Services
{
    public interface ICountryRepository
    {
        List<Country> GetAll();
        Country GetByCurrencyAbbrv(string abbreviation);
    }
}
