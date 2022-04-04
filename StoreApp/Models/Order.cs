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
        public string OrderProduct {get ; set;} = "Apple";
        public string OrderStore {get ; set;} = "Apple Store";
        public string OrderCust {get ; set;} = "Guest";

        public override string ToString()
        {
            string oString = $"OrderNum: {OrderNum} | Store Name: {OrderStore} | Customer Name: {OrderCust} | Product Name: {OrderProduct} | Number of Product {OrderAmount} | Order Cost {OrderTotalCost}";
            return oString;
        }

    }
}