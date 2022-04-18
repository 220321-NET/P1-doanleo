namespace UI
{
    public class LoginMenu : IMenu
    {
        private readonly HttpService _http;
        public LoginMenu(HttpService http)
        {
            _http = http;
        }
        public async Task Start()
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
            try{
                user = await _http.authenticate(user);
            } catch (HttpRequestException ex){
                Console.WriteLine("Couldn't Verify Customer");
                Console.WriteLine(ex);
                goto TryAgain;
            }
            
            if (user.username != "Guest")
            {
                Console.WriteLine("======================================");
                Console.WriteLine("[#]: Login Successful!");
                Console.WriteLine("[#]: Press any button to continue");
                Console.ReadKey();
                c.cCust = user;
                await new MenuFactory().gotoMenu("mainstore").Start();
            }
            else
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
                    await new MenuFactory().gotoMenu("signup").Start();
                }
                else if (retry != "x")
                {
                    Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                }
            }

        }
    }
}