namespace UI
{
    public class ItemMenu : IMenu
    {
        public void Start()
        {
            bool menuExit = false;

            //Menu Front End
            do
            {
                Console.WriteLine("\n\n\n\n\n======================================");
                Console.WriteLine($"[#]: Store: {c.cStore.StoreName} | User: {c.cCust.username}");
                Console.WriteLine($"[#]: Here is what we have in stock. | Cart: {c.cCart.Count}");
                new MenuFactory().gotoMenu("stock").Start();
                Console.WriteLine("[#]: Select an Option: ");
                if (c.cCust.isEmployee)
                {
                    Console.WriteLine("[0]: Restock Items");
                }
                Console.WriteLine("[1]: Add to Cart");
                Console.WriteLine("[2]: Remove from Cart");
                Console.WriteLine("[3]: Check Out");
                Console.WriteLine("[4]: Change Store");
                Console.WriteLine("[x]: Return to Main Menu");
                Console.WriteLine("======================================");

                //Input
                string? input = Console.ReadLine();

                //Menu Back End
                switch (input)
                {
                    case "0":
                        //You can get here even if you arent an employee so
                        //this is here to stop that
                        if (c.cCust.isEmployee) { new MenuFactory().gotoMenu("restock").Start();; }
                        break;
                    case "1":
                        new MenuFactory().gotoMenu("add").Start();
                        break;
                    case "2":
                        new MenuFactory().gotoMenu("rem").Start();
                        break;
                    case "3":
                        checkout();
                        break;
                    case "4":
                        new MenuFactory().gotoMenu("changestore").Start();
                        break;
                    case "x":
                        menuExit = true;
                        break;
                    default:
                        Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                        break;
                }
            } while (!menuExit);
            /*
                View Inventory 
                    -> Select Location
                    -> Restock Item (E)
                        ->Access Granted (M)
                    -> Add to Cart (C)
                    -> Check Out (C)
                    -> Remove From Cart (C)
            */
        }
        private void checkout()
        {
            //calls a BL function to update the store's stock
            //adds the order 
            //idk how imma write this rn
        }
    }
}