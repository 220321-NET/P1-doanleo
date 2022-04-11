namespace UI
{
    public class LoginMenu : IMenu
    {
        private readonly IBL _bl;
        public LoginMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            Customer user = new Customer();
            Console.WriteLine("======================================");
            Console.WriteLine("[#]: Please log in to continue");

        TryAgain:
            AuthenticationMenu auth = new AuthenticationMenu();
            List<string> login = auth.Start();

            user.username = login[0];
            user.password = login[1];
            //authenticate
            if (_bl.authenticate(user.username, user.password))
            {
                Console.WriteLine("======================================");
                Console.WriteLine("[#]: Login Successful!");
                Console.WriteLine("[#]: Press any button to continue");
                user = _bl.getCustomer(user);
                Console.ReadKey();
                c.cCust = user;
                new MenuFactory().gotoMenu("mainstore").Start();
            }
            else if (user.username != "Guest")
            {
                Console.WriteLine("[#]: Could not Authenticate User. Try Again?");
                Console.WriteLine("[1]: Yes ");
                Console.WriteLine("[2]: Sign Up");
                Console.WriteLine("[x]: No ");
                string? retry = Console.ReadLine();
                if (retry == "1")
                {
                    goto TryAgain;
                }
                else if (retry == "2")
                {
                    new MenuFactory().gotoMenu("signup").Start();
                }
                else if (retry != "x")
                {
                    Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                }
            }

        }
    }
}