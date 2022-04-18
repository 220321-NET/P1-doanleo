namespace Models
{
    public class Order
    {
        public int OrderID { get; set; } = 0;
        public int OrderNum { get; set; } = 0;
        public int OrderAmount { get; set; } = 0;
        public double OrderTotalCost { get; set; } = 0;
        public string OrderProduct { get; set; } = "Apple";
        public string OrderStore { get; set; } = "The Apple Store";
        public string OrderCust { get; set; } = "Guest";

        public override string ToString()
        {
            string oString = $"OrderNum: {OrderNum} | Store Name: {OrderStore} | Customer Name: {OrderCust} | Product Name: {OrderProduct} | Number of Product {OrderAmount} | Order Cost {OrderTotalCost}";
            return oString;
        }

    }
}