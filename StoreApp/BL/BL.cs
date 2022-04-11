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
        public bool existingUser(string user){
            return _repo.existingUser(user);
        }
        public void addOrder(int sID, int cID, List<Product> cart)
        {
            _repo.addOrder(sID, cID, cart);
        }
        public void restock(int sID, int pID, int howMany)
        {
            _repo.restock(sID, pID, howMany);
        }
        public void addToCart(int sID, int pID, int howMany)
        {
            _repo.addToCart(sID, pID, howMany);
        }
    }
}