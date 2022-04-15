namespace UI
{
    public class ChangeStoreMenu : IMenu
    {
        private readonly HttpService _http;
        public ChangeStoreMenu(HttpService http){
            _http = http;
        }
        public async Task Start()
        {
            //creates a list of stores, puts a flag on the store id you're at rn
            List<Storefront> stores = await _http.GetStoresAsync();
            Console.WriteLine("======================================");
            Console.WriteLine($"[#]: You are at: {c.cStore.StoreName}");
            Console.WriteLine("[#]: Here is a list of our stores");
            Console.WriteLine("======================================");
            foreach (Storefront store in stores)
            {
                string output = $"[#]: {store.StoreName}";
                if (store.StoreName == c.cStore.StoreName)
                {
                    output += " <-- YOU ARE HERE";
                }
                Console.WriteLine(output);
            }
        TryAgain:
            Console.WriteLine("[#]: Enter the name of the store you would like to go to");
            string? input = Console.ReadLine();
            bool found = false;
            foreach (Storefront store in stores)
            {
                if (input == store.StoreName)
                {
                    found = true;
                    Console.WriteLine($"[#]: Moving to {store.StoreName}.");
                    c.cStore = store;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("[#]: Store not found");
                goto TryAgain;
            }
        }
    }
}