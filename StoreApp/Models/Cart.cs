namespace Models
{
    public class Cart
    {
        public Dictionary<int, Product> dCart { get; set; } = new Dictionary<int, Product>();
        public List<Product> cart { get; set; }= new List<Product>();

        public void addToCart(Product p, int value)
        {
            bool matched = false;
            foreach (var prod in dCart){
                if(prod.Key == p.ProdID){
                    prod.Value.ProdStock += value;
                    matched = true;
                }
            }
            if (!matched)
            {
                p.ProdStock = value;
                dCart.Add(p.ProdID, p);
            }
        }

        public void remFrCart(Product p)
        {
            bool matched = false;
            foreach (var prod in dCart){
                if(prod.Key == p.ProdID){
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
                Console.WriteLine($"[#]: {prod.Value.ProdName} | {prod.Value.ProdStock} x ${prod.Value.ProdCost} = ${String.Format("{0:0.00}", prod.Value.ProdStock * prod.Value.ProdCost)}");
            }
        }

    }
}