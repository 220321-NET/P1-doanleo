namespace BL
{
    public class BusinessL : IBL
    {
        private readonly IRepo _repo;
        public BusinessL(IRepo repo)
        {
            _repo = repo;
        }
        public async Task<List<Storefront>> GetStoresAsync()
        {
            return await _repo.GetStoresAsync();
        }
        public async Task<List<Product>> GetStockAsync(int sID)
        {
            return await _repo.GetStockAsync(sID);
        }
        public async Task<List<Order>> GetStoreOrdersAsync(int sID, string sort, bool ascDesc)
        {
            return await _repo.GetStoreOrdersAsync(sID, sort, ascDesc);
        }
        public async Task<List<Order>> GetCustOrdersAsync(int cID, string sort, bool ascDesc)
        {
            return await _repo.GetCustOrdersAsync(cID, sort, ascDesc);
        }
        public Customer addCustomer(string user, string pass)
        {
            return _repo.addCustomer(user, pass);
        }

        public Customer getCustomer(Customer cust)
        {
            return _repo.getCustomer(cust);
        }
        public bool authenticate(string user, string pass)
        {
            return _repo.authenticate(user, pass);
        }
        public bool existingUser(string user)
        {
            return _repo.existingUser(user);
        }
        public List<string> returnPass(string user)
        {
            return _repo.returnPass(user);
        }
        public async Task addOrderAsync(int sID, int cID, Dictionary<int, Product> dCart )
        {
            await _repo.addOrderAsync(sID, cID, dCart);
        }
        public async Task restockAsync(int sID, int pID, int howMany)
        {
            await _repo.restockAsync(sID, pID, howMany);
        }
        public async Task addToCartAsync(int sID, int pID, int howMany)
        {
            await _repo.addToCartAsync(sID, pID, howMany);
        }
    }
}