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
            Console.WriteLine("\n\n\n\n\n");
            AuthenticationMenu auth = new AuthenticationMenu();
            List<string> login = auth.Start();
            
            //Store it in the DL
            Customer newC = new Customer();
            newC.username = login[0];
            newC.password = login[1];
            newC.isEmployee = false;
            //push that into add customer, take id
            newC.CustID = _bl.addCustomer(newC);
            //set to current and go to store
            //welcome message
            c.cCust = newC;
            new MenuFactory().gotoMenu("mainstore").Start();
        }
    }
}