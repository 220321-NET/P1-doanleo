namespace UI
{
    public class MenuFactory
    {
        IMenu cMenu = new MainMenu();
        public IMenu gotoMenu(String menuType)
        {
            switch (menuType)
            {
                case "main":
                    return new MainMenu();
                case "login":
                    return new LoginMenu();
                case "signup":
                    return new SignUpMenu();
                case "mainstore":
                    return new StoreMenu();
                case "item":
                    return new ItemMenu();
                case "stock":
                    return new ShowStock();
                case "add":
                    return new AddCart();
                case "rem":
                    return new RemCart();
                case "restock":
                    return new Restock();
                case "order":
                    return new OrderMenu();
                case "changestore":
                    return new ChangeStoreMenu();
                default:
                    return new MainMenu();
            }

        }
    }
}