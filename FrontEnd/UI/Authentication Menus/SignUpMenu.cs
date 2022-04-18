namespace UI
{
    public class SignUpMenu : IMenu
    {
        private readonly HttpService _http;
        public SignUpMenu(HttpService http)
        {
            _http = http;
        }
        public async Task Start()
        {
        //Create the login
        TryAgain:
            AuthenticationMenu auth = new AuthenticationMenu();
            List<string> login = auth.Start();
            //Store it in the DL
            Customer newC = new Customer();
            newC.username = login[0];
            newC.password = login[1];
            newC.isEmployee = false;
            if (login[0] != "Guest")
            {
                try
                {
                    newC = await _http.addCustomer(newC);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("Couldn't Create Customer");
                    Console.WriteLine(ex);
                    goto TryAgain;
                }
                if (newC.username != "Guest")
                {
                    c.cCust = newC;
                    await new MenuFactory().gotoMenu("mainstore").Start();
                } else {
                    Console.WriteLine("[#] Username already taken, try again");
                    goto TryAgain;
                }
            }
        }
    }
}