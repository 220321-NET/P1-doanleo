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
        List<Storefront> GetStores();

        /// <summary>
        /// Gets a list of the stock within a store
        /// </summary>
        /// <param name="store">The StoreFront Object you wish to access the inventory of</param>
        /// <returns>A List of the store stock</returns>
        List<Product> GetStock(Storefront store);

        /// <summary>
        /// Gets a list of Orders given the store
        /// </summary>
        /// <param name="store">The store you want to look at</param>
        /// <param name="sort">Order by string</param>
        /// <param name="ascDesc">Sort by Ascending or Descending</param>
        /// <returns>List of orders from a given store</returns>
        List<Order> GetStoreOrders(Storefront store, string sort, bool ascDesc);

        /// <summary>
        /// Gets the list of orders by a customer
        /// </summary>
        /// <param name="cust">Customer</param>
        /// <param name="sort">Order by string</param>
        /// <param name="ascDesc">Sort by Ascending or Descending</param>
        /// <returns>List of orders tied to a customer</returns>
        List<Order> GetCustOrders(Customer cust, string sort, bool ascDesc);

        /// <summary>
        /// Adds an order by inputing the cart into orders
        /// </summary>
        /// <param name="store">Store bought from</param>
        /// <param name="cust">Customer who bought</param>
        /// <param name="cart">List of product purchased</param>
        public void addOrder(Storefront store, Customer cust, List<Product> cart);

        /// <summary>
        /// Add a customer to the database, and returns their ID
        /// </summary>
        /// <param name="cust">Customer information</param>
        public int addCustomer(Customer cust);

        /// <summary>
        /// Incriments to the stock of an item within a store
        /// </summary>
        /// <param name="store">Store to access inventory</param>
        /// <param name="item">Item to incriment</param>
        /// <param name="howMany">Number to incriment by</param>
        public void restock(Storefront store, Product item, int howMany);

        /// <summary>
        /// Decrement to the stock of an item within a store
        /// </summary>
        /// <param name="store">Store to access inventory</param>
        /// <param name="item">Item to decrement</param>
        /// <param name="howMany">Number to decrement by</param>
        public void addToCart(Storefront store, Product item, int howMany);

        //Authenticate from DB
        /// <summary>
        /// Authenticates if a customer is in their database
        /// </summary>
        /// <param name="cust"> user to authenticate</param>
        /// <returns>true if successful, false if failed</returns>
        public bool loginCheck(Customer cust);
                
        /// <summary>
        /// Used after loginCheck, returns id
        /// </summary>
        /// <param name="cust">Customer Info</param>
        /// <returns>Customer's ID</returns>
        public int getID(Customer cust);

    }
}