using Microsoft.Data.SqlClient;

namespace DL
{
    public class DataStorage : IRepo
    {
        private readonly string _connectionString;
        public DataStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int addCustomer(Customer cust)
        {
            //insert into customers (username, password) values cust.username, cust.password
            //select custid from customers where username = username and password = password
            return 0;
        }

        public void addOrder(Storefront store, Customer cust, List<Product> cart)
        {
            int orderNum = 0;
            //select max(ordernum) from order and set to ordernum
            //insert into order make a loop for every cart item
        }

        public List<Order> GetStoreOrders(Storefront store, string sort, bool ascDesc)
        {
            //select * from orders where store = store.storename sort by sort ascdesc
            return new List<Order>();
        }

        public List<Order> GetCustOrders(Customer cust, string sort, bool ascDesc)
        {
            //select * from orders where cust= cust name sort by sort ascdesc
            return new List<Order>();
        }

        public List<Product> GetStock(Storefront store)
        {
            List<Product> stock = new List<Product>();
            /*
            Select Stores.StoreName, Products.ProductName, Products.ProductCost, Stock from StoreStock
            join Stores on Storestock.Storeid = stores.StoreID
            join Products on storestock.ProductID = products.productid
            Where StoreName = 'The Apple Store'
            */
            return stock;
        }

        public List<Storefront> GetStores()
        {
            //select * from stores;
            return new List<Storefront>();
        }

        public bool loginCheck(Customer cust)
        {
            //only checks if username and password match then returns yes or not
            return true;
        }

        public void restock(Storefront store, Product item, int howMany)
        {
            //select stock and store it to a number
            //update stock from storestock where
        }
        public void addToCart(Storefront store, Product item, int howMany)
        {
            //same
        }

        public void sample()
        {
            //this is my sample to use for later

            //Add connection
            SqlConnection conn = new SqlConnection(_connectionString);
            //Open Connection
            conn.Open();
            //query
            string command = "SELECT * FROM thing";
            SqlCommand cmd = new SqlCommand(command, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows) // iterates through each row
            //keeps reading while theres rows or results
            {
                int id = reader.GetInt32(0);
                //type name = reader.Gettype(column number);
            }

            cmd = new SqlCommand("INSERT INTO database (Pameter, Parameter, Paramentr) VALUES (@param, @param, @param)", conn);
            SqlParameter typeParam = new SqlParameter("@param", DateTime.Now);
            cmd.Parameters.Add(typeParam);
            cmd.Parameters.AddWithValue("@param", DateTime.Now);
            cmd.ExecuteNonQuery();
            //next
            reader.Close(); //kills reader object
            conn.Close(); //closes connection to db to prevent mem leak
        }
        public void dcSample()
        {


        }


    }
}