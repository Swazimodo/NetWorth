namespace NetWorth.Web.Services
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private readonly ICountryRepository _countryRepository;

        public CurrencyConverter(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public double ConvertFromUSD(string currencyAbbrv, double value)
        {
            return value / _countryRepository.GetByCurrencyAbbrv(currencyAbbrv).ExchangeRateToUSD;
        }

        public double ConvertToUSD(string currencyAbbrv, double value)
        {
            return _countryRepository.GetByCurrencyAbbrv(currencyAbbrv).ExchangeRateToUSD * value;
        }
    }
}
