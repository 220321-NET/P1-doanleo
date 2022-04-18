// namespace UI
// {
//     //Main 
//     public class oldMainMenu
//     {
//         private readonly IBL _bl;
//         public oldMainMenu(IBL bl){
//             _bl = bl;
//         }
//         //Other Properties
//         Customer currentUser = new Customer();
//         List<Product> cart = new List<Product>();
//         List<Storefront> stores = new List<Storefront>();//remove this too
//         Storefront currentStore = new Storefront(); //remove this later
//         public void homeMenu()
//         {
//             // Menu Functions
//             // Sign Up -> Create new Customer
//             // Log in -> check list for customer
//             // Employee Login -> check list of employees, enables certain options (employee level 1 or 2 for manager)
//             // Close
//             bool menuExit = false;
//             do
//             {
//                 //Menu Front End
//                 Console.WriteLine("\n\n\n\n\n======================================");
//                 Console.WriteLine("[#]: Welcome to the Apple Store");
//                 Console.WriteLine("[#]: Log in or Create an Account to continue: ");
//                 Console.WriteLine("======================================");
//                 Console.WriteLine("[1]: Log In");
//                 Console.WriteLine("[2]: Create an Account");
//                 Console.WriteLine("[3]: Employee Log In");
//                 Console.WriteLine("[x]: Exit");
//                 Console.WriteLine("======================================");

//                 //Input
//                 string? input = Console.ReadLine();

//                 //Menu Back End
//                 switch (input)
//                 {
//                     case "1":
//                         loginMenu();
//                         break;
//                     case "2":
//                         newCustomer();
//                         break;
//                     case "3":
//                         loginMenu();
//                         break;
//                     case "x":
//                         Console.WriteLine("\n\n\n\n\n======================================");
//                         Console.WriteLine("[#]: Thank you for your patronage\n[#]: Come back soon!");
//                         Console.WriteLine("======================================");
//                         menuExit = true;
//                         break;
//                     default:
//                         Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
//                         break;
//                 }
//             } while (!menuExit);
//         }
//         //Menu Option 1
//         private void newCustomer()
//         {
//             //Create the login
//             Console.WriteLine("\n\n\n\n\n");
//             List<string> userInput = usernamePassword();
//             //Store it in the DL
//             //insert code here for that
//             //Send to Login
//             loginMenu();
//         }
//         private void storeMenu()
//         {
//             // the isEmployee tag will eventually be removed
//             Console.WriteLine("employee?");
//             string? empt = Console.ReadLine();
//             bool isEmployee = false;
//             //bool isEmployee = currentUser.isEmployee;
//             if (empt == "y")
//             {
//                 isEmployee = true;
//             }
//             //User Login
//             // //currentUser = loginMenu();
//             // Console.WriteLine("======================================");
//             // Console.WriteLine($"is employee? {isEmployee}");
//             // Console.WriteLine($"are you supposed to be one? {currentUser.isEmployee}");
//             // Console.WriteLine($"user {currentUser.username}");
//             // Console.WriteLine($"pass {currentUser.password}");
//             // Console.WriteLine("======================================");

//             bool menuExit = false;
//             //Menu Front End
//             do
//             {
//                 Console.WriteLine("\n\n\n\n\n======================================");
//                 Console.WriteLine($"[#]: Welcome to the Apple Store, User: {currentUser.username}");
//                 Console.WriteLine("[#]: Select an Option: ");
//                 Console.WriteLine("======================================");
//                 Console.WriteLine("[1]: View Items in Stock");
//                 Console.WriteLine("[2]: View Order History");
//                 Console.WriteLine("[x]: Log out, return to Main Menu");
//                 Console.WriteLine("======================================");

//                 //Input
//                 string? input = Console.ReadLine();

//                 //Menu Back End
//                 switch (input)
//                 {
//                     case "1":
//                         viewItems(isEmployee);
//                         break;
//                     case "2":
//                         viewOrders(isEmployee);
//                         break;
//                     case "x":
//                         currentUser = new Customer();
//                         //Removes the current customer and sets it to the default
//                         menuExit = true;
//                         break;
//                     default:
//                         Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
//                         break;
//                 }
//             } while (!menuExit);
//         }
        

