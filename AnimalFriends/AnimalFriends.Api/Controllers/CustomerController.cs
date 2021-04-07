using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AnimalFriends.Core;
using AnimalFriends.Core.Presentation;

namespace AnimalFriends.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpPost]
        public async Task<IActionResult> Register(CustomerModel customer, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var referenceNumber =
                await _customerService.SaveModelAsync(customer, cancellationToken).ConfigureAwait(false);

            return Ok(new{ ReferenceNumber = referenceNumber });
        }
    }
}
