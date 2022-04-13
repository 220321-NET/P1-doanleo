using Microsoft.AspNetCore.Mvc;
using BL;
using Models;
using Microsoft.Extensions.Caching.Memory;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IBL _bl;
        private IMemoryCache _cache;
        public OrdersController(IBL bl, IMemoryCache cache)
        {
            _bl = bl;
            _cache = cache;
        }
        [HttpGet("Store/{store}{sort}")]
        public async Task<List<Order>> GetStoreOrdersAsync(int store, string sort, bool ascDesc)
        {
            return await _bl.GetStoreOrdersAsync(store, sort, ascDesc);
        }
        [HttpGet("Customer/{store}{sort}")]
        public async Task<List<Order>> GetCustOrdersAsync(int cust, string sort, bool ascDesc)
        {
            return await _bl.GetCustOrdersAsync(cust, sort, ascDesc);
        }
        [HttpPost]
        public void addOrderAsync(int store, int cust, Cart cart)
        {
            _bl.addOrderAsync(store, cust, cart);
        }
    }
}