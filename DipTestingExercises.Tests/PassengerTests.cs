using System;
using NUnit.Framework;
using DipTestingExercises.Tests.Mocks;

namespace DipTestingExercises.Tests
{
    [TestFixture]
    public class PassengerTests
    {
        Passenger _passenger;

        [SetUp]
        public void SetUp()
        {
            _passenger = new FakePassenger("Bob", "Dylan", "Male", "Concession");
        }

        [Test]
        public void Passenger_IsCalled_PropertiesAreSet()
        {
            // act

            // assert
            Assert.That(_passenger.fname.Equals("Bob"));
            Assert.That(_passenger.lname.Equals("Dylan"));
            Assert.That(_passenger.getGender().Equals("Male"));
            Assert.That(_passenger.getTicketType().Equals("Concession"));

        }

        [Test]
        public void GetTicketType_IsCalled_ReturnsCorrectLicenceType()
        {
            // act
            var result = _passenger.getTicketType();

            // assert
            Assert.That(result.Equals("Concession"));
        }
    }
}
