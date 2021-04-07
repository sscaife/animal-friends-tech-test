using System;
using System.Collections.Generic;
using System.Text;
using AnimalFriends.Core.Presentation;
using FluentAssertions;
using NUnit.Framework;

namespace AnimalFriends.Core.Unit.Tests
{
    public class DateOfBirthValidationAttributeTests
    {
        private DateOfBirthValidationAttribute _attribute;

        [SetUp]
        public void Setup()
        {
            _attribute = new DateOfBirthValidationAttribute();
        }

        [TestCase(-18, true)]
        [TestCase(-17, false)]
        [TestCase(-50, true)]
        [TestCase(0, false)]
        public void IsValid_GivenDateOfBirth_ValueGivenPassesValidation(int yearsToAdd, bool passesValidation)
        {
            var actual = _attribute.IsValid(DateTime.Now.AddYears(yearsToAdd));

            actual.Should().Be(passesValidation);
        }

        [Test]
        public void IsValid_GivenNonDateValue_ReturnsFalse()
        {
            var actual = _attribute.IsValid("a string");

            actual.Should().Be(false);
        }

        [Test]
        public void IsValid_GivenNullDate_ReturnsTrue()
        {
            var actual = _attribute.IsValid(null);

            actual.Should().Be(true);
        }
    }
}
