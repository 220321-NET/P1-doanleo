namespace BL
{
    public class BusinessL : IBL
    {
        private readonly IRepo _repo;
        public BusinessL(IRepo repo)
        {
            _repo = repo;
        }
        public Customer addCustomer(Customer cust)
        {
            return _repo.addCustomer(cust);
        }

        public void addOrder(Storefront store, Customer cust, List<Product> cart)
        {
            _repo.addOrder(store, cust, cart);
        }

        public void addToCart(Storefront store, Product item, int howMany)
        {
            _repo.addToCart(store, item, howMany);
        }
        public async Task<List<Order>> GetStoreOrdersAsync(Storefront store, string sort, bool ascDesc)
        {
            return await _repo.GetStoreOrdersAsync(store, sort, ascDesc);
        }
        public async Task<List<Order>> GetCustOrdersAsync(Customer cust, string sort, bool ascDesc)
        {
            return await _repo.GetCustOrdersAsync(cust, sort, ascDesc);
        }

        public async Task<List<Product>> GetStockAsync(Storefront store)
        {
            return await _repo.GetStockAsync(store);
        }

        public async Task<List<Storefront>> GetStoresAsync()
        {
            return await _repo.GetStoresAsync();
        }

        public bool loginCheck(Customer cust)
        {
            return _repo.loginCheck(cust);
        }

        public void restock(Storefront store, Product item, int howMany)
        {
            _repo.restock(store, item, howMany);
        }

        public Customer getID(Customer cust)
        {
            return _repo.getID(cust);
        }
    }
}