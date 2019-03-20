using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetWorth.Web.Models.Api;
using NetWorth.Web.Services;

namespace NetWorth.Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class CurrencyCalcController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICurrencyConverter _currencyConverter;

        public CurrencyCalcController(ICountryRepository countryRepository, ICurrencyConverter currencyConverter)
        {
            _countryRepository = countryRepository;
            _currencyConverter = currencyConverter;
        }

        [HttpGet]
        public IActionResult GetCurrenciesList()
        {
            return Ok(_countryRepository.GetAll().Select(x => x.CurrencyAbbrv));
        }

        [HttpPost]
        public IActionResult CalculateTotal([FromBody] CalculateTotalModel model)
        {
            var usd = model.Roster.Aggregate(
                0d, 
                (total, item) => total + _currencyConverter.ConvertToUSD(item.currencyAbbrv, item.Value));
            var convertedTotal = _currencyConverter.ConvertFromUSD(model.TargetCurrencyAbbrv, usd);
            return Ok(Math.Round(convertedTotal, 2));
        }
    }
}
