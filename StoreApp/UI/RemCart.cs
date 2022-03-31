namespace UI
{
    public class RemCart : IMenu
    {
        public void Start()
        {
            //REMOVE THIS CODE LATER
            Product temp = new Product();
            Product temp2 = new Product();
            temp2.ProdName = "removethis";

            c.cCart.Add(temp);
            c.cCart.Add(temp2);

            AnotherOne:
            Console.WriteLine("[#]: Here is your cart");
            foreach (Product prod in c.cCart)
            {
                Console.WriteLine($"[#]: {prod.ProdName}");
            }
            Console.WriteLine("[#]: Enter the name of the product you want to remove");
            string? input = Console.ReadLine();
            bool found = false;
            foreach (Product prod in c.cCart)
            {
                if (input == prod.ProdName)
                {
                    //maybe make it not case sensitive
                    c.cCart.Remove(prod);
                    found = true;
                    Console.WriteLine($"[#]: Product: {prod.ProdName} removed.");
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("[#]: Product not found");
            }

            TryAgain:
            Console.WriteLine("[#]: Would you like to remove another?: ");
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
        }
    }
}