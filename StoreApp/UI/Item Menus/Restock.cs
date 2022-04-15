namespace UI
{

    public class Restock : IMenu
    {
        private readonly HttpService _http;
        public Restock(HttpService http)
        {
            _http = http;
        }
        public async Task Start()
        {
        //Do I want to it to even have a password to allow this?
        //idk check cust id and if it doesnt match ask for override?
        AnotherOne:
            await new MenuFactory().gotoMenu("stock").Start();
            List<Product> stock = await _http.GetStockAsync(c.cStore.StoreID);
            Console.WriteLine("[#]: Which item would you like to restock?: ");
            Console.WriteLine("[x]: Return to other Options");
            //Input
            string? input = Console.ReadLine();

            //Menu Back End
            //Later it'll check if its an item it can even incriment
            switch (input)
            {
                case "1":
                    await restock(0);
                    break;
                case "2":
                    await restock(1);
                    break;
                case "3":
                    await restock(2);
                    break;
                case "4":
                    await restock(3);
                    break;
                case "5":
                    await restock(4);
                    break;
                case "6":
                    await restock(5);
                    break;
                case "x":
                    goto End;
                default:
                    Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                    break;
            }

        TryAgain:
            Console.WriteLine("[#]: Would you like to restock another?: ");
            Console.WriteLine("[1] Yes ");
            Console.WriteLine("[x] No ");
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
        private async Task restock(int index)
        {
        AnotherOne:
            Console.WriteLine($"[#]: How many {c.cStock[index].ProdName} would you like to restock?");
            string? num = Console.ReadLine();
            int howMany = 0;
            if (Int32.TryParse(num, out howMany))
            {
                await _http.restockAsync(c.cStore.StoreID, c.cStock[index].ProdID, howMany);
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
