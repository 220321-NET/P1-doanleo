namespace Models
{
    public class Product
    {
        /*
        Product ID, Product Name, Cost
        */
        public int ID { get; set; }
        public string name { get; set; }
        public double cost { get; set; }

        public Product(){
            ID = 0;
            name = "product";
            cost = 0.01;
        }

    }
}