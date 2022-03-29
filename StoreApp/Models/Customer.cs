namespace Models
{
    public class Customer
    {
        //Properties
        public string username { get; set; }
        public string password { get; set; }
        public int ID { get; set; }
        public bool isEmployee{ get; set;}
        // Constructor
        public Customer()
        {
            username = "Guest";
            password = "password";
            ID = 0;
            isEmployee = false;
        }
        //Methods
        /*
            Name, Assigned ID
        */
    }
}