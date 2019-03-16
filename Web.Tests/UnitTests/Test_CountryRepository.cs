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
    public class Test_CountryRepository
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CountryRepository_CreateRepository_ThrowOnNullDataContext()
        {
            // Arrange
            try
            {
                // Act
                ICountryRepository sut = new CountryRepository(null);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void CountryRepository_UseNullCollection_ThrowException()
        {
            // Arrange
            var db = new Mock<IDataContext>();
            db.Setup(x => x.Counties).Returns<IQueryable>(null);
            ICountryRepository sut = new CountryRepository(db.Object);

            try
            {
                // Act
                sut.GetAll();

                // Assert
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void CountryRepository_GetAll_ReturnsAllItems()
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

            // Act
            ICountryRepository sut = new CountryRepository(db.Object);
            
            // Assert
            Assert.AreEqual(sut.GetAll().Count, countries.Count);
        }

        [Test]
        public void CountryRepository_GetByAbbrv_ReturnCorrectCountry()
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

            // Act
            ICountryRepository sut = new CountryRepository(db.Object);

            // Assert
            Assert.AreEqual(sut.GetByCurrencyAbbrv("USD"), countries[0]);
            Assert.AreEqual(sut.GetByCurrencyAbbrv("JPY"), countries[3]);
        }

        [Test]
        public void CountryRepository_GetByAbbrv_ReturnNullIfNotFound()
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

            // Act
            ICountryRepository sut = new CountryRepository(db.Object);

            // Assert
            Assert.AreEqual(sut.GetByCurrencyAbbrv("ABC"), null);
        }
    }
}