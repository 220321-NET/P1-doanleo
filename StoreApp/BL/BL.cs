namespace BL
{
    public class BusinessL : IBL
    {
        private readonly IRepo _repo;
        public BusinessL(IRepo repo){
            _repo = repo;
        }
        public void addCustomer(Customer cust)
        {
            _repo.addCustomer(cust);
        }

        public void addOrder(List<Product> cart)
        {
            _repo.addOrder(cart);
        }

        public List<Order> GetOrders(bool isEmployee)
        {
            return _repo.GetOrders(isEmployee);
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
            return loginCheck(cust);
        }

        public void restock(Storefront store, Product item, int howMany)
        {
            _repo.restock(store, item, howMany);
        }
    }
}