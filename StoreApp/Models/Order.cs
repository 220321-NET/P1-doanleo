namespace Models
{
    public class Order
    {
        /*
        Order ID, (Product ID, Product Name, Cost),Customer ID, Total Cost
        */
        public int OrderID {get ; set;}
        public int OrderNum {get ; set;}
        public int OrderAmount {get ; set;}
        public double OrderTotalCost {get ; set;}
        public int OrderProduct {get ; set;}
        public int OrderStore {get ; set;}
        public int OrderCust {get ; set;}


    }
}