using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetWorth.Web.Models.Api;
using NetWorth.Web.Services;

namespace NetWorth.Web.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyCalcController : Controller
    {
        private readonly ICurrencyConverter _currencyConverter;

        public CurrencyCalcController(ICurrencyConverter currencyConverter)
        {
            _currencyConverter = currencyConverter;
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
