namespace UI
{
    public class StoreMenu : IMenu
    {
        public void Start()
        {
            bool menuExit = false;
            //Menu Front End
            do
            {
                Console.WriteLine("======================================");
                Console.WriteLine($"[#]: Welcome to {c.cStore.StoreName}, User: {c.cCust.username}");
                Console.WriteLine("[#]: Select an Option: ");
                Console.WriteLine("======================================");
                Console.WriteLine("[1]: View Items in Stock");
                Console.WriteLine("[2]: View Order History");
                Console.WriteLine("[x]: Log out, return to Main Menu");
                Console.WriteLine("======================================");

                //Input
                string? input = Console.ReadLine();

                //Menu Back End
                switch (input)
                {
                    case "1":
                        //viewItems(cCust.isEmployee);
                        new MenuFactory().gotoMenu("item").Start();
                        break;
                    case "2":
                        //viewOrders(cCust.isEmployee);
                        new MenuFactory().gotoMenu("order").Start();
                        break;
                    case "3":
                        c.cCust.isEmployee = true;
                        break;
                    case "x":
                        //Removes the current customer and sets it to the default
                        menuExit = true;
                        break;
                    default:
                        Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                        break;
                }
            } while (!menuExit);
        }
    }
}