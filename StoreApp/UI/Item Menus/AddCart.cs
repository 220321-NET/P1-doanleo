namespace UI
{
    public class AddCart : IMenu
    {
        private readonly HttpService _http;
        public AddCart(HttpService http)
        {
            _http = http;
        }
        public async Task Start()
        {
        AnotherOne:
            await new MenuFactory().gotoMenu("stock").Start();
            List<Product> stock = await _http.GetStockAsync(c.cStore.StoreID);
            Console.WriteLine($"[#]: Which item would you like? | Cart: {c.cCart.dCart.Count}");
            Console.WriteLine("[x]: Return to other Options");
            //Input
            string? input = Console.ReadLine();

            //Menu Back End
            switch (input)
            {
                case "1":
                    await addToCart(0);
                    break;
                case "2":
                    await addToCart(1);
                    break;
                case "3":
                    await addToCart(2);
                    break;
                case "4":
                    await addToCart(3);
                    break;
                case "5":
                    await addToCart(4);
                    break;
                case "6":
                    await addToCart(5);
                    break;
                case "x":
                    goto End;
                default:
                    Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                    break;
            }

        TryAgain:
            Console.WriteLine("[#]: Would you like to add another item?: ");
            Console.WriteLine("[1]: Yes ");
            Console.WriteLine("[x]: No ");
            string? retry = Console.ReadLine();
            if (retry == "1")
            {
                goto AnotherOne;
            }
            else if (retry != "x")
            {
                Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                goto TryAgain;
            }
        End:
            Console.WriteLine("");
        }
        private async Task addToCart(int index)
        {
        AnotherOne:
            Console.WriteLine($"[#]: How many {c.cStock[index].ProdName} would you like?");
            string? num = Console.ReadLine();
            int howMany = 0;
            if (Int32.TryParse(num, out howMany))
            {
                if (howMany > 0)
                {
                    await _http.addToCartAsync(c.cStore.StoreID, c.cStock[index].ProdID, howMany);
                    c.cCart.addToCart(c.cStock[index], howMany);
                } else {
                    Console.WriteLine("[#]: Why are you adding 0 of this item?");
                }
            }
            else
            {
            TryAgain:
                Console.WriteLine("[#]: Oops, Invalid Input! Try Again?");
                Console.WriteLine("[1]: Yes ");
                Console.WriteLine("[x]: No ");
                string? retry = Console.ReadLine();
                if (retry == "1")
                {
                    goto AnotherOne;
                }
                else if (retry != "x")
                {
                    Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                    goto TryAgain;
                }
            }
        }
    }

}