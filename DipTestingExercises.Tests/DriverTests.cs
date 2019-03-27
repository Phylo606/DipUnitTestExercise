using System;
using NUnit.Framework;
using DipTestingExercises.Tests.Mocks;

namespace DipTestingExercises.Tests
{
    [TestFixture]
    public class DriverTests
    {
        Driver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new FakeDriver("Jane", "Doe", "Female", "Probationary");
        }

        [Test]
        public void Driver_IsCalled_PropertiesAreSet()
        {
            // act

            // assert
            Assert.That(_driver.fname.Equals("Jane"));
            Assert.That(_driver.lname.Equals("Doe"));
            Assert.That(_driver.getGender().Equals("Female"));
            Assert.That(_driver.getLicenceType().Equals("Probationary"));

        }

        [Test]
        public void GetLicenceType_IsCalled_ReturnsCorrectLicenceType()
        {
            // act
            var result = _driver.getLicenceType();

            // assert
            Assert.That(result.Equals("Probationary"));
        }
    }
}
