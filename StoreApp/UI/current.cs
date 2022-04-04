namespace UI
{
    public static class c
    {
        public static Customer cCust {get; set;} = new Customer();
        public static List<Product> cCart {get; set;} = new List<Product>();
        public static List<Product> cStock {get; set;} = new List<Product>();
        public static Storefront cStore {get; set;} = new Storefront();
        //stores the current things to be able to be called later

    }
}