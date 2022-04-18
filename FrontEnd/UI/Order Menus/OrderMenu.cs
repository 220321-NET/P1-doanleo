namespace UI
{
    public class OrderMenu : IMenu
    {
        private readonly HttpService _http;
        public OrderMenu(HttpService http)
        {
            _http = http;
        }
        public async Task Start()
        {
            bool accessGranted = c.cCust.isEmployee;

            // if employee go to viewStoreOrders(string sort)
            // if customer go to viewCustOrders(string sort)
            // display with a default search then give sort options, 
            bool onnum = true;
            bool otot = true;
            bool cs = true;
            bool menuExit = false;
            do
            {
                int count = getOrderCount(accessGranted).Result;
                if (count == 0)
                {
                    Console.WriteLine("[#]: You have no Orders");
                    menuExit = true;
                }
                //flag if ascending or desc, true = asc 

                //Menu Front End
                Console.WriteLine("======================================");
                Console.WriteLine($"[#]: How do you want to Sort By?");
                if (accessGranted) { Console.WriteLine($"[#]: Store: {c.cStore.StoreName} | Orders: {count}"); }
                if (!accessGranted) { Console.WriteLine($"[#]: User: {c.cCust.username} | Orders: {count}"); }
                Console.WriteLine("======================================");
                Console.WriteLine("[1]: Sort By Order Number");
                Console.WriteLine("[2]: Sort By Order Total");
                if (accessGranted) { Console.WriteLine("[3]: Sort By Customer"); }
                if (!accessGranted) { Console.WriteLine("[3]: Sort By Store"); }
                if (accessGranted) { Console.WriteLine("[4]: Change Store"); }
                if (accessGranted) { Console.WriteLine("[5]: View own Orders"); }
                if (!accessGranted && c.cCust.isEmployee) { Console.WriteLine("[5]: View Store Orders"); }
                Console.WriteLine("[x]: Exit");
                Console.WriteLine("======================================");

                //Input
                string? input = Console.ReadLine();

                //Menu Back End
                switch (input)
                {
                    case "1":
                        await viewOrder(accessGranted, "OrderNum", onnum);
                        onnum = !onnum;
                        otot = true;
                        cs = true;
                        break;
                    case "2":
                        await viewOrder(accessGranted, "OrderTotal", otot);
                        onnum = true;
                        otot = !otot;
                        cs = true;
                        break;
                    case "3":
                        if (accessGranted)
                        {
                            await viewOrder(accessGranted, "CustomerID", cs);
                            onnum = true;
                            otot = true;
                            cs = !cs;
                        }
                        if (!accessGranted)
                        {
                            await viewOrder(accessGranted, "StoreID", cs);
                            onnum = true;
                            otot = true;
                            cs = !cs;
                        }
                        break;
                    case "4":
                        if (accessGranted) { await new MenuFactory().gotoMenu("changestore").Start(); }
                        break;
                    case "5":
                        if (c.cCust.isEmployee) { accessGranted = !accessGranted; }
                        break;
                    case "x":
                        menuExit = true;
                        break;
                    default:
                        Console.WriteLine("[#]: Oops, Invalid Input! Try Again");
                        break;
                }
            } while (!menuExit);

            /*
                View Order History (checks if customer or employee, 
                    this method changes depending on which)
                    -> Sort By (Both Ways)
                        Location
                        Date
                        Cost
                    -> Display Order Details
                    which store do you want to check?
            */
        }
        private async Task viewOrder(bool isE, string sort, bool ascDesc)
        {
            string sorted = "/\\";
            if (!ascDesc) { sorted = "\\/"; }
            Console.WriteLine($"[#]: Sorting by {sort} {sorted}");
            sort = "Orders." + sort;
            List<Order> oList = new List<Order>();
            if (isE)
            {
                oList = await _http.GetStoreOrdersAsync(c.cStore.StoreID, sort, ascDesc);
            }
            else
            {
                oList = await _http.GetCustOrdersAsync(c.cCust.CustID, sort, ascDesc);
            }
            foreach (Order o in oList)
            {
                Console.WriteLine(o);
            }
        }
        private async Task<int> getOrderCount(bool isE)
        {
            List<Order> count = new List<Order>();
            string sorter = "Orders.OrderID";
            if (isE)
            {
                count = await _http.GetStoreOrdersAsync(c.cStore.StoreID, sorter, false);
            }
            else
            {
                count = await _http.GetCustOrdersAsync(c.cCust.CustID, sorter, false);
            }
            return count.Count;
        }
    }
}