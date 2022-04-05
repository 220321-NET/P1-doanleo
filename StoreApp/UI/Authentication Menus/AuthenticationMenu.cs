namespace UI
{
    public class AuthenticationMenu
    {
        public List<string> Start()
        {
            List<string> userInput = new List<string>();
            bool menuExit = true;
            //Sets a Default to be modified
            userInput.Add("Guest");
            userInput.Add("password");
            
            do
            {
            //Take User Input 
            Username:
                Console.WriteLine("======================================");
                Console.WriteLine("[#]: Enter a Username: ");
                Console.WriteLine("[x]: Cancel and return to main menu");
                Console.WriteLine("======================================");
                string? cUsername = Console.ReadLine();
                if (cUsername == "x")
                {
                    menuExit = true;
                    break;
                }
                else if (String.IsNullOrWhiteSpace(cUsername))
                {
                    //Validates if it's null or empty
                    Console.WriteLine("[#]: Username can not be empty ");
                    goto Username;
                }
                else if (cUsername == "Guest")
                {
                    Console.WriteLine("[#]: Username can not be 'Guest'");
                    goto Username;
                }
            Password:
                Console.WriteLine("\n\n\n\n\n======================================");
                Console.WriteLine("[#]: Enter a Password: ");
                Console.WriteLine("[x]: Cancel and return to main menu");
                Console.WriteLine("======================================");
                string? cPassword = Console.ReadLine();
                if (cPassword == "x")
                {
                    menuExit = true;
                    break;
                }
                else if (String.IsNullOrWhiteSpace(cPassword))
                {
                    //Validates if it's null or empty
                    Console.WriteLine("[#]: Password can not be empty ");
                    goto Password;
                }

            //Confirm with User
            Confirm:
                Console.WriteLine("\n\n\n\n\n======================================");
                Console.WriteLine($"[#]: Username: {cUsername} \n[#]: Password: {cPassword}");
                Console.WriteLine("[#]: Is this Correct?");
                Console.WriteLine("======================================");
                Console.WriteLine("[1] Yes");
                Console.WriteLine("[2] No");
                Console.WriteLine("[x]: Cancel and return to main menu");
                Console.WriteLine("======================================");
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        userInput[0] = cUsername;
                        userInput[1] = cPassword;
                        menuExit = true;
                        break;
                    case "2":
                        //Goes back to the top
                        break;
                    case "x":
                        menuExit = true;
                        break;
                    default:
                        Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                        goto Confirm;
                }
            } while (!menuExit);
            return userInput;
        }
    }
}