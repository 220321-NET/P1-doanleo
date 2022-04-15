namespace UI
{
    public class MenuFactory
    {
        public IMenu gotoMenu(String menuType)
        {
            // //For Dependency Injection
            string connect = File.ReadAllText("./connectionString.txt");
            IRepo _repo = new DataStorage(connect);
            IBL _bl = new BusinessL(_repo);
            HttpService http = new HttpService();
            switch (menuType)
            {
                case "main":
                    return new MainMenu();
                case "login":
                    return new LoginMenu(http);
                case "signup":
                    return new SignUpMenu(http);
                case "mainstore":
                    return new StoreMenu();
                case "item":
                    return new ItemMenu(http);
                case "stock":
                    return new ShowStock(http);
                case "add":
                    return new AddCart(http);
                case "rem":
                    return new RemCart(http);
                case "restock":
                    return new Restock(http);
                case "order":
                    return new OrderMenu(http);
                case "changestore":
                    return new ChangeStoreMenu(http);
                default:
                    return new MainMenu();
            }

        }
    }
}