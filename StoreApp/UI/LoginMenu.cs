namespace UI
{
    public class LoginMenu : IMenu
    {
        public void Start()
        {
            Customer user = new Customer();
            Console.WriteLine("\n\n\n\n\n======================================");
            Console.WriteLine("[#]: Please log in to continue");
            AuthenticationMenu auth = new AuthenticationMenu();
            List<string> login = auth.Start();

            user.username = login[0];
            user.password = login[1];
            //authenticate
            //if(_bl.loginCheck(user)){
                //populate with user's information.
            //}            //populate with user's information.
            
            /*
                Here would be code to validate that they are a user within the list
                change to return a customer later? that way theres persistence
                dont need employee class technically cause i have a flag for it
                an employee is just a customer with more access 
                    and i can put it in them to check for sure?
                customer have flag for employee checked in store menu
                but the search would just match user and password, if match then success
                if fail then retry
            */

            Console.WriteLine("\n\n\n\n\n======================================");
            Console.WriteLine("[#]: Login Successful!");
            Console.WriteLine("[#]: Press any button to continue");
            Console.WriteLine("======================================");
            Console.ReadKey();
            c.cCust = user;
            new MenuFactory().gotoMenu("mainstore").Start();
        }
    }
}