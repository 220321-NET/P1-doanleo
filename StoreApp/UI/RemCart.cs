namespace UI
{
    public class RemCart : IMenu
    {
        private readonly IBL _bl;
        public RemCart(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            if (c.cCart.Count < 1)
            {
                goto End;
            }
        AnotherOne:
            Console.WriteLine("[#]: Here is your cart");
            Dictionary<Product, int> d = new Dictionary<Product, int>();
            foreach (Product prod in c.cCart)
            {
                if (d.ContainsKey(prod))
                {
                    d[prod] = d[prod] + 1;
                }
                else
                {
                    d.Add(prod, 1);
                }
            }
            foreach (var prod in d)
            {
                Console.WriteLine($"[#]: {prod.Key.ProdName} | {prod.Value} | ${prod.Key.ProdCost}");
            }
            Console.WriteLine("[#]: Enter the name of the product you want to remove");
            string? input = Console.ReadLine();
            c.cCart.RemoveAll(a => a.ProdName == input);
            Console.WriteLine($"[#]: Product {input} has been removed.");
        TryAgain:
            if (c.cCart.Count < 1){
                goto End;
            }
            foreach (var prod in d)
            {
                Console.WriteLine($"[#]: {prod.Key.ProdName} | {prod.Value}");
            }
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
        End:
            Console.WriteLine("[#]: Cart is Empty");
        }

    }

}