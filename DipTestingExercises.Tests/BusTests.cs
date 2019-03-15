using System;
using NUnit.Framework;
using DipTestingExercises.Tests.Mocks;

namespace DipTestingExercises.Tests
{
    [TestFixture]
    public class BusTests
    {
        IPerson _driver;
        IPerson _passenger;
        Bus _bus;

        [SetUp]
        public void Setup()
        {
            _driver = new FakeIPerson();
            _passenger = new FakeIPerson();
            _bus = new Bus(_driver, 100, 50, 2, 1);
        }


        [Test]
        public void Bus_IsCalled_PropertiesAreSet()
        {
            // act

            // assert
            Assert.That(_bus.maxPassengers.Equals(1));
        }

        [Test]
        public void GetPassengerCount_BusIsEmpty()
        {
            //act
            var result = _bus.getPassengerCount();
            
            //assert
            Assert.That(result.Equals(0));
        }

        [Test]
        public void GetPassengerCount_BusHasPassenger()
        {
            //act
            _bus.passengers.Add(_passenger);
            _bus.getPassengerCount();

            //assert
            Assert.That(_bus.passengers.Count.Equals(1));
        }

        [Test]
        public void EmbarkPassenger_BusHasRoomForPassenger_AddedToPassengerList()
        {
            //act
            _bus.embarkPassenger(_passenger);
            var result = _bus.passengers.Count;

            //assert
            Assert.That(result.Equals(1));
            Assert.That(_bus.passengers[0].Equals(_passenger));

        }

        [Test]
        public void EmbarkPassenger_BusIsFull_TwoPassengersAddedToPassengerList()
        {
            //act
            try
            {
                _bus.embarkPassenger(_passenger);
                _bus.embarkPassenger(_passenger);
                Assert.Fail();
            }

            //asert
            catch (Exception e)
            {
                var num_embarked = _bus.passengers.Count;
                Assert.That(e.Message.ToLower().Contains("bus"));
                Assert.That(e.Message.ToLower().Contains("full"));
                Assert.That(num_embarked.Equals(1));
            }

        }
    }
};
    