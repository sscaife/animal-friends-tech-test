using System;
using System.Collections.Generic;
using System.Text;
using AnimalFriends.Core.Presentation;
using FluentAssertions;
using NUnit.Framework;

namespace AnimalFriends.Core.Unit.Tests
{
    public class EmailOrDoBValidatorAttributeTests
    {
        private EmailOrDoBValidatorAttribute _attribute;

        [SetUp]
        public void Setup()
        {
            _attribute = new EmailOrDoBValidatorAttribute(new[] {"Email", "DateOfBirth"});
        }

        [Test]
        public void IsValid_GivenEmptyModel_ReturnsFalse()
        {
            var actual = _attribute.IsValid(new CustomerModel());

            actual.Should().BeFalse();
        }

        [Test]
        public void IsValid_GivenModelContainingDoB_ReturnsTrue()
        {
            var actual = _attribute.IsValid(new CustomerModel
            {
                DateOfBirth = DateTime.Now
            });

            actual.Should().BeTrue();
        }

        [Test]
        public void IsValid_GivenModelContainingEmail_ReturnsTrue()
        {
            var actual = _attribute.IsValid(new CustomerModel
            {
                Email = "anemail"
            });

            actual.Should().BeTrue();
        }

        [Test]
        public void IsValid_GivenModelContainingBothEmailAndDoB_ReturnsTrue()
        {
            var actual = _attribute.IsValid(new CustomerModel
            {
                Email = "anemail",
                DateOfBirth = DateTime.Now
            });

            actual.Should().BeTrue();
        }
    }
}
