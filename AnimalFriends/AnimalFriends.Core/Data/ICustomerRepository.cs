using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnimalFriends.Core.Data
{
    public interface ICustomerRepository
    {
        Task<int> SaveCustomerAsync(CustomerDto customer, CancellationToken cancellationToken = default);
    }
}
