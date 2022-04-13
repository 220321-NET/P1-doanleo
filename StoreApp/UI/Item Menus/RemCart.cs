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
            if (c.cCart.dCart.Count < 1)
            {
                goto End;
            }
        AnotherOne:
            Console.WriteLine("[#]: Here is your cart");
            c.cCart.displayCart();
            Console.WriteLine("[#]: Enter the name of the product you want to remove");
            string? input = Console.ReadLine();
            //find the product to restock
            int pos = -1;
            for (int i = 0; i < c.cStock.Count; i++)
            {
                if (c.cStock[i].ProdName == input)
                {
                    pos = i;
                    break;
                }
            }
            //restock it
            if (pos != -1) // if it exists
            {
                //find how much to restock
                int num = 0;
                foreach (var prod in c.cCart.dCart)
                {
                    if (prod.Key.ProdName == c.cStock[pos].ProdName)
                    {
                        num = prod.Value;
                    }
                }
                _bl.restockAsync(c.cStore.StoreID, c.cStock[pos].ProdID, num);
                //remove from cart
                c.cCart.remFrCart(c.cStock[pos]);
                Console.WriteLine($"[#]: Product {input} has been removed.");
            }
            else
            {
                Console.WriteLine($"[#]: Product {input} does not exist.");
            }



        TryAgain:
            if (c.cCart.dCart.Count < 1)
            {
                goto End;
            }
            Console.WriteLine("[#]: Would you like to remove another product?: ");
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
            Console.WriteLine("[#]: Cart is Empty");
        }

    }

}