namespace UI
{
    public class OrderMenu : IMenu
    {
        public void Start()
        {
            bool accessGranted = c.cCust.isEmployee;

            // if employee go to viewStoreOrders(string sort)
            // if customer go to viewCustOrders(string sort)
            // display with a default search then give sort options, 

            bool menuExit = false;
            do{
                Console.WriteLine("I forgot");
                menuExit = true;
            }while(!menuExit);

            /*
                View Order History (checks if customer or employee, 
                    this method changes depending on which)
                    -> Sort By (Both Ways)
                        Location
                        Date
                        Cost
                    -> Display Order Details
            */
        }
    }
}