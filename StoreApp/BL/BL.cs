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
        public async Task<Customer> addCustomerAsync(string user, string pass)
        {
            return await _repo.addCustomerAsync(user, pass);
        }

        public async Task<Customer> getCustomerAsync(Customer cust)
        {
            return await _repo.getCustomerAsync(cust);
        }
        public async Task<bool> authenticateAsync(string user, string pass)
        {
            return await _repo.authenticateAsync(user, pass);
        }
        public async Task<bool> existingUserAsync(string user)
        {
            return await _repo.existingUserAsync(user);
        }
        public async Task<List<string>> returnPassAsync(string user){
            return await _repo.returnPassAsync(user);
        }
        public void addOrderAsync(int sID, int cID, Cart cart)
        {
            _repo.addOrderAsync(sID, cID, cart);
        }
        public void restockAsync(int sID, int pID, int howMany)
        {
            _repo.restockAsync(sID, pID, howMany);
        }
        public void addToCartAsync(int sID, int pID, int howMany)
        {
            _repo.addToCartAsync(sID, pID, howMany);
        }
    }
}