namespace DL
{
    /// <summary>
    /// Interface for accessing data in a repository within the Apple Store
    /// </summary>
    public interface IRepo
    {
        /// <summary>
        /// Gets a list of all the stores
        /// </summary>
        /// <returns>A list of StoreFronts</returns>
        Task<List<Storefront>> GetStoresAsync();

        /// <summary>
        /// Gets a list of the stock within a store
        /// </summary>
        /// <param name="sID">the ID of the store you want</param>
        /// <returns>A List of the store stock</returns>
        Task<List<Product>> GetStockAsync(int sID);

        /// <summary>
        /// Gets a list of Orders given the store
        /// </summary>
        /// <param name="sID">the ID of the store you want</param>
        /// <param name="sort">Order by string</param>
        /// <param name="ascDesc">Sort by Ascending or Descending</param>
        /// <returns>List of orders from a given store</returns>
        Task<List<Order>> GetStoreOrdersAsync(int sID, string sort, bool ascDesc);

        /// <summary>
        /// Gets the list of orders by a customer
        /// </summary>
        /// <param name="cID">Customer's ID</param>
        /// <param name="sort">Order by string</param>
        /// <param name="ascDesc">Sort by Ascending or Descending</param>
        /// <returns>List of orders tied to a customer</returns>
        Task<List<Order>> GetCustOrdersAsync(int cID, string sort, bool ascDesc);

        /// <summary>
        /// used after authenticating. returns an entire customer class
        /// </summary>
        /// <param name="user">username</param>
        /// <param name="pass">password</param>
        /// <returns>Customer Customer class with ID</returns>
        public Task<Customer> addCustomerAsync(string user, string pass);
        
        /// <summary>
        /// Add a customer to the database, and returns their ID
        /// </summary>
        /// <param name="cust">Customer information</param>
        public Task<Customer> getCustomerAsync(Customer cust);

        //Authenticate from DB
        /// <summary>
        /// checks if username and password match
        /// </summary>
        /// <param name="user">uses the authenticate to see if user exists</param>
        /// <param name="pass">password</param>
        /// <returns>true if successful, false if failed</returns>
        public Task<bool> authenticateAsync(string user, string pass);
        /// <summary>
        /// checks if username is already used in the database, used for creation
        /// </summary>
        /// <param name="user">username used</param>
        /// <returns>true if already exists, false otherwise</returns>
        public Task<bool> existingUserAsync(string user);
        /// <summary>
        /// Returns the users password so the UI layer can authenticate
        /// </summary>
        /// <param name="user">user to check</param>
        /// <returns>password string</returns>
        public Task<List<string>> returnPassAsync(string user);
        /// <summary>
        /// Adds an order by inputing the cart into orders
        /// </summary>
        /// <param name="sID">Store bought from</param>
        /// <param name="cID">Customer who bought</param>
        /// <param name="cart">List of product purchased</param>
        public void addOrderAsync(int sID, int cID, Cart cart);

        /// <summary>
        /// Incriments to the stock of an item within a store
        /// </summary>
        /// <param name="sID">Store to access inventory</param>
        /// <param name="pID">Item to incriment</param>
        /// <param name="howMany">Number to incriment by</param>
        public void restockAsync(int sID, int pID, int howMany);

        /// <summary>
        /// Decrement to the stock of an item within a store
        /// </summary>
        /// <param name="sID">Store to access inventory</param>
        /// <param name="pID">Item to decrement</param>
        /// <param name="howMany">Number to decrement by</param>
        public void addToCartAsync(int sID, int pID, int howMany);





    }
}