//         //Login Screen, WILL RETURN A CUSTOMER TO KEEP PERSISTENCE
//         private void loginMenu()
//         {
//             Customer user = new Customer();
//             Console.WriteLine("\n\n\n\n\n======================================");
//             Console.WriteLine("[#]: Please log in to continue");
//             List<string> login = usernamePassword();
//             user.username = login[0];
//             user.password = login[1];
//             /*
//                 Here would be code to validate that they are a user within the list
//                 change to return a customer later? that way theres persistence
//                 dont need employee class technically cause i have a flag for it
//                 an employee is just a customer with more access 
//                     and i can put it in them to check for sure?
//                 customer have flag for employee checked in store menu
//                 but the search would just match user and password, if match then success
//                 if fail then retry
//             */

//             Console.WriteLine("\n\n\n\n\n======================================");
//             Console.WriteLine("[#]: Login Successful!");
//             Console.WriteLine("[#]: Press any button to continue");
//             Console.WriteLine("======================================");
//             Console.ReadKey();
//             currentUser = user;
//             storeMenu();
//         }

//         //Used for Login and Sign up
//         private List<string> usernamePassword()
//         {
//             List<string> userInput = new List<string>();
//             bool menuExit = true;
//             //populate userInput in case we exit and return to main menu, it goes back to default
//             userInput.Add("Guest");
//             userInput.Add("password");

//             do
//             {
//             //Take User Input 
//             Username:
//                 Console.WriteLine("======================================");
//                 Console.WriteLine("[#]: Enter a Username: ");
//                 Console.WriteLine("[x]: Cancel and return to main menu");
//                 Console.WriteLine("======================================");
//                 string? cUsername = Console.ReadLine();
//                 if (cUsername == "x")
//                 {
//                     menuExit = true;
//                     break;
//                 }
//                 else if (String.IsNullOrWhiteSpace(cUsername))
//                 {
//                     //Validates if it's null or empty
//                     Console.WriteLine("[#]: Username can not be empty ");
//                     goto Username;
//                 }
//                 else if (cUsername == "Guest")
//                 {
//                     Console.WriteLine("[#]: Username can not be 'Guest'");
//                     goto Username;
//                 }
//             Password:
//                 Console.WriteLine("\n\n\n\n\n======================================");
//                 Console.WriteLine("[#]: Enter a Password: ");
//                 Console.WriteLine("[x]: Cancel and return to main menu");
//                 Console.WriteLine("======================================");
//                 string? cPassword = Console.ReadLine();
//                 if (cPassword == "x")
//                 {
//                     menuExit = true;
//                     break;
//                 }
//                 else if (String.IsNullOrWhiteSpace(cPassword))
//                 {
//                     //Validates if it's null or empty
//                     Console.WriteLine("[#]: Password can not be empty ");
//                     goto Password;
//                 }

//             //Confirm with User
//             Confirm:
//                 Console.WriteLine("\n\n\n\n\n======================================");
//                 Console.WriteLine($"[#]: Username: {cUsername} \n[#]: Password: {cPassword}");
//                 Console.WriteLine("[#]: Is this Correct?");
//                 Console.WriteLine("======================================");
//                 Console.WriteLine("[1] Yes");
//                 Console.WriteLine("[2] No");
//                 Console.WriteLine("[x]: Cancel and return to main menu");
//                 Console.WriteLine("======================================");
//                 string? input = Console.ReadLine();
//                 switch (input)
//                 {
//                     case "1":
//                         userInput[0] = cUsername;
//                         userInput[1] = cPassword;
//                         menuExit = true;
//                         break;
//                     case "2":
//                         //Goes back to the top
//                         break;
//                     case "x":
//                         menuExit = true;
//                         break;
//                     default:
//                         Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
//                         goto Confirm;
//                 }
//             } while (!menuExit);
//             return userInput;
//         }
//         //Here will be menus within the storeMenu() class
//         //viewItems methods
//         private void viewItems(bool isEmployee)
//         {
//             bool accessGranted = isEmployee;
//             bool menuExit = false;

