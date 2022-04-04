namespace BL
{
    public class BusinessL : IBL
    {
        private readonly IRepo _repo;
        public BusinessL(IRepo repo)
        {
            _repo = repo;
        }
        public int addCustomer(Customer cust)
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
        public List<Order> GetStoreOrders(Storefront store, string sort, bool ascDesc)
        {
            return _repo.GetStoreOrders(store, sort, ascDesc);
        }
        public List<Order> GetCustOrders(Customer cust, string sort, bool ascDesc)
        {
            return _repo.GetCustOrders(cust, sort, ascDesc);
        }

        public List<Product> GetStock(Storefront store)
        {
            return _repo.GetStock(store);
        }

        public List<Storefront> GetStores()
        {
            return _repo.GetStores();
        }

        public bool loginCheck(Customer cust)
        {
            return _repo.loginCheck(cust);
        }

        public void restock(Storefront store, Product item, int howMany)
        {
            _repo.restock(store, item, howMany);
        }

        public int getID(Customer cust)
        {
            return _repo.getID(cust);
        }
    }
}