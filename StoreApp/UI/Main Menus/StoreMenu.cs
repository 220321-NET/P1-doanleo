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
                Console.WriteLine("[3]: Change Store");
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
                        new MenuFactory().gotoMenu("changestore").Start();
                        break;
                    case ".":
                        c.cCust.isEmployee = true;
                        break;
                    case "x":
                        //Flush stored data
                        c.cCust = new Customer();
                        c.cStore = new Storefront();
                        c.cStock = new List<Product>();
                        c.cCart = new Cart();
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