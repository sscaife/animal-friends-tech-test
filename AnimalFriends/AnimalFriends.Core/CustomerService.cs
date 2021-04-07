using System.Threading;
using System.Threading.Tasks;
using AnimalFriends.Core.Data;
using AnimalFriends.Core.Presentation;
using AutoMapper;

namespace AnimalFriends.Core
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<int> SaveModelAsync(CustomerModel model, CancellationToken cancellationToken = default)
        {
            var dto = _mapper.Map<CustomerDto>(model);

            var referenceNumber = await _repository.SaveCustomerAsync(dto, cancellationToken).ConfigureAwait(false);

            return referenceNumber;
        }
    }
}