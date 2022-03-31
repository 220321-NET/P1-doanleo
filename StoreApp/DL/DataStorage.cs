using Microsoft.Data.SqlClient;

namespace DL
{
    public class DataStorage : IRepo
    {
        private readonly string _connectionString;
        public DataStorage(string connectionString){
            _connectionString = connectionString;
        }

        public int addCustomer(Customer cust)
        {
            throw new NotImplementedException();
        }

        public void addOrder(List<Product> cart)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders(bool isEmployee)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetStock(Storefront store)
        {
            throw new NotImplementedException();
        }

        public List<Storefront> GetStores()
        {
            throw new NotImplementedException();
        }

        public bool loginCheck(Customer cust)
        {   
            //only checks if username and password match then returns yes or not
            throw new NotImplementedException();
        }

        public void restock(Storefront store, Product item, int howMany)
        {
            throw new NotImplementedException();
        }


        public void sample(){
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
        public void dcSample(){


        }
    }
}