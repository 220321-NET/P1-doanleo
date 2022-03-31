namespace UI
{
    public class AddCart : IMenu
    {
        public void Start()
        {
        //REMEMBER TO REDO THIS TO MAKE IT RIGHT
        //Do I want to it to even have a password to allow this?
        //idk check cust id and if it doesnt match ask for override?
        AnotherOne:
            new MenuFactory().gotoMenu("stock").Start();
            Console.WriteLine("[#]: Which item would you like to restock?: ");
            Console.WriteLine("[x]: Return to other Options");
            //Input
            string? input = Console.ReadLine();

            //Menu Back End
            //Later it'll check if its an item it can even incriment
            switch (input)
            {
                case "1":
                    Console.WriteLine("[#]: Incrimented Object 1");
                    break;
                case "2":
                    Console.WriteLine("[#]: Incrimented Object 2");
                    break;
                case "3":
                    Console.WriteLine("[#]: Incrimented Object 3");
                    break;
                case "4":
                    Console.WriteLine("[#]: Incrimented Object 4");
                    break;
                case "5":
                    Console.WriteLine("[#]: Incrimented Object 5");
                    break;
                case "6":
                    Console.WriteLine("[#]: Incrimented Object 6");
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
            Console.WriteLine("[2] No ");
            string? retry = Console.ReadLine();
            if (retry == "1")
            {
                goto AnotherOne;
            }
            else if (retry != "2")
            {
                Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                goto TryAgain;
            }
        End:
            Console.WriteLine("");
        }
    }
}