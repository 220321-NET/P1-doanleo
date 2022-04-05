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
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("[#]: Welcome to the Big Apple Hub");
                Console.WriteLine("                        .8 ");
                Console.WriteLine("                      .888");
                Console.WriteLine("                    .8888'");
                Console.WriteLine("                   .8888'");
                Console.WriteLine("                   888'");
                Console.WriteLine("                   8'");
                Console.WriteLine("      .88888888888. .88888888888.");
                Console.WriteLine("   .8888888888888888888888888888888.");
                Console.WriteLine(" .8888888888888888888888888888888888.");
                Console.WriteLine(".&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&'");
                Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&'");
                Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&'");
                Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@:");
                Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@:");
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.");
                Console.WriteLine(" `0000000000000000000000000000000000'");
                Console.WriteLine("  `0000000000000000000000000000000000'");
                Console.WriteLine("   `00000000000000000000000000000000'");
                Console.WriteLine("     `#############################'");
                Console.WriteLine("       `#########################'");
                Console.WriteLine("         `##########''#########'");
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