namespace UI
{
    public class ItemMenu : IMenu
    {
        private readonly IBL _bl;
        public ItemMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            bool menuExit = false;

            //Menu Front End
            do
            {
                Console.WriteLine("\n\n\n\n\n======================================");
                Console.WriteLine($"[#]: Store: {c.cStore.StoreName}");
                Console.WriteLine($"[#]: User: {c.cCust.username}| Cart: {c.cCart.Count}");
                new MenuFactory().gotoMenu("stock").Start();
                Console.WriteLine("[#]: Select an Option: ");
                if (c.cCust.isEmployee) { Console.WriteLine("[0]: Restock Items"); }
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
                        if (c.cCust.isEmployee) { new MenuFactory().gotoMenu("restock").Start(); }
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
                        if (c.cCart.Count > 0)
                        {
                        TryAgain:
                            Console.WriteLine($"[#]: There are {c.cCart.Count} item(s) in your cart");
                            Console.WriteLine($"[#]: Are you sure you want to leave?");
                            Console.WriteLine($"[#]: Leaving will reset your cart");
                            Console.WriteLine("[1]: Yes ");
                            Console.WriteLine("[2]: No ");
                            string? retry = Console.ReadLine();
                            if (retry == "1")
                            {
                                clearCart();
                            }
                            else if (retry != "2")
                            {
                                Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                                goto TryAgain;
                            }

                        }
                        else
                        {
                            //Cart is empty, no need to clear
                            menuExit = true;
                        }
                        break;
                    default:
                        Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                        break;
                }
            } while (!menuExit);
        }
        private void checkout()
        {
            Console.WriteLine("[#]: Here is your cart");
            Dictionary<Product, int> d = new Dictionary<Product, int>();
            double total = 0;
            foreach (Product prod in c.cCart)
            {
                if (d.ContainsKey(prod))
                {
                    d[prod] = d[prod] + 1;
                }
                else
                {
                    d.Add(prod, 1);
                }
            }
            foreach (var prod in d)
            {
                total += prod.Key.ProdCost;
                Console.WriteLine($"[#]: {prod.Key.ProdName} | {prod.Value} | ${prod.Key.ProdCost}");
            }
            Console.WriteLine("======================================");
        TryAgain:
            Console.WriteLine("[#]: Would you like to check out?");
            Console.WriteLine($"[#]: Total: ${total.ToString()}");
            Console.WriteLine("[1]: Yes ");
            Console.WriteLine("[2]: No ");
            string? retry = Console.ReadLine();
            if (retry == "1")
            {
                _bl.addOrder(c.cStore, c.cCust, c.cCart);
                //Clear Cart
                c.cCart = new List<Product>();
            }
            else if (retry != "2")
            {
                Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                goto TryAgain;
            }
        }
        private void clearCart()
        {
            foreach (Product item in c.cCart)
            {
                _bl.restock(c.cStore, item, 1);
            }
            c.cCart = new List<Product>();
        }
    }
}