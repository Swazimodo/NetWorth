using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using NetWorth.Web.Data;
using NetWorth.Web.Models;
using NetWorth.Web.Services;

namespace NetWorth.Web.Tests
{
    public class Test_CurrencyConverter
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CurrencyConverter_ConvertZeroUSDToUSD_ValueShouldNotChange()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country() { CountryName="United States", CurrencyAbbrv="USD", CurrencyName="US Dollar", ExchangeRateToUSD=1 },
                new Country() { CountryName="Canada", CurrencyAbbrv="CAD", CurrencyName="Candadian Dollar", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="Russia", CurrencyAbbrv="RUB", CurrencyName="Russian Ruble", ExchangeRateToUSD=0.015 },
                new Country() { CountryName="Japan", CurrencyAbbrv="JPY", CurrencyName="Japan Yen", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="England", CurrencyAbbrv="GBP", CurrencyName="Great British Pound", ExchangeRateToUSD=1.33 },
            };
            var db = new Mock<IDataContext>();
            db.Setup(x => x.Counties).Returns(countries.AsQueryable());
            ICountryRepository countryRepo = new CountryRepository(db.Object);
            ICurrencyConverter sut = new CurrencyConverter(countryRepo);

            // Act
            var convertedValue = sut.ConvertToUSD("USD", 0);

            // Assert
            Assert.AreEqual(convertedValue,0);
        }

        [Test]
        public void CurrencyConverter_ConvertZeroCADToUSD_ValueShouldNotChange()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country() { CountryName="United States", CurrencyAbbrv="USD", CurrencyName="US Dollar", ExchangeRateToUSD=1 },
                new Country() { CountryName="Canada", CurrencyAbbrv="CAD", CurrencyName="Candadian Dollar", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="Russia", CurrencyAbbrv="RUB", CurrencyName="Russian Ruble", ExchangeRateToUSD=0.015 },
                new Country() { CountryName="Japan", CurrencyAbbrv="JPY", CurrencyName="Japan Yen", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="England", CurrencyAbbrv="GBP", CurrencyName="Great British Pound", ExchangeRateToUSD=1.33 },
            };
            var db = new Mock<IDataContext>();
            db.Setup(x => x.Counties).Returns(countries.AsQueryable());
            ICountryRepository countryRepo = new CountryRepository(db.Object);
            ICurrencyConverter sut = new CurrencyConverter(countryRepo);

            // Act
            var convertedValue = sut.ConvertToUSD("CAD", 0);

            // Assert
            Assert.AreEqual(convertedValue, 0);
        }

        [Test]
        public void CurrencyConverter_ConvertThirtyUSDToUSD_ValueShouldNotChange()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country() { CountryName="United States", CurrencyAbbrv="USD", CurrencyName="US Dollar", ExchangeRateToUSD=1 },
                new Country() { CountryName="Canada", CurrencyAbbrv="CAD", CurrencyName="Candadian Dollar", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="Russia", CurrencyAbbrv="RUB", CurrencyName="Russian Ruble", ExchangeRateToUSD=0.015 },
                new Country() { CountryName="Japan", CurrencyAbbrv="JPY", CurrencyName="Japan Yen", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="England", CurrencyAbbrv="GBP", CurrencyName="Great British Pound", ExchangeRateToUSD=1.33 },
            };
            var db = new Mock<IDataContext>();
            db.Setup(x => x.Counties).Returns(countries.AsQueryable());

            ICountryRepository countryRepo = new CountryRepository(db.Object);
            ICurrencyConverter sut = new CurrencyConverter(countryRepo);
            double value = 30d;

            // Act
            var convertedValue = sut.ConvertToUSD("USD", value);

            // Assert
            Assert.AreEqual(convertedValue, value);
        }

        [Test]
        public void CurrencyConverter_ConvertThirtyCADToUSD_ValueShouldUpdateCorrectly()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country() { CountryName="United States", CurrencyAbbrv="USD", CurrencyName="US Dollar", ExchangeRateToUSD=1 },
                new Country() { CountryName="Canada", CurrencyAbbrv="CAD", CurrencyName="Candadian Dollar", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="Russia", CurrencyAbbrv="RUB", CurrencyName="Russian Ruble", ExchangeRateToUSD=0.015 },
                new Country() { CountryName="Japan", CurrencyAbbrv="JPY", CurrencyName="Japan Yen", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="England", CurrencyAbbrv="GBP", CurrencyName="Great British Pound", ExchangeRateToUSD=1.33 },
            };
            var db = new Mock<IDataContext>();
            db.Setup(x => x.Counties).Returns(countries.AsQueryable());

            ICountryRepository countryRepo = new CountryRepository(db.Object);
            ICurrencyConverter sut = new CurrencyConverter(countryRepo);
            double value = 30d;

            // Act
            var convertedValue = sut.ConvertToUSD("CAD", value);

            // Assert
            Assert.AreEqual(convertedValue, countries[1].ExchangeRateToUSD * value);
        }

        [Test]
        public void CurrencyConverter_ConvertZeroUSDFromUSD_ValueShouldNotChange()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country() { CountryName="United States", CurrencyAbbrv="USD", CurrencyName="US Dollar", ExchangeRateToUSD=1 },
                new Country() { CountryName="Canada", CurrencyAbbrv="CAD", CurrencyName="Candadian Dollar", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="Russia", CurrencyAbbrv="RUB", CurrencyName="Russian Ruble", ExchangeRateToUSD=0.015 },
                new Country() { CountryName="Japan", CurrencyAbbrv="JPY", CurrencyName="Japan Yen", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="England", CurrencyAbbrv="GBP", CurrencyName="Great British Pound", ExchangeRateToUSD=1.33 },
            };
            var db = new Mock<IDataContext>();
            db.Setup(x => x.Counties).Returns(countries.AsQueryable());
            ICountryRepository countryRepo = new CountryRepository(db.Object);
            ICurrencyConverter sut = new CurrencyConverter(countryRepo);

            // Act
            var convertedValue = sut.ConvertFromUSD("USD", 0);

            // Assert
            Assert.AreEqual(convertedValue, 0);
        }

        [Test]
        public void CurrencyConverter_ConvertZeroCADFromUSD_ValueShouldNotChange()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country() { CountryName="United States", CurrencyAbbrv="USD", CurrencyName="US Dollar", ExchangeRateToUSD=1 },
                new Country() { CountryName="Canada", CurrencyAbbrv="CAD", CurrencyName="Candadian Dollar", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="Russia", CurrencyAbbrv="RUB", CurrencyName="Russian Ruble", ExchangeRateToUSD=0.015 },
                new Country() { CountryName="Japan", CurrencyAbbrv="JPY", CurrencyName="Japan Yen", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="England", CurrencyAbbrv="GBP", CurrencyName="Great British Pound", ExchangeRateToUSD=1.33 },
            };
            var db = new Mock<IDataContext>();
            db.Setup(x => x.Counties).Returns(countries.AsQueryable());
            ICountryRepository countryRepo = new CountryRepository(db.Object);
            ICurrencyConverter sut = new CurrencyConverter(countryRepo);

            // Act
            var convertedValue = sut.ConvertFromUSD("CAD", 0);

            // Assert
            Assert.AreEqual(convertedValue, 0);
        }

        [Test]
        public void CurrencyConverter_ConvertThirtyUSDFromUSD_ValueShouldNotChange()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country() { CountryName="United States", CurrencyAbbrv="USD", CurrencyName="US Dollar", ExchangeRateToUSD=1 },
                new Country() { CountryName="Canada", CurrencyAbbrv="CAD", CurrencyName="Candadian Dollar", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="Russia", CurrencyAbbrv="RUB", CurrencyName="Russian Ruble", ExchangeRateToUSD=0.015 },
                new Country() { CountryName="Japan", CurrencyAbbrv="JPY", CurrencyName="Japan Yen", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="England", CurrencyAbbrv="GBP", CurrencyName="Great British Pound", ExchangeRateToUSD=1.33 },
            };
            var db = new Mock<IDataContext>();
            db.Setup(x => x.Counties).Returns(countries.AsQueryable());

            ICountryRepository countryRepo = new CountryRepository(db.Object);
            ICurrencyConverter sut = new CurrencyConverter(countryRepo);
            double value = 30d;

            // Act
            var convertedValue = sut.ConvertFromUSD("USD", value);

            // Assert
            Assert.AreEqual(convertedValue, value);
        }

        [Test]
        public void CurrencyConverter_ConvertThirtyCADFromUSD_ValueShouldUpdateCorrectly()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country() { CountryName="United States", CurrencyAbbrv="USD", CurrencyName="US Dollar", ExchangeRateToUSD=1 },
                new Country() { CountryName="Canada", CurrencyAbbrv="CAD", CurrencyName="Candadian Dollar", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="Russia", CurrencyAbbrv="RUB", CurrencyName="Russian Ruble", ExchangeRateToUSD=0.015 },
                new Country() { CountryName="Japan", CurrencyAbbrv="JPY", CurrencyName="Japan Yen", ExchangeRateToUSD=0.75 },
                new Country() { CountryName="England", CurrencyAbbrv="GBP", CurrencyName="Great British Pound", ExchangeRateToUSD=1.33 },
            };
            var db = new Mock<IDataContext>();
            db.Setup(x => x.Counties).Returns(countries.AsQueryable());

            ICountryRepository countryRepo = new CountryRepository(db.Object);
            ICurrencyConverter sut = new CurrencyConverter(countryRepo);
            double value = 30d;

            // Act
            var convertedValue = sut.ConvertFromUSD("CAD", value);

            // Assert
            Assert.AreEqual(convertedValue, value / countries[1].ExchangeRateToUSD);
        }
    }
}