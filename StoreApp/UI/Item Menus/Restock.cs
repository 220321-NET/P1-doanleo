namespace UI
{

    public class Restock : IMenu
    {
        private readonly IBL _bl;
        public Restock(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
        //Do I want to it to even have a password to allow this?
        //idk check cust id and if it doesnt match ask for override?
        AnotherOne:
            new MenuFactory().gotoMenu("stock").Start();
            List<Product> stock = _bl.GetStock(c.cStore);
            Console.WriteLine("[#]: Which item would you like to restock?: ");
            Console.WriteLine("[x]: Return to other Options");
            //Input
            string? input = Console.ReadLine();

            //Menu Back End
            //Later it'll check if its an item it can even incriment
            switch (input)
            {
                case "1":
                    restock(0);
                    break;
                case "2":
                    restock(1);
                    break;
                case "3":
                    restock(2);
                    break;
                case "4":
                    restock(3);
                    break;
                case "5":
                    restock(4);
                    break;
                case "6":
                    restock(5);
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
        private void restock(int index)
        {
        AnotherOne:
            Console.WriteLine($"[#]: How many {c.cStock[index].ProdName} would you like to restock?");
            string? num = Console.ReadLine();
            int howMany = 0;
            if (Int32.TryParse(num, out howMany))
            {
                _bl.restock(c.cStore, c.cStock[index], howMany);
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
