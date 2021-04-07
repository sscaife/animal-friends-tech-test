using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AnimalFriends.Core.Presentation;

namespace AnimalFriends.Core
{
    public interface ICustomerService
    {
        Task<int> SaveModelAsync(CustomerModel model, CancellationToken cancellationToken = default);
    }
}
