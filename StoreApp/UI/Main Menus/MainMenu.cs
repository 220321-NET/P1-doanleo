namespace UI
{
    public class MainMenu : IMenu
    {

        public void Start()
        {
            bool menuExit = false;
            do
            {
                //Menu Front End
                Console.WriteLine("======================================");
                Console.WriteLine("         .:'");
                Console.WriteLine("      __ :'__");
                Console.WriteLine("   .'`__`-'__``.");
                Console.WriteLine("  :__________.-'");
                Console.WriteLine("  :_________: {BAH}");
                Console.WriteLine("   :_________`-; ");
                Console.WriteLine("    `.__.-.__.'");
                Console.WriteLine("[#]: Welcome to the Big Apple Hub");
                Console.WriteLine("[#]: Log in or Create an Account to continue: ");
                Console.WriteLine("======================================");
                Console.WriteLine("[1]: Log In");
                Console.WriteLine("[2]: Create an Account");
                Console.WriteLine("[x]: Exit");
                Console.WriteLine("======================================");

                //Input
                string? input = Console.ReadLine();

                //Menu Back End
                switch (input)
                {
                    case "1":
                        new MenuFactory().gotoMenu("login").Start();
                        break;
                    case "2":
                        new MenuFactory().gotoMenu("signup").Start();
                        break;
                    case "x":
                        Console.WriteLine("======================================");
                        Console.WriteLine("[#]: Thank you for your patronage\n[#]: Come back soon!");
                        Console.WriteLine("======================================");
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