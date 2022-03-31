namespace Models
{
    public class Customer
    {
        //Properties
        public string username { get; set; } = "Guest";
        public string password { get; set; } = "";
        public int CustID { get; set; }
        public bool isEmployee { get; set; } = false;

    }
}