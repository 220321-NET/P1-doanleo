namespace UI
{
    public class ChangeStoreMenu : IMenu
    {
        public void Start()
        {
            //creates a list of stores, puts a flag on the store id you're at rn
            List<Storefront> stores = new List<Storefront>();
            //REMOVE THIS CODE LATER
            Storefront temp1 = new Storefront();
            Storefront temp2 = new Storefront();
            Storefront temp3 = new Storefront();
            Storefront temp4 = new Storefront();
            temp1.StoreName = "test 1";
            temp2.StoreName = "test 2";
            temp3.StoreName = "test 3";
            temp4.StoreName = "Apple Superstore";
            stores.Add(temp1);
            stores.Add(temp2);
            stores.Add(temp4);
            stores.Add(temp3);

            Console.WriteLine("\n\n\n\n\n======================================");
            Console.WriteLine($"[#]: You are at: {c.cStore.StoreName}");
            Console.WriteLine("[#]: Here is a list of our stores");
            Console.WriteLine("======================================");
            foreach (Storefront store in stores)
            {
                string output = $"[#]: {store.StoreName}";
                if (store.StoreName == c.cStore.StoreName)
                {
                    output += "<-- YOU ARE HERE";
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