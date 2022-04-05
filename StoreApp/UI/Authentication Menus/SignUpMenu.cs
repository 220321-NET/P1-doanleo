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
            AuthenticationMenu auth = new AuthenticationMenu();
            List<string> login = auth.Start();
            if (login[0] != "Guest")
            {
                //Store it in the DL
                Customer newC = new Customer();
                newC.username = login[0];
                newC.password = login[1];
                newC.isEmployee = false;
                //push that into add customer, take id
                newC = _bl.addCustomer(newC);
                c.cCust = newC;
                new MenuFactory().gotoMenu("mainstore").Start();
            }
        }
    }
}