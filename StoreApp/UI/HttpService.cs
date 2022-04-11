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

    public async Task<List<Storefront>> GetStoresAsync()
    {
        List<Storefront> stores = new List<Storefront>();
        try{
        stores = await JsonSerializer.DeserializeAsync<List<Storefront>>(await client.GetStreamAsync("Stores")) ?? new List<Storefront>();
        }
        catch (HttpRequestException ex){
            Console.WriteLine("Couldn't Retrieve Stores");
        }
        return stores;
    }
    public async Task<List<Product>> GetStockAsync()
    {
        List<Product> stock = new List<Product>();
        try{
        stock = await JsonSerializer.DeserializeAsync<List<Product>>(await client.GetStreamAsync("Stock")) ?? new List<Product>();
        }
        catch (HttpRequestException ex){
            Console.WriteLine("Couldn't Retrieve Stores");
        }
        return stock;
    }
}