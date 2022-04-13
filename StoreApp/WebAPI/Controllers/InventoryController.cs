using Microsoft.AspNetCore.Mvc;
using BL;
using Models;
using Microsoft.Extensions.Caching.Memory;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IBL _bl;
        private IMemoryCache _cache;
        public InventoryController(IBL bl, IMemoryCache cache)
        {
            _bl = bl;
            _cache = cache;
        }
        //get api/Stores/Stock/0
        [HttpGet("Stock/{id}")]
        public async Task<List<Product>> GetStockAsync(int store)
        {
            return await _bl.GetStockAsync(store);
        }
        [HttpPut("restock")]
        public void restock(int store, int item, int howMany)
        {
            _bl.restockAsync(store, item, howMany);
        }
        [HttpPut("addToCart")]
        public void addToCart(int store, int item, int howMany)
        {
            _bl.addToCartAsync(store, item, howMany);
        }
    }
}
