namespace Models
{
    public class Cart
    {
        public Dictionary<Product, int> dCart { get; set; } = new Dictionary<Product, int>();

        public void addToCart(Product p, int value)
        {
            bool matched = false;
            foreach (var prod in dCart){
                if(prod.Key.ProdName == p.ProdName){
                    dCart[prod.Key] = dCart[prod.Key] + value;
                    matched = true;
                }
            }
            if (!matched)
            {
                dCart.Add(p, value);
            }
        }

        public void remFrCart(Product p)
        {
            bool matched = false;
            foreach (var prod in dCart){
                if(prod.Key.ProdName == p.ProdName){
                    dCart.Remove(prod.Key);
                    matched = true;
                }
            }
            if (!matched)
            {
                Console.WriteLine("[#]: Product not found in Cart");
            }
        }

        public void displayCart()
        {
            foreach (var prod in dCart)
            {
                Console.WriteLine($"[#]: {prod.Key.ProdName} | {prod.Value} x ${prod.Key.ProdCost} = ${String.Format("{0:0.00}", prod.Value * prod.Key.ProdCost)}");
            }
        }

    }
}