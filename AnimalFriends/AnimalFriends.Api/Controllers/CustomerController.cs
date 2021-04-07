using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AnimalFriends.Core.Presentation;

namespace AnimalFriends.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> Register(CustomerModel customer, CancellationToken cancellationToken = default)
        {

        }
    }
}
