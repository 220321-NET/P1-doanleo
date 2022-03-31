namespace BL
{
    public interface IBL
    {
        //Get From DB
        List<Storefront> GetStores();
        List<Product> GetStock(Storefront store);
        List<Order> GetOrders(bool isEmployee);

        //Add to DB
        public void addOrder(List<Product> cart);
        public void addCustomer(Customer cust);

        //Update DB
        public void restock(Storefront store, Product item, int howMany);
        //Authenticate from DB
        public bool loginCheck(Customer cust);
    }
}