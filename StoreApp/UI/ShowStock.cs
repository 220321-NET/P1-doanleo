namespace UI
{
    public class ShowStock : IMenu
    {
        public void Start()
        {
            Console.WriteLine("======================================");
            Console.WriteLine($"Name: Fuji  |Name: Gala  |Name: Mac   ");
            Console.WriteLine($"Price: $0.00|Price: $0.00|Price: $0.00");
            Console.WriteLine($"Stock: 00000|Stock: 00000|Stock: 00000");
            Console.WriteLine("    [01]    |    [02]    |    [03]    ");
            Console.WriteLine("======================================");
            Console.WriteLine($"Name: Granny|Name: HoneyC|Name: RedDel");
            Console.WriteLine($"Price: $0.00|Price: $0.00|Price: $0.00");
            Console.WriteLine($"Stock: 00000|Stock: 00000|Stock: 00000");
            Console.WriteLine("    [04]    |    [05]    |    [06]    ");
            Console.WriteLine("======================================");
        }
    }
}