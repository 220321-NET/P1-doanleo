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
        private IMemoryCache _cache;

        public UserController(IBL bl, IMemoryCache cache)
        {
            _bl = bl;
            _cache = cache;
        }
        //login
        [HttpGet("Login")]
        public async Task<Customer> GetCustomerAsync(string user, string pass)
        {
            Customer cust = new Customer();
            cust.username = user;
            cust.password = pass;
            cust = await _bl.getCustomerAsync(cust);
            return cust;
        }
        [HttpGet("Authenticate")]
        // used to autenticate in the UI, is the authenticate method from before
        public async Task<List<string>> returnPassAsync(string user)
        {
            return await _bl.returnPassAsync(user);
        }
        [HttpGet("Sign Up")]
        public async Task<bool> existingUser(string user)
        {
            return await _bl.existingUserAsync(user);
        }
        [HttpPost]
        public async Task<Customer> addCustomer(string user, string pass)
        {
            return await _bl.addCustomerAsync(user, pass);
        }
    }
}