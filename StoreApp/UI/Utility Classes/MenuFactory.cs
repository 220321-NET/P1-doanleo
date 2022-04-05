namespace UI
{
    public class MenuFactory
    {
        public IMenu gotoMenu(String menuType)
        {
            //For Dependency Injection
            string connect = File.ReadAllText("./connectionString.txt");
            IRepo _repo = new DataStorage(connect);
            IBL _bl = new BusinessL(_repo);
            switch (menuType)
            {
                case "main":
                    return new MainMenu();
                case "login":
                    return new LoginMenu(_bl);
                case "signup":
                    return new SignUpMenu(_bl);
                case "mainstore":
                    return new StoreMenu();
                case "item":
                    return new ItemMenu(_bl);
                case "stock":
                    return new ShowStock(_bl);
                case "add":
                    return new AddCart(_bl);
                case "rem":
                    return new RemCart(_bl);
                case "restock":
                    return new Restock(_bl);
                case "order":
                    return new OrderMenu(_bl);
                case "changestore":
                    return new ChangeStoreMenu(_bl);
                default:
                    return new MainMenu();
            }

        }
    }
}