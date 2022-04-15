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
        public List<string> returnPass(string user);
        public Task addOrderAsync(int sID, int cID, Dictionary<int, Product> dCart);
        public Task restockAsync(int sID, int pID, int howMany);
        public Task addToCartAsync(int sID, int pID, int howMany);
    }
}