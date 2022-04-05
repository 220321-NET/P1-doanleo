namespace UI
{
    public class AddCart : IMenu
    {
        private readonly IBL _bl;
        public AddCart(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
        AnotherOne:
            new MenuFactory().gotoMenu("stock").Start();
            List<Product> stock = _bl.GetStock(c.cStore);
            Console.WriteLine($"[#]: Which item would you like? | Cart: {c.cCart.Count}");
            Console.WriteLine("[x]: Return to other Options");
            //Input
            string? input = Console.ReadLine();

            //Menu Back End
            switch (input)
            {
                case "1":
                    addToCart(0);
                    break;
                case "2":
                    addToCart(1);
                    break;
                case "3":
                    addToCart(2);
                    break;
                case "4":
                    addToCart(3);
                    break;
                case "5":
                    addToCart(4);
                    break;
                case "6":
                    addToCart(5);
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
        private void addToCart(int index)
        {
        AnotherOne:
            Console.WriteLine($"[#]: How many {c.cStock[index].ProdName} would you like?");
            string? num = Console.ReadLine();
            int howMany = 0;
            if (Int32.TryParse(num, out howMany))
            {
                _bl.addToCart(c.cStore, c.cStock[index], howMany);
                for (int x = 0; x < howMany; x++)
                {
                    //will break on negative input
                    c.cCart.Add(c.cStock[index]);
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