class Customer
{
    //Properties
    public string Name { get; set; }
    
    // Constructor
    public Customer()
    {
        Name = "name";
    }
    //Methods
    /*
        Name, Assigned ID
    
    */
}

class Employee{
    /*
        Name, Assigned ID, Manager?
    */
}

class StoreFront{
    /*
        Name, Store ID, Manager ID
    */
}

class Order{
    /*
        Order ID, (Product ID, Product Name, Cost),Customer ID, Total Cost
    */
}

class Product{
    /*
        Product ID, Product Name, Cost
    */
}

class Program
{
    static void Main()
    {
        /*
        Menu Functions
        Sign Up -> Create new Customer
        Log in -> check list for customer
        Employee Login -> check list of employees, enables certain options (employee level 1 or 2 for manager)

        If Customer,
        View Inventory 
            -> Select Location
                -> Add to Cart
                -> Check Out
                -> Remove From Cart
                -> Wishlist and Returns if time permits
        View Order History
            -> Sort By (Both Ways)
                Location
                Date
                Cost
                    -> Display Order Details
        If Employee,
        View Inventory 
            -> Select Location
                -> Manager Check, Allow Restocking
        View Order History
            -> Sort By (Both Ways)
                Location
                Date
                Cost
                    -> Display Order Details
        */
    }
}