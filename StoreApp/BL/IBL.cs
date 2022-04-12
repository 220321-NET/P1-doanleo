namespace BL
{
    public interface IBL
    {
        //Get From DB
        Task<List<Storefront>> GetStoresAsync();
        Task<List<Product>> GetStockAsync(int sID);
        Task<List<Order>> GetStoreOrdersAsync(int sID, string sort, bool ascDesc);
        Task<List<Order>> GetCustOrdersAsync(int cID, string sort, bool ascDesc);
        //Add to DB
        public Customer addCustomer(string user, string pass);
        public Customer getCustomer(Customer cust);
        public bool authenticate(string user, string pass);
        public bool existingUser(string user);
        public void addOrder(int sID, int cID, Cart cart);
        public void restock(int sID, int pID, int howMany);
        public void addToCart(int sID, int pID, int howMany);
    }
}