namespace UI
{
    public class SignUpMenu : IMenu
    {
        private readonly IBL _bl;
        public SignUpMenu(IBL bl)
        {
            _bl = bl;
        }
        public async void Start()
        {
            //Create the login
            TryAgain:
            AuthenticationMenu auth = new AuthenticationMenu();
            List<string> login = auth.Start();
            if (login[0] != "Guest")
            {
                if(await _bl.existingUserAsync(login[0])){
                    Console.WriteLine("[#] Username already taken, try again");
                    goto TryAgain;
                }
                //Store it in the DL
                Customer newC = new Customer();
                newC.username = login[0];
                newC.password = login[1];
                newC.isEmployee = false;
                //push that into add customer, take id
                newC = await _bl.addCustomerAsync(newC.username, newC.password);
                c.cCust = newC;
                new MenuFactory().gotoMenu("mainstore").Start();
            }
        }
    }
}