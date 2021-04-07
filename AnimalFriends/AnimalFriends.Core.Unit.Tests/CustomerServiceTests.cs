using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AnimalFriends.Core.Data;
using AnimalFriends.Core.Presentation;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace AnimalFriends.Core.Unit.Tests
{
    public class CustomerServiceTests
    {
        private Mock<ICustomerRepository> _repository;
        private ICustomerService _service;
        private Mock<IMapper> _mapper;

        [SetUp]
        public async Task Setup()
        {
            _repository = new Mock<ICustomerRepository>();
            _mapper = new Mock<IMapper>();

            _service = new CustomerService(_repository.Object, _mapper.Object);
        }

        [Test]
        public async Task SaveModel_GivenModel_MapsToDto()
        {
            await _service.SaveModelAsync(new CustomerModel());

            _mapper.Verify(o => o.Map<CustomerDto>(It.IsAny<CustomerModel>()), Times.Once);
        }

        [Test]
        public async Task SaveModel_GivenModel_PersistsToStorage()
        {
            await _service.SaveModelAsync(new CustomerModel());

            _repository.Verify(o => o.SaveCustomerAsync(It.IsAny<CustomerDto>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task SaveModel_WhenModelIsPersisted_ReturnsCustomerReferenceNumber()
        {
            _repository.Setup(o => o.SaveCustomerAsync(It.IsAny<CustomerDto>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var actual = await _service.SaveModelAsync(new CustomerModel());

            actual.Should().Be(1);
        }
    }
}
