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
        public async Task<List<Product>> GetStockAsync(Storefront store)
        {
            return await _bl.GetStockAsync(store);
        }
        [HttpGet("sort")]
        public async Task<List<Order>> GetStoreOrdersAsync(Storefront store, string sort, bool ascDesc)
        {
            return await _bl.GetStoreOrdersAsync(store, sort, ascDesc);
        }
        [HttpGet("sort")]
        public async Task<List<Order>> GetCustOrdersAsync(Customer cust, string sort, bool ascDesc)
        {
            return await _bl.GetCustOrdersAsync(cust, sort, ascDesc);
        }
        
        [HttpPost]
        public Customer addCustomer(Customer cust)
        {
            return _bl.addCustomer(cust);
        }
        [HttpPost]
        public bool loginCheck(Customer cust)
        {
            return _bl.loginCheck(cust);
        }
        [HttpPost]
        public void addOrder(Storefront store, Customer cust, List<Product> cart)
        {
            _bl.addOrder(store, cust, cart);
        }
        [HttpPut]
        public void restock(Storefront store, Product item, int howMany)
        {
            _bl.restock(store, item, howMany);
        }
        [HttpPut]
        public void addToCart(Storefront store, Product item, int howMany)
        {
            _bl.addToCart(store, item, howMany);
        }
    }




}