//             //Menu Front End
//             do
//             {
//                 Console.WriteLine("\n\n\n\n\n======================================");
//                 Console.WriteLine($"[#]: Store: {currentStore.StoreName} | User: {currentUser.username}");
//                 Console.WriteLine($"[#]: Here is what we have in stock. | Cart: {cart.Count}");
//                 pullInventory();
//                 Console.WriteLine("[#]: Select an Option: ");
//                 if (isEmployee)
//                 {
//                     Console.WriteLine("[0]: Restock Items");
//                 }
//                 Console.WriteLine("[1]: Add to Cart");
//                 Console.WriteLine("[2]: Remove from Cart");
//                 Console.WriteLine("[3]: Check Out");
//                 Console.WriteLine("[4]: Change Store");
//                 Console.WriteLine("[x]: Return to Main Menu");
//                 Console.WriteLine("======================================");

//                 //Input
//                 string? input = Console.ReadLine();

//                 //Menu Back End
//                 switch (input)
//                 {
//                     case "0":
//                         //You can get here even if you arent an employee so
//                         //this is here to stop that
//                         if (isEmployee) { restock(); }
//                         break;
//                     case "1":
//                         addToCart();
//                         break;
//                     case "2":
//                         remFrCart();
//                         break;
//                     case "3":
//                         checkout();
//                         break;
//                     case "4":
//                         jumpStores();
//                         break;
//                     case "x":
//                         menuExit = true;
//                         break;
//                     default:
//                         Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
//                         break;
//                 }
//             } while (!menuExit);
//             /*
//                 View Inventory 
//                     -> Select Location
//                     -> Restock Item (E)
//                         ->Access Granted (M)
//                     -> Add to Cart (C)
//                     -> Check Out (C)
//                     -> Remove From Cart (C)
//             */
//         }
//         private void pullInventory()
//         {
//             //pull store stock and add each selection into below
//             //id 
//             Console.WriteLine("======================================");
//             Console.WriteLine($"Name: Fuji  |Name: Gala  |Name: Mac   ");
//             Console.WriteLine($"Price: $0.00|Price: $0.00|Price: $0.00");
//             Console.WriteLine($"Stock: 00000|Stock: 00000|Stock: 00000");
//             Console.WriteLine("    [01]    |    [02]    |    [03]    ");
//             Console.WriteLine("======================================");
//             Console.WriteLine($"Name: Granny|Name: HoneyC|Name: RedDel");
//             Console.WriteLine($"Price: $0.00|Price: $0.00|Price: $0.00");
//             Console.WriteLine($"Stock: 00000|Stock: 00000|Stock: 00000");
//             Console.WriteLine("    [04]    |    [05]    |    [06]    ");
//             Console.WriteLine("======================================");
//         }
//         private void restock()
//         {
//         //Do I want to it to even have a password to allow this?
//         //idk check cust id and if it doesnt match ask for override?
//         AnotherOne:
//             pullInventory();
//             Console.WriteLine("[#]: Which item would you like to restock?: ");
//             Console.WriteLine("[x]: Return to other Options");
//             //Input
//             string? input = Console.ReadLine();

//             //Menu Back End
//             //Later it'll check if its an item it can even incriment
//             switch (input)
//             {
//                 case "1":
//                     Console.WriteLine("[#]: Incrimented Object 1");
//                     break;
//                 case "2":
//                     Console.WriteLine("[#]: Incrimented Object 2");
//                     break;
//                 case "3":
//                     Console.WriteLine("[#]: Incrimented Object 3");
//                     break;
//                 case "4":
//                     Console.WriteLine("[#]: Incrimented Object 4");
//                     break;
//                 case "5":
//                     Console.WriteLine("[#]: Incrimented Object 5");
//                     break;
//                 case "6":
//                     Console.WriteLine("[#]: Incrimented Object 6");
//                     break;
//                 case "x":
//                     break;
//                 default:
//                     Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
//                     break;
//             }

//         TryAgain:
//             Console.WriteLine("[#]: Would you like to restock another?: ");
//             Console.WriteLine("[1] Yes ");
//             Console.WriteLine("[2] No ");
//             string? retry = Console.ReadLine();
//             if (retry == "1")
//             {
//                 goto AnotherOne;
//             }
//             else if (retry != "2")
//             {
//                 Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
//                 goto TryAgain;
//             }

