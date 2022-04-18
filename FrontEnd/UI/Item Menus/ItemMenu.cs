namespace UI
{
    public class ItemMenu : IMenu
    {
        private readonly HttpService _http;
        public ItemMenu(HttpService http)
        {
            _http = http;
        }
        public async Task Start()
        {
            bool menuExit = false;

            //Menu Front End
            do
            {
                Console.WriteLine("======================================");
                Console.WriteLine($"[#]: Store: {c.cStore.StoreName}");
                Console.WriteLine($"[#]: User: {c.cCust.username}| Cart: {c.cCart.dCart.Count}");
                await new MenuFactory().gotoMenu("stock").Start();
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
                        if (c.cCust.isEmployee) { await new MenuFactory().gotoMenu("restock").Start(); }
                        break;
                    case "1":
                        await new MenuFactory().gotoMenu("add").Start();
                        break;
                    case "2":
                        await new MenuFactory().gotoMenu("rem").Start();
                        break;
                    case "3":
                        if (c.cCart.dCart.Count < 1)
                        {
                            Console.WriteLine("[#]: Your cart is Empty");
                            break;
                        }
                        checkout();
                        break;
                    case "4":
                        if (c.cCart.dCart.Count > 0)
                        {
                        TryAgain:
                            Console.WriteLine($"[#]: There are {c.cCart.dCart.Count} item(s) in your cart");
                            Console.WriteLine("[#]: Are you sure you want to change stores?");
                            Console.WriteLine("[#]: Leaving will reset your cart");
                            Console.WriteLine("[1]: Go Back");
                            Console.WriteLine("[x]: Leave");
                            string? retry = Console.ReadLine();
                            if (retry == "x")
                            {
                                clearCart();
                                await new MenuFactory().gotoMenu("changestore").Start();
                            }
                            else if (retry != "1")
                            {
                                Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                                goto TryAgain;
                            }

                        }
                        else
                        {
                            await new MenuFactory().gotoMenu("changestore").Start();
                        }
                        break;
                    case "x":
                        if (c.cCart.dCart.Count > 0)
                        {
                        TryAgain:
                            Console.WriteLine($"[#]: There are {c.cCart.dCart.Count} item(s) in your cart");
                            Console.WriteLine("[#]: Are you sure you want to leave?");
                            Console.WriteLine("[#]: Leaving will reset your cart");
                            Console.WriteLine("[1]: Go Back");
                            Console.WriteLine("[x]: Leave");
                            string? retry = Console.ReadLine();
                            if (retry == "x")
                            {
                                clearCart();
                                menuExit = true;
                            }
                            else if (retry != "1")
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
        private async void checkout()
        {
            Console.WriteLine("[#]: Here is your cart");
            
            double total = 0;
            foreach (var prod in c.cCart.dCart)
            {
                total += prod.Value.ProdCost * prod.Value.ProdStock;
            }
            c.cCart.displayCart();
            Console.WriteLine("======================================");
        TryAgain:
            Console.WriteLine("[#]: Would you like to check out?");
            Console.WriteLine($"[#]: Total: ${String.Format("{0:0.00}", total)}");
            Console.WriteLine("[1]: Yes ");
            Console.WriteLine("[x]: No ");
            string? retry = Console.ReadLine();
            if (retry == "1")
            {
                await _http.addOrderAsync(c.cStore.StoreID, c.cCust.CustID, c.cCart.dCart);
                //Clear Cart
                c.cCart = new Cart();
            }
            else if (retry != "x")
            {
                Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                goto TryAgain;
            }
        }
        private async void clearCart()
        {
            foreach (var prod in c.cCart.dCart)
            {
                await _http.restockAsync(c.cStore.StoreID, prod.Value.ProdID, prod.Value.ProdStock);
            }
            c.cCart = new Cart();
        }
    }
}