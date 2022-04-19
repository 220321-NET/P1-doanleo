using Microsoft.AspNetCore.Mvc;
using BL;
using Models;
using Microsoft.Extensions.Caching.Memory;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBL _bl;
        public UserController(IBL bl)
        {
            _bl = bl;
        }
        [HttpPost]
        public Customer GetCustomer(Customer cust)
        {
            if (_bl.authenticate(cust.username, cust.password))
            {
                cust = _bl.getCustomer(cust);
                
                return cust;
            }
            return new Customer();
        }
        [HttpPut]
        public Customer addCustomer(Customer cust)
        {
            if (_bl.existingUser(cust.username))
            {
                return new Customer();
            }
            return _bl.addCustomer(cust.username, cust.password);
        }
    }
}