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

        public async Task<List<Storefront>> GetStoresAsync()
        {
            List<Storefront> stores = new List<Storefront>();
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM Stores", conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
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
        public async Task<List<Product>> GetStockAsync(int sID)
        {
            List<Product> stock = new List<Product>();
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT StoreID, Products.ProductID, Products.ProductName, Products.ProductCost, Stock FROM StoreStock JOIN Products ON Storestock.ProductID =Products.ProductID WHERE StoreID = @sID", conn);
            cmd.Parameters.AddWithValue("@sID", sID);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
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
        public async Task<List<Order>> GetStoreOrdersAsync(int sID, string sort, bool ascDesc)
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
            cmd.Parameters.AddWithValue("@id", sID);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
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

        public async Task<List<Order>> GetCustOrdersAsync(int cID, string sort, bool ascDesc)
        {
            //select * from orders where cust= cust name sort by sort ascdesc
            List<Order> o = new List<Order>();
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = "SELECT OrderID, OrderNum, Stores.StoreName, Customers.username, Products.ProductName, NumberOrdered, OrderTotal FROM Orders JOIN Stores ON Orders.StoreID = Stores.StoreID JOIN Products on Orders.ProductID = Products.ProductID JOIN Customers on Orders.CustomerID = Customers.CustID WHERE Orders.CustomerID = @id ORDER BY ";
            string SORTBY = "ASC";
            if (ascDesc) { SORTBY = "DESC"; }
            sql = sql + sort + " " + SORTBY;
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", cID);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
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
        public async Task<Customer> addCustomerAsync(string user, string pass)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("INSERT INTO Customers (username, password) VALUES (@user, @pass)", conn);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            Customer cust = new Customer();
            cust.username = user;
            cust.password = pass;
            await cmd.ExecuteNonQueryAsync();

            conn.Close();
            return await getCustomerAsync(cust);
        }
        public async Task<Customer> getCustomerAsync(Customer cust)
        {
            int id = -1;

            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE username = @user AND password = @pass", conn);
            cmd.Parameters.AddWithValue("@user", cust.username);
            cmd.Parameters.AddWithValue("@pass", cust.password);
            Customer t = new Customer();
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                id = reader.GetInt32(0);
                string u = reader.GetString(1);
                string p = reader.GetString(2);
                bool isE = reader.GetBoolean(3);

                t.CustID = id;
                t.username = u;
                t.password = p;
                t.isEmployee = isE;
            }
            reader.Close();
            conn.Close();
            return t;
        }
        public async Task<bool> authenticateAsync(string user, string pass)
        {
            bool match = false;
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE username = @user AND password = @pass", conn);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                match = true;
            }
            reader.Close();
            conn.Close();
            return match;
        }
        public async Task<bool> existingUserAsync(string user)
        {
            bool match = false;
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE username = @user", conn);
            cmd.Parameters.AddWithValue("@user", user);

            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                match = true;
            }
            reader.Close();
            conn.Close();
            return match;
        }
        public async Task<List<string>> returnPassAsync(string user)
        {
            List<string> cust = new List<string>();
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE username = @user", conn);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                cust.Add(reader.GetString(1));
                cust.Add(reader.GetString(2));
            }
            reader.Close();
            conn.Close();
            return cust;
        }

        public async void addOrderAsync(int sID, int cID, Cart cart)
        {
            int orderNum = 0;
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string pullString = "SELECT MAX(OrderNum) FROM Orders";
            using SqlCommand pull = new SqlCommand(pullString, conn);
            using SqlDataReader reader = await pull.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                orderNum = reader.GetInt32(0) + 1;
            }
            reader.Close();
            Dictionary<Product, int> d = cart.dCart;

            foreach (var prod in d)
            {
                string insert = "INSERT INTO Orders (OrderNum, ProductID, NumberOrdered, CustomerID, StoreID, OrderTotal) VALUES (@on, @pid, @pord, @cid, @sid, @total)";
                using SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@pid", prod.Key.ProdID);
                cmd.Parameters.AddWithValue("@on", orderNum);
                cmd.Parameters.AddWithValue("@pord", prod.Value);
                cmd.Parameters.AddWithValue("@cid", cID);
                cmd.Parameters.AddWithValue("@sid", sID);
                double doub = (prod.Value * prod.Key.ProdCost);
                cmd.Parameters.AddWithValue("@total", Convert.ToDecimal(doub));
                await cmd.ExecuteNonQueryAsync();
            }
        }
        public async void restockAsync(int sID, int pID, int howMany)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT Stock FROM StoreStock WHERE StoreID = @sID AND ProductID = @pID", conn);
            cmd.Parameters.AddWithValue("@sID", sID);
            cmd.Parameters.AddWithValue("@pID", pID);
            int stock = 0;
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                stock = reader.GetInt32(0);
            }
            reader.Close();
            stock = stock + howMany;
            SqlCommand upd = new SqlCommand("UPDATE StoreStock SET Stock = @stock WHERE StoreID = @sID AND ProductID = @pID", conn);
            upd.Parameters.AddWithValue("@stock", stock);
            upd.Parameters.AddWithValue("@sID", sID);
            upd.Parameters.AddWithValue("@pID", pID);
            await upd.ExecuteNonQueryAsync();
            conn.Close();
        }
        public async void addToCartAsync(int sID, int pID, int howMany)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("SELECT Stock FROM StoreStock WHERE StoreID = @sID AND ProductID = @pID", conn);
            cmd.Parameters.AddWithValue("@sID", sID);
            cmd.Parameters.AddWithValue("@pID", pID);
            int stock = 0;
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                stock = reader.GetInt32(0);
            }
            reader.Close();
            stock = stock - howMany;
            SqlCommand upd = new SqlCommand("UPDATE StoreStock SET Stock = @stock WHERE StoreID = @sID AND ProductID = @pID", conn);
            upd.Parameters.AddWithValue("@stock", stock);
            upd.Parameters.AddWithValue("@sID", sID);
            upd.Parameters.AddWithValue("@pID", pID);
            await upd.ExecuteNonQueryAsync();
            conn.Close();
        }
    }
}