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
        public InventoryController(IBL bl)
        {
            _bl = bl;
        }
        public class Stock
        {
            //used for restock and add to cart functions
            public int sID { get; set; }
            public int pID { get; set; }
            public int howMany { get; set; }
        }
        //get api/Inventory/0
        [HttpGet("{id}")]
        public async Task<List<Product>> GetStockAsync(int id)
        {
            return await _bl.GetStockAsync(id);
        }
        [HttpPut("restock")]
        public async Task restock(Stock stock)
        {
            Console.WriteLine(stock.sID + ""+ stock.pID + ""+  stock.howMany);
            await _bl.restockAsync(stock.sID, stock.pID, stock.howMany);
        }
        [HttpPut("addToCart")]
        public async Task addToCart(Stock stock)
        {
            await _bl.addToCartAsync(stock.sID, stock.pID, stock.howMany);
        }
    }
}
