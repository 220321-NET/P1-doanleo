using Microsoft.AspNetCore.Mvc;
using BL;
using Models;
using Microsoft.Extensions.Caching.Memory;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IBL _bl;
        private IMemoryCache _cache;
        public StoreController(IBL bl, IMemoryCache cache)
        {
            _bl = bl;
            _cache = cache;
        }
        //Get Commands
        [HttpGet]
        public async Task<List<Storefront>> GetStoresAsync()
        {
            return await _bl.GetStoresAsync();
        }
        [HttpGet]
        public async Task<List<Product>> GetStockAsync(int store)
        {
            return await _bl.GetStockAsync(store);
        }
        [HttpGet("sort")]
        public async Task<List<Order>> GetStoreOrdersAsync(int store, string sort, bool ascDesc)
        {
            return await _bl.GetStoreOrdersAsync(store, sort, ascDesc);
        }
        [HttpGet("sort")]
        public async Task<List<Order>> GetCustOrdersAsync(int cust, string sort, bool ascDesc)
        {
            return await _bl.GetCustOrdersAsync(cust, sort, ascDesc);
        }
        
        [HttpPost]
        public Customer addCustomer(string user, string pass)
        {
            return _bl.addCustomer(user, pass);
        }
        [HttpPost]
        public bool authenticate(string user, string pass)
        {
            return _bl.authenticate(user, pass);
        }
        [HttpPost]
        public void addOrder(int store, int cust, List<Product> cart)
        {
            _bl.addOrder(store, cust, cart);
        }
        [HttpPut]
        public void restock(int store, int item, int howMany)
        {
            _bl.restock(store, item, howMany);
        }
        [HttpPut]
        public void addToCart(int store, int item, int howMany)
        {
            _bl.addToCart(store, item, howMany);
        }
    }




}