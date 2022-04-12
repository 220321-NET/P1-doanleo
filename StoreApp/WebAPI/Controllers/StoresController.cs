using Microsoft.AspNetCore.Mvc;
using BL;
using Models;
using Microsoft.Extensions.Caching.Memory;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IBL _bl;
        private IMemoryCache _cache;
        public StoresController(IBL bl, IMemoryCache cache)
        {
            _bl = bl;
            _cache = cache;
        }
        //Get api/Stores/
        [HttpGet]
        public async Task<List<Storefront>> GetStoresAsync()
        {
            return await _bl.GetStoresAsync();
        }
        //get api/Stores/Stock/0
        [HttpGet("Stock/{id}")]
        public async Task<List<Product>> GetStockAsync(int store)
        {
            return await _bl.GetStockAsync(store);
        }
        [HttpGet("Orders/Store/{store}{sort}")]
        public async Task<List<Order>> GetStoreOrdersAsync(int store, string sort, bool ascDesc)
        {
            return await _bl.GetStoreOrdersAsync(store, sort, ascDesc);
        }
        [HttpGet("Orders/Customer/{store}{sort}")]
        public async Task<List<Order>> GetCustOrdersAsync(int cust, string sort, bool ascDesc)
        {
            return await _bl.GetCustOrdersAsync(cust, sort, ascDesc);
        }
        
        [HttpPost]
        public Customer addCustomer(string user, string pass)
        {
            return _bl.addCustomer(user, pass);
            
        }
        public Customer getCustomer(Customer cust){
            return _bl.getCustomer(cust);
        }
        [HttpPost]
        public bool authenticate(string user, string pass)
        {
            return _bl.authenticate(user, pass);
        }
        public bool existingUser(string user){
            return _bl.existingUser(user);
        }
        [HttpPost]
        public void addOrder(int store, int cust, Cart cart)
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