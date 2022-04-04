namespace UI
{
    public class OrderMenu : IMenu
    {
        private readonly IBL _bl;
        public OrderMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            bool accessGranted = c.cCust.isEmployee;

            // if employee go to viewStoreOrders(string sort)
            // if customer go to viewCustOrders(string sort)
            // display with a default search then give sort options, 

            bool menuExit = false;
            do
            {
                int count = getOrderCount(accessGranted);
                //flag if ascending or desc, true = asc 
                bool ascDesc = true;
                //Menu Front End
                Console.WriteLine("\n\n\n\n\n======================================");
                Console.WriteLine("[#]: Select how to sort it");
                if (accessGranted) { Console.WriteLine($"[#]: Store: {c.cStore.StoreName} | Orders: {count}"); }
                if (!accessGranted) { Console.WriteLine($"[#]: User: {c.cCust.username} | Orders: {count}"); }
                Console.WriteLine("======================================");
                Console.WriteLine("[1]: Sort By Order Number");
                Console.WriteLine("[2]: Sort By Order Cost");
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
                        viewOrder(accessGranted, "OrderNum", ascDesc);
                        ascDesc = !ascDesc;
                        break;
                    case "2":
                        viewOrder(accessGranted, "OrderCost", ascDesc);
                        ascDesc = !ascDesc;
                        break;
                    case "3":
                        if (accessGranted)
                        {
                            viewOrder(accessGranted, "CustomerID", ascDesc);
                            ascDesc = !ascDesc;
                        }
                        if (!accessGranted)
                        {
                            viewOrder(accessGranted, "StoreID", ascDesc);
                            ascDesc = !ascDesc;
                        }
                        break;
                    case "4":
                        if (accessGranted) { new MenuFactory().gotoMenu("changestore").Start(); }
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
        private void viewOrder(bool isE, string sort, bool ascDesc)
        {
            string sorted = "/\\";
            if (!ascDesc){sorted = "\\/";}
            Console.WriteLine($"[#]: Sorting by {sort}{sorted}");
            List<Order> oList = new List<Order>();
            if(isE){
                oList = _bl.GetStoreOrders(c.cStore, sort, ascDesc);
            } else {
                oList = _bl.GetCustOrders(c.cCust, sort, ascDesc);
            }
            foreach(Order o in oList){
                Console.WriteLine(o);
            }
            Console.ReadKey();
        }
        private int getOrderCount(bool isE)
        {
            int count = 0;
            string sorter = "id";
            if (isE)
            {
                count = _bl.GetStoreOrders(c.cStore, sorter, false).Count;
            }
            else
            {
                count = _bl.GetCustOrders(c.cCust, sorter, false).Count;
            }
            return count;
        }
    }
}