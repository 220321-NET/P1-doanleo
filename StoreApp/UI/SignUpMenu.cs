namespace UI
{
    public class SignUpMenu : IMenu
    {
        public void Start()
        {
            //Create the login
            Console.WriteLine("\n\n\n\n\n");
            AuthenticationMenu auth = new AuthenticationMenu();
            List<string> login = auth.Start();
            //Store it in the DL
            //insert code here for that
            Customer newC = new Customer();
            newC.username = login[0];
            newC.password =login[1];
            newC.isEmployee = false;
            //push that into add customer, take id

            //set to current and go to store
            //welcome message
            c.cCust = newC;
            new MenuFactory().gotoMenu("mainstore").Start();
        }
    }
}