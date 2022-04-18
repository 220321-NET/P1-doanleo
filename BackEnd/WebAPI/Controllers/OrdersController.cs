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

        [HttpGet("Store/{sID}/{sort}/{ascDesc}")]
        public async Task<List<Order>> GetStoreOrdersAsync(int sID, string sort, bool ascDesc)
        {
            return await _bl.GetStoreOrdersAsync(sID, sort, ascDesc);
        }
        [HttpGet("Customer/{cID}/{sort}/{ascDesc}")]
        public async Task<List<Order>> GetCustOrdersAsync(int cID, string sort, bool ascDesc)
        {
            return await _bl.GetCustOrdersAsync(cID, sort, ascDesc);
        }
        [HttpPost("{store}/{cust}")]
        public async Task addOrderAsync(int store, int cust, Dictionary<int, Product> dCart)
        {
            await _bl.addOrderAsync(store, cust, dCart);
        }
    }
}