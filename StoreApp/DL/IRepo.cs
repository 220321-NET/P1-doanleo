namespace DL
{
    /// <summary>
    /// Interface for accessing data in a repository within the Apple Store
    /// </summary>
    public interface IRepo
    {
        //Get From DB
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
        /// Get a list of the Orders
        /// </summary>
        /// <param name="isEmployee">True/False flag from Customer</param>
        /// <returns>List of orders</returns>
        List<Order> GetOrders(bool isEmployee);

        //Add to DB
        /// <summary>
        /// Adds an order by inputing the cart into orders
        /// </summary>
        /// <param name="cart">List of product purchased</param>
        public void addOrder(List<Product> cart);
        /// <summary>
        /// Add a customer to the database
        /// </summary>
        /// <param name="cust">Customer information</param>
        public int addCustomer(Customer cust);

        //Update DB
        /// <summary>
        /// Incriments to the stock of an item within a store
        /// </summary>
        /// <param name="store">Store to access inventory</param>
        /// <param name="item">Item to incriment</param>
        /// <param name="howMany">Number to incriment by</param>
        /// <returnReturns the customers IDk</returns>
        public void restock(Storefront store, Product item, int howMany);
        //Authenticate from DB
        /// <summary>
        /// Authenticates if a customer is in their database
        /// </summary>
        /// <param name="cust"> user to authenticate</param>
        /// <returns>true if successful, false if failed</returns>
        public bool loginCheck(Customer cust);
    }
}