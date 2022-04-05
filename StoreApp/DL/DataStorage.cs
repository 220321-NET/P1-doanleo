using Microsoft.Data.SqlClient;
using System.Data;

namespace DL
{
    public class DataStorage : IRepo
    {
        private readonly string _connectionString;
        public DataStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Customer addCustomer(Customer cust)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("INSERT INTO Customers (username, password) VALUES (@user, @pass)", conn);
            cmd.Parameters.AddWithValue("@user", cust.username);
            cmd.Parameters.AddWithValue("@pass", cust.password);

            cmd.ExecuteNonQuery();

            conn.Close();
            return getID(cust);
        }

        public void addOrder(Storefront store, Customer cust, List<Product> cart)
        {
            int orderNum = 0;
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string pullString = "SELECT MAX(OrderNum) FROM Orders";
            using SqlCommand pull = new SqlCommand(pullString, conn);
            using SqlDataReader reader = pull.ExecuteReader();
            while (reader.Read())
            {
                orderNum = reader.GetInt32(0) + 1;
            }
            reader.Close();
            Dictionary<Product, int> d = new Dictionary<Product, int>();
            foreach (Product prod in cart)
            {
                if (d.ContainsKey(prod))
                {
                    d[prod] = d[prod] + 1;
                }
                else
                {
                    d.Add(prod, 1);
                }
            }
            
            foreach (var prod in d)
            {
                string insert = "INSERT INTO Orders (OrderNum, ProductID, NumberOrdered, CustomerID, StoreID, OrderTotal) VALUES (@on, @pid, @pord, @cid, @sid, @total)";
                using SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@pid", prod.Key.ProdID);
                cmd.Parameters.AddWithValue("@on", orderNum);
                cmd.Parameters.AddWithValue("@pord", prod.Value);
                cmd.Parameters.AddWithValue("@cid", cust.CustID);
                cmd.Parameters.AddWithValue("@sid", store.StoreID);
                double doub = (prod.Value * prod.Key.ProdCost);
                cmd.Parameters.AddWithValue("@total", Convert.ToDecimal(doub));
                cmd.ExecuteNonQuery();
            }
        }

        public List<Order> GetStoreOrders(Storefront store, string sort, bool ascDesc)
        {
            //select * from orders where store = store.storename sort by sort ascdesc
            List<Order> o = new List<Order>();
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = "SELECT OrderID, OrderNum, Stores.StoreName, Customers.username, Products.ProductName, NumberOrdered, OrderTotal FROM Orders JOIN Stores ON Orders.StoreID = Stores.StoreID JOIN Products on Orders.ProductID = Products.ProductID JOIN Customers  on Orders.CustomerID = Customers.CustID WHERE Orders.StoreID = @id ORDER BY ";

            string SORTBY = "ASC";
            if (ascDesc) { SORTBY = "DESC"; }
            sql = sql + sort + " " + SORTBY;
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", store.StoreID);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int oid = reader.GetInt32(0);
                int onum = reader.GetInt32(1);
                string os = reader.GetString(2);
                string oc = reader.GetString(3);
                string op = reader.GetString(4);
                int ordered = reader.GetInt32(5);
                double ot = decimal.ToDouble(reader.GetDecimal(6));

                Order ord = new Order();
                ord.OrderID = oid;
                ord.OrderNum = onum;
                ord.OrderAmount = ordered;
                ord.OrderTotalCost = ot;
                ord.OrderProduct = op;
                ord.OrderStore = os;
                ord.OrderCust = oc;

                o.Add(ord);
            }
            reader.Close();
            conn.Close();

