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
        public void CountryRepository_GetAll_ReturnsAllItems()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country() { Id=1, CountryName="1" },
                new Country() { Id=2, CountryName="2" },
                new Country() { Id=3, CountryName="3" },
                new Country() { Id=4, CountryName="4" },
                new Country() { Id=5, CountryName="5" }
            };
            var db = new Mock<IDataContext>();
            db.Setup(x => x.Counties).Returns(countries.AsQueryable());

            // Act
            ICountryRepository sut = new CountryRepository(db.Object);
            
            // Assert
            Assert.AreEqual(sut.GetAll().Count, countries.Count);
        }
    }
}