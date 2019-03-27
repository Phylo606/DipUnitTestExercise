using System;
using NUnit.Framework;
using DipTestingExercises.Tests.Mocks;

namespace DipTestingExercises.Tests
{
    [TestFixture]
    public class PersonTests
    {
        Person _person;

        [SetUp]
        public void SetUp()
        {
            _person = new FakePerson("John", "Smith", "Male");
        }

        [Test]
        public void Person_IsCalled_PropertiesAreSet()
        {
            // act

            // assert
            Assert.That(_person.fname.Equals("John"));
            Assert.That(_person.lname.Equals("Smith"));
            Assert.That(_person.getGender().Equals("Male"));

        }

        [Test]
        public void getName_IsCalled_FullNameIsCorrect()
        {
            // act
            var result = _person.getName();

            // assert
            Assert.That(result.Equals("John Smith"));

        }

        [Test]
        public void getGender_IsCalled_GenderIsCorrect()
        {
            // act
            var result = _person.getGender();

            // assert
            Assert.That(result.Equals("Male"));
        }
    }
}
