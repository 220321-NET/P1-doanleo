namespace UI
{
    public class SignUpMenu : IMenu
    {
        private readonly IBL _bl;
        public SignUpMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            //Create the login
            TryAgain:
            AuthenticationMenu auth = new AuthenticationMenu();
            List<string> login = auth.Start();
            if (login[0] != "Guest")
            {
                if(_bl.existingUser(login[0])){
                    Console.WriteLine("[#] Username already taken, try again");
                    goto TryAgain;
                }
                //Store it in the DL
                Customer newC = new Customer();
                newC.username = login[0];
                newC.password = login[1];
                newC.isEmployee = false;
                //push that into add customer, take id
                newC = _bl.addCustomer(newC.username, newC.password);
                c.cCust = newC;
                new MenuFactory().gotoMenu("mainstore").Start();
            }
        }
    }
}