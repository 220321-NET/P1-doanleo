namespace Models
{
    public class Product
    {
        /*
        Product ID, Product Name, Cost
        */
        public int ProdID { get; set; }
        public string ProdName { get; set; } = "Apple";
        public double ProdCost { get; set; }
        public int ProdStock { get; set; } = 0;
    }
}