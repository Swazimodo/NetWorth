using System;
using System.Collections.Generic;
using System.Linq;
using NetWorth.Web.Data;
using NetWorth.Web.Models;

namespace NetWorth.Web.Services
{
    public class CountryRepository: ICountryRepository
    {
        private readonly IDataContext _dataContext;

        public CountryRepository(IDataContext dataContext)
        {
            if (dataContext == null) throw new ArgumentNullException("dataContext");
            _dataContext = dataContext;
        }

        public List<Country> GetAll()
        {
            return _dataContext.Counties.ToList();
        }

        public Country GetByCurrencyAbbrv(string abbreviation)
        {
            return _dataContext.Counties.FirstOrDefault(x => x.CurrencyAbbrv == abbreviation);
        }
    }
}
