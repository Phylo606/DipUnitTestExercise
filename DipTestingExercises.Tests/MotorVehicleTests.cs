using System;
using NUnit.Framework;
using DipTestingExercises.Tests.Mocks;

namespace DipTestingExercises.Tests
{
    [TestFixture]
    public class MotorVehicleTests
    {
        IPerson _driver;
        MotorVehicle _mv;

        [SetUp]
        public void Setup()
        {
            _driver = new FakeIPerson();
            _mv = new FakeMotorVehicle(_driver, 100, 50, 2);
        }


        [Test]
        public void MotorVehicle_IsCalled_PropertiesAreSet()
        {
            // act

            // assert
            Assert.That(_mv.currentFuel.Equals(50));
            Assert.That(_mv.maxFuel.Equals(100));
            Assert.That(_mv.litresPerKM.Equals(2));
            Assert.That(_mv.driver.Equals(_driver));

        }


        [Test]
        public void GetFuelRemaining_IsCalled_ReturnsCorrectAmount()
        {
            // act
            var result = _mv.getFuelRemaining();

            // assert
            Assert.That(result.Equals(50));
        }


        [Test]
        public void refuel_HasEnoughRoom_CurrentFuelUpdatedCorrectlly()
        {
            // act
            _mv.refuel(50);

            // assert
            Assert.That(_mv.currentFuel.Equals(100));
        }


        [Test]
        public void refuel_DoesNotHaveEnoughRoom_ThrowsException()
        {
            // act
            try
            {
                _mv.refuel(51);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.That(e.Message.ToLower().Contains("cannot hold that much fuel"));
            }
        }


        [Test]
        public void refuel_AddingNegativeAmountOfFuel_ThrowsException()
        {
            // act
            try
            {
                _mv.refuel(-1);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.That(e.Message.ToLower().Contains("stealing fuel"));
            }
        }


        [Test]
        public void travel_HasEnoughFuel_ReturnsCorrectAmount()
        {
            // act
            _mv.travel(10);

            // assert
            Assert.That(_mv.currentFuel.Equals(30));
        }


        [Test]
        public void travel_DoesNotHaveEnoughFuel_ThrowsException()
        {
            // act
            try
            {
                _mv.travel(26);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.That(e.Message.ToLower().Contains("out of fuel"));
                Assert.That(_mv.currentFuel.Equals(0));
            }
        }
    }
}
