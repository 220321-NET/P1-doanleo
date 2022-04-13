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
        public Task<Customer> addCustomerAsync(string user, string pass);
        public Task<Customer> getCustomerAsync(Customer cust);
        public Task<bool> authenticateAsync(string user, string pass);
        public Task<bool> existingUserAsync(string user);
        public Task<List<string>> returnPassAsync(string user);
        public void addOrderAsync(int sID, int cID, Cart cart);
        public void restockAsync(int sID, int pID, int howMany);
        public void addToCartAsync(int sID, int pID, int howMany);
    }
}