//         }
//         private void addToCart()
//         {
//             //dont bother writing now, its gonna be a copy paste of the 
//             //restock with the switch and text changed
//         }
//         private void remFrCart()
//         {
//             //REMOVE THIS CODE LATER
//             Product temp = new Product();
//             Product temp2 = new Product();
//             temp2.ProdName = "removethis";

//             cart.Add(temp);
//             cart.Add(temp2);

//         AnotherOne:
//             Console.WriteLine("[#]: Here is your cart");
//             foreach (Product prod in cart)
//             {
//                 Console.WriteLine($"[#]: {prod.ProdName}");
//             }
//             Console.WriteLine("[#]: Enter the name of the product you want to remove");
//             string? input = Console.ReadLine();
//             bool found = false;
//             foreach (Product prod in cart)
//             {
//                 if (input == prod.ProdName)
//                 {
//                     //maybe make it not case sensitive
//                     cart.Remove(prod);
//                     found = true;
//                     Console.WriteLine($"[#]: Product: {prod.ProdName} removed.");
//                     break;
//                 }
//             }
//             if (!found)
//             {
//                 Console.WriteLine("[#]: Product not found");
//             }

//         TryAgain:
//             Console.WriteLine("[#]: Would you like to remove another?: ");
//             Console.WriteLine("[1] Yes ");
//             Console.WriteLine("[2] No ");

//             string? retry = Console.ReadLine();
//             if (retry == "1")
//             {
//                 goto AnotherOne;
//             }
//             else if (retry != "2")
//             {
//                 Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
//                 goto TryAgain;
//             }
//         }
//         private void checkout()
//         {
//             //calls a BL function to update the store's stock
//             //adds the order 
//             //idk how imma write this rn
//         }
//         private void jumpStores()
//         {
//             //creates a list of stores, puts a flag on the store id you're at rn
//             //
//             //REMOVE THIS CODE LATER
//             Storefront temp1 = new Storefront();
//             Storefront temp2 = new Storefront();
//             Storefront temp3 = new Storefront();
//             Storefront temp4 = new Storefront();
//             temp1.StoreName = "test 1";
//             temp2.StoreName = "test 2";
//             temp3.StoreName = "test 3";
//             temp4.StoreName = "Apple Superstore";
//             stores.Add(temp1);
//             stores.Add(temp2);
//             stores.Add(temp4);
//             stores.Add(temp3);

//             Console.WriteLine("\n\n\n\n\n======================================");
//             Console.WriteLine($"[#]: You are at: {currentStore.StoreName}");
//             Console.WriteLine("[#]: Here is a list of our stores");
//             Console.WriteLine("======================================");
//             foreach (Storefront store in stores)
//             {
//                 string output = $"[#]: {store.StoreName}";
//                 if (store.StoreName == currentStore.StoreName)
//                 {
//                     output += "<-- YOU ARE HERE";
//                 }
//                 Console.WriteLine(output);
//             }
//         TryAgain:
//             Console.WriteLine("[#]: Enter the name of the store you would like to go to");
//             string? input = Console.ReadLine();
//             bool found = false;
//             foreach (Storefront store in stores)
//             {
//                 if (input == store.StoreName)
//                 {
//                     found = true;
//                     Console.WriteLine($"[#]: Moving to {store.StoreName}.");
//                     currentStore = store;
//                     break;
//                 }
//             }
//             if (!found)
//             {
//                 Console.WriteLine("[#]: Store not found");
//                 goto TryAgain;
//             }
//         }
//         //viewOrders methods
//         private void viewOrders(bool isEmployee)
//         {
//             bool accessGranted = isEmployee;

//             // if employee go to viewStoreOrders(string sort)
//             // if customer go to viewCustOrders(string sort)
//             // display with a default search then give sort options, 

//             bool menuExit = false;
//             do{

//             }while(!menuExit);

//             /*
//                 View Order History (checks if customer or employee, 
//                     this method changes depending on which)
//                     -> Sort By (Both Ways)
//                         Location
//                         Date
//                         Cost
//                     -> Display Order Details
//             */
//         }
//     }
// }