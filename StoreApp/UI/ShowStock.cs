namespace UI
{
    public class ShowStock : IMenu
    {
        private readonly IBL _bl;
        public ShowStock(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            c.cStock = _bl.GetStock(c.cStore);
            Console.WriteLine("======================================");
            Console.WriteLine($"Name: {String.Format("{0, 6}", c.cStock[0].ProdName)}|Name: {String.Format("{0, 6}", c.cStock[1].ProdName)}|Name: {String.Format("{0, 6}", c.cStock[2].ProdName)}");
            Console.WriteLine($"Price: ${String.Format("{0:0.00}", c.cStock[0].ProdCost)}|Price: ${String.Format("{0:0.00}", c.cStock[1].ProdCost)}|Price: ${String.Format("{0:0.00}", c.cStock[2].ProdCost)}");
            Console.WriteLine($"Stock: {String.Format("{0, -5:00000}", c.cStock[0].ProdStock)}|Stock: {String.Format("{0, -5:00000}", c.cStock[1].ProdStock)}|Stock: {String.Format("{0, -5:00000}", c.cStock[2].ProdStock)}");
            Console.WriteLine("    [01]    |    [02]    |    [03]    ");
            Console.WriteLine("======================================");
            Console.WriteLine($"Name: {String.Format("{0, 6}", c.cStock[3].ProdName)}|Name: {String.Format("{0, 6}", c.cStock[4].ProdName)}|Name: {String.Format("{0, 6}", c.cStock[5].ProdName)}");
            Console.WriteLine($"Price: ${String.Format("{0:0.00}", c.cStock[3].ProdCost)}|Price: ${String.Format("{0:0.00}", c.cStock[4].ProdCost)}|Price: ${String.Format("{0:0.00}", c.cStock[5].ProdCost)}");
            Console.WriteLine($"Stock: {String.Format("{0, -5:00000}", c.cStock[3].ProdStock)}|Stock: {String.Format("{0, -5:00000}", c.cStock[4].ProdStock)}|Stock: {String.Format("{0, -5:00000}", c.cStock[5].ProdStock)}");
            Console.WriteLine("    [04]    |    [05]    |    [06]    ");
            Console.WriteLine("======================================");
        }
    }
}