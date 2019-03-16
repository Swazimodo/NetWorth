namespace NetWorth.Web.Models
{
    public class Country
    {
        public string CountryName { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyAbbrv { get; set; }
        public double ExchangeRateToUSD { get; set; }
    }
}
