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
        public List<Storefront> GetStores()
        {
            return _bl.GetStores();
        }
        [HttpGet]
        public List<Product> GetStock(Storefront store)
        {
            return _bl.GetStock(store);
        }
        [HttpGet("sort")]
        public List<Order> GetStoreOrders(Storefront store, string sort, bool ascDesc)
        {
            return _bl.GetStoreOrders(store, sort, ascDesc);
        }
        [HttpGet("sort")]
        public List<Order> GetCustOrders(Customer cust, string sort, bool ascDesc)
        {
            return _bl.GetCustOrders(cust, sort, ascDesc);
        }
        [HttpPost]
        public void addOrder(Storefront store, Customer cust, List<Product> cart)
        {
            _bl.addOrder(store, cust, cart);
        }
        [HttpPost]
        public Customer addCustomer(Customer cust)
        {
            return _bl.addCustomer(cust);
        }
        [HttpPost]
        public void restock(Storefront store, Product item, int howMany)
        {
            _bl.restock(store, item, howMany);
        }
        [HttpPost]
        public void addToCart(Storefront store, Product item, int howMany)
        {
            _bl.addToCart(store, item, howMany);
        }
    }




}