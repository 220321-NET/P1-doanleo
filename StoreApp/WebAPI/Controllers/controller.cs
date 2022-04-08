using Microsoft.AspNetCore.Mvc;
using BL;
using Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IBL _bl;
        public StoreController(IBL bl)
        {
            _bl = bl;
        }
        //Get Commands
        [HttpGet]
        public List<Product> GetStock(Storefront store)
        {
            return _bl.GetStock(store);
        }
    }




}