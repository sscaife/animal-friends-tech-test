using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using AnimalFriends.Api.Controllers;
using AnimalFriends.Core;
using AnimalFriends.Core.Presentation;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace AnimalFriends.Api.Unit.Tests
{
    public class CustomerControllerTests
    {
        private CustomerController _controller;
        private Mock<ICustomerService> _customerService;

        [SetUp]
        public void Setup()
        {
            _customerService = new Mock<ICustomerService>();

            _controller = new CustomerController(_customerService.Object);
        }

        [Test]
        public void Constructor_GivenNullService_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new CustomerController(null);
            });
        }

        [Test]
        public async Task Register_GivenValidModel_SavesCustomer()
        {
            await _controller.Register(new CustomerModel(), CancellationToken.None);

            _customerService.Verify(o => o.SaveModelAsync(It.IsAny<CustomerModel>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task Register_GivenValidModel_ReturnsReferenceNumber()
        {
            _customerService.Setup(o => o.SaveModelAsync(It.IsAny<CustomerModel>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var response = await _controller.Register(new CustomerModel(), CancellationToken.None) as OkObjectResult;

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
            response.Value.ToString().Should().Be("{ ReferenceNumber = 1 }");
        }

        [Test]
        public async Task Register_GivenInvalidModel_ReturnsBadRequest()
        {
            _controller.ModelState.AddModelError("Firstname", "Firstname should not be null");
            var response = await _controller.Register(new CustomerModel(), CancellationToken.None) as BadRequestObjectResult;

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }
    }
}