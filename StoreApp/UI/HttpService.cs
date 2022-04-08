using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace UI;

public class HttpService
{
    private readonly string _apiBaseURL = " https://localhost:7223/api/";

    private HttpClient client = new HttpClient();

    public HttpService()
    {
        client.BaseAddress = new Uri(_apiBaseURL);
    }

    public List<Storefront> GetStores()
    {
        List<Storefront> stores = new List<Storefront>();
        //stores = JsonSerializer.Deserialze

        return stores;
    }
    public Customer addCustomer(Customer cust)
    {

        return new Customer();
    }
}