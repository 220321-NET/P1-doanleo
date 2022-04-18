using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace UI;

public class HttpService
{
    private readonly string _apiBaseURL = " http://localhost:5104/api/";

    private HttpClient client = new HttpClient();

    public HttpService()
    {
        client.BaseAddress = new Uri(_apiBaseURL);
    }

    public async Task<List<Storefront>> GetStoresAsync()
    {
        List<Storefront> stores = new List<Storefront>();
        try
        {
            stores = await JsonSerializer.DeserializeAsync<List<Storefront>>(await client.GetStreamAsync("Stores")) ?? new List<Storefront>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Couldn't Retrieve Stores");
        }
        return stores;
    }
    public async Task<List<Product>> GetStockAsync(int id)
    {
        List<Product> stock = new List<Product>();
        try
        {
            stock = await JsonSerializer.DeserializeAsync<List<Product>>(await client.GetStreamAsync($"Inventory/{id}")) ?? new List<Product>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Couldn't Retrieve Stock");
        }
        return stock;
    }

    public class OrderDTO
    {
        public int id { get; set; }
        public string sort { get; set; } = "";
        public bool ascDesc { get; set; }
    }
    public async Task<List<Order>> GetStoreOrdersAsync(int sID, string sort, bool ascDesc)
    {
        List<Order> orders = new List<Order>();
        try
        {
            orders = await JsonSerializer.DeserializeAsync<List<Order>>(await client.GetStreamAsync($"Orders/Store/{sID}/{sort}/{ascDesc}")) ?? new List<Order>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Couldn't Retrieve Store's Orders");
        }
        return orders;
    }

    public async Task<List<Order>> GetCustOrdersAsync(int cID, string sort, bool ascDesc)
    {
        List<Order> orders = new List<Order>();
        try
        {
            orders = await JsonSerializer.DeserializeAsync<List<Order>>(await client.GetStreamAsync($"Orders/Customer/{cID}/{sort}/{ascDesc}")) ?? new List<Order>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Couldn't Retrieve Customer's Orders");
        }
        return orders;
    }

    public async Task<Customer> addCustomer(Customer user)
    {
        Customer cust = user;
        string sUser = JsonSerializer.Serialize(cust);
        StringContent scUser = new StringContent(sUser, Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage resp = await client.PutAsync("User", scUser);
            resp.EnsureSuccessStatusCode();
            cust = await JsonSerializer.DeserializeAsync<Customer>(await resp.Content.ReadAsStreamAsync()) ?? new Customer(); ;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Couldn't Add Customer");
        }
        return cust;
    }

    public async Task<Customer> authenticate(Customer user)
    {
        Customer cust = user;

        string sUser = JsonSerializer.Serialize(cust);
        StringContent scUser = new StringContent(sUser, Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage resp = await client.PostAsync("User", scUser);
            resp.EnsureSuccessStatusCode();
            cust = await JsonSerializer.DeserializeAsync<Customer>(await resp.Content.ReadAsStreamAsync()) ?? new Customer(); ;
        }
        catch (HttpRequestException)
        {
            //Console.WriteLine("Couldn't Verify Customer");
            throw;
        }
        return cust;
    }

    public async Task addOrderAsync(int sID, int cID, Dictionary<int, Product> dCart)
    {
        string sCart = JsonSerializer.Serialize(dCart);
        StringContent stringcontent = new StringContent(sCart, Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage resp = await client.PostAsync($"Orders/{sID}/{cID}", stringcontent);
            resp.EnsureSuccessStatusCode();
            
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Couldn't Complete Order");
        }
    }
    class Stock
    {
        //used for restock and add to cart functions
        public int sID { get; set; }
        public int pID { get; set; }
        public int howMany { get; set; }
    }
    public async Task restockAsync(int sID, int pID, int howMany)
    {
        Stock stock = new Stock();
        stock.sID = sID;
        stock.pID = pID;
        stock.howMany = howMany;
        string sStock = JsonSerializer.Serialize(stock);
        StringContent stringcontent = new StringContent(sStock, Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage resp = await client.PutAsync("Inventory/restock", stringcontent);
            resp.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Couldn't Restock");
        }
    }

    public async Task addToCartAsync(int sID, int pID, int howMany)
    {
        Stock stock = new Stock();
        stock.sID = sID;
        stock.pID = pID;
        stock.howMany = howMany;
        string sStock = JsonSerializer.Serialize(stock);
        StringContent stringcontent = new StringContent(sStock, Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage resp = await client.PutAsync("Inventory/addToCart", stringcontent);
            resp.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Couldn't Add to Cart");
        }
    }
}
