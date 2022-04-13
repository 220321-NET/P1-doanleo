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
    }
}