            return o;
        }

        public List<Order> GetCustOrders(Customer cust, string sort, bool ascDesc)
        {
            //select * from orders where cust= cust name sort by sort ascdesc
            List<Order> o = new List<Order>();
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = "SELECT OrderID, OrderNum, Stores.StoreName, Customers.username, Products.ProductName, NumberOrdered, OrderTotal FROM Orders JOIN Stores ON Orders.StoreID = Stores.StoreID JOIN Products on Orders.ProductID = Products.ProductID JOIN Customers  on Orders.CustomerID = Customers.CustID WHERE Orders.CustomerID = @id ORDER BY ";
            string SORTBY = "ASC";
            if (ascDesc) { SORTBY = "DESC"; }
            sql = sql + sort + " " + SORTBY;
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", cust.CustID);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int oid = reader.GetInt32(0);
                int onum = reader.GetInt32(1);
                string os = reader.GetString(2);
                string oc = reader.GetString(3);
                string op = reader.GetString(4);
                int ordered = reader.GetInt32(5);
                double ot = decimal.ToDouble(reader.GetDecimal(6));

                Order ord = new Order();
                ord.OrderID = oid;
                ord.OrderNum = onum;
                ord.OrderAmount = ordered;
                ord.OrderTotalCost = ot;
                ord.OrderProduct = op;
                ord.OrderStore = os;
                ord.OrderCust = oc;

                o.Add(ord);
            }
            reader.Close();
            conn.Close();

            return o;
        }

        public List<Product> GetStock(Storefront store)
        {
            List<Product> stock = new List<Product>();
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT StoreID, Products.ProductID, Products.ProductName, Products.ProductCost, Stock FROM StoreStock JOIN Products ON Storestock.ProductID =Products.ProductID WHERE StoreID = @sID", conn);
            cmd.Parameters.AddWithValue("@sID", store.StoreID);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(1);
                string name = reader.GetString(2);
                decimal cost = reader.GetDecimal(3);
                int iStock = reader.GetInt32(4);

                Product item = new Product();
                item.ProdID = id;
                item.ProdName = name;
                item.ProdCost = decimal.ToDouble(cost);
                item.ProdStock = iStock;

                stock.Add(item);
            }
            reader.Close();
            conn.Close();
            return stock;
        }

        public List<Storefront> GetStores()
        {
            List<Storefront> stores = new List<Storefront>();
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM Stores", conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);

                Storefront store = new Storefront();
                store.StoreID = id;
                store.StoreName = name;

                stores.Add(store);
            }
            reader.Close();
            conn.Close();
            return stores;
        }

        public bool loginCheck(Customer cust)
        {
            bool found = false;
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE username = @user AND password = @pass", conn);
            cmd.Parameters.AddWithValue("@user", cust.username);
            cmd.Parameters.AddWithValue("@pass", cust.password);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                found = true;
            }
            reader.Close();
            conn.Close();
            return found;
        }

        public Customer getID(Customer cust)
        {
            int id = -1;

            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE username = @user AND password = @pass", conn);
            cmd.Parameters.AddWithValue("@user", cust.username);
            cmd.Parameters.AddWithValue("@pass", cust.password);
            Customer t = new Customer();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetInt32(0);
                string u = reader.GetString(1);
                string p = reader.GetString(2);
                bool isE = reader.GetBoolean(3);

                t.CustID = id;
                t.username= u;
                t.password = p;
                t.isEmployee = isE;
            }
            reader.Close();
            conn.Close();
            return t;
        }

        public void restock(Storefront store, Product item, int howMany)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT Stock FROM StoreStock WHERE StoreID = @sID AND ProductID = @pID", conn);
            cmd.Parameters.AddWithValue("@sID", store.StoreID);
            cmd.Parameters.AddWithValue("@pID", item.ProdID);
            int stock = 0;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                stock = reader.GetInt32(0);
            }
            reader.Close();
            stock = stock + howMany;
            SqlCommand upd = new SqlCommand("UPDATE StoreStock SET Stock = @stock WHERE StoreID = @sID AND ProductID = @pID", conn);
            upd.Parameters.AddWithValue("@stock", stock);
            upd.Parameters.AddWithValue("@sID", store.StoreID);
            upd.Parameters.AddWithValue("@pID", item.ProdID);
            upd.ExecuteNonQuery();
            conn.Close();
        }
        public void addToCart(Storefront store, Product item, int howMany)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT Stock FROM StoreStock WHERE StoreID = @sID AND ProductID = @pID", conn);
            cmd.Parameters.AddWithValue("@sID", store.StoreID);
            cmd.Parameters.AddWithValue("@pID", item.ProdID);
            int stock = 0;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                stock = reader.GetInt32(0);
            }
            reader.Close();
            stock = stock - howMany;
            SqlCommand upd = new SqlCommand("UPDATE StoreStock SET Stock = @stock WHERE StoreID = @sID AND ProductID = @pID", conn);
            upd.Parameters.AddWithValue("@stock", stock);
            upd.Parameters.AddWithValue("@sID", store.StoreID);
            upd.Parameters.AddWithValue("@pID", item.ProdID);
            upd.ExecuteNonQuery();
            conn.Close();
        }
    }
}