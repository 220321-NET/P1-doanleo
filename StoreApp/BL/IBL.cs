namespace BL
{
    public interface IBL
    {
        //Get From DB
        List<Storefront> GetStores();
        List<Product> GetStock(Storefront store);
        List<Order> GetStoreOrders(Storefront store, string sort, bool ascDesc);
        List<Order> GetCustOrders(Customer cust, string sort, bool ascDesc);
        //Add to DB
        public void addOrder(Storefront store, Customer cust, List<Product> cart);
        public int addCustomer(Customer cust);

        //Update DB
        public void restock(Storefront store, Product item, int howMany);
        public void addToCart(Storefront store, Product item, int howMany);
        //Authenticate from DB
        public bool loginCheck(Customer cust);
    }
}