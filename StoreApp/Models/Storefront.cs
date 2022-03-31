namespace Models
{
    public class Storefront
    {
        /*
            Name, Store ID, Manager ID
        */
        public int StoreID { get; set; }
        public string StoreName { get; set; } = "default store";
        public string ManagerPass  { get; set; } = "1234";
    } 
}