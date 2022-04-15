namespace UI
{
    public class ShowStock : IMenu
    {
        private readonly HttpService _http;
        public ShowStock(HttpService http)
        {
            _http = http;
        }
        public async Task Start()
        {
            c.cStock = await _http.GetStockAsync(c.cStore.StoreID);
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