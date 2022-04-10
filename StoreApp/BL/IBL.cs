namespace BL
{
    public interface IBL
    {
        //Get From DB
        Task<List<Storefront>> GetStoresAsync();
        Task<List<Product>> GetStockAsync(Storefront store);
        Task<List<Order>> GetStoreOrdersAsync(Storefront store, string sort, bool ascDesc);
        Task<List<Order>> GetCustOrdersAsync(Customer cust, string sort, bool ascDesc);
        //Add to DB
        public void addOrder(Storefront store, Customer cust, List<Product> cart);
        public Customer addCustomer(Customer cust);

        //Update DB
        public void restock(Storefront store, Product item, int howMany);
        public void addToCart(Storefront store, Product item, int howMany);
        //Authenticate from DB
        public bool loginCheck(Customer cust);
        public Customer getID(Customer cust);
    }
}