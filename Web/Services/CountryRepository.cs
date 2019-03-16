using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetWorth.Web.Data;
using NetWorth.Web.Models;

namespace NetWorth.Web.Services
{
    public class CountryRepository: ICountryRepository
    {
        private readonly IDataContext _dataContext;

        public CountryRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Country> GetAll()
        {
            return _dataContext.Counties.ToList();
        }
    }
}
