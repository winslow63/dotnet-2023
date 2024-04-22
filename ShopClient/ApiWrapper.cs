using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopClient;
public class ApiWrapper
{
    private readonly ApiClient _client;
    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var serverUrl = configuration.GetSection("ServerUrl").Value;

        _client = new ApiClient(serverUrl, new HttpClient());
    }


    public async Task<ICollection<TSGetDto>> GetCarAsync()
    {
        return await _client.TSsAllAsync();
    }

    public async Task<TSGetDto> AddCarAsync(TSPostDto product)
    {
        return await _client.TSsPOSTAsync(product);
    }

    public async Task UpdateCarAsync(int id, TSPostDto product)
    {
        await _client.TSsPUTAsync(id, product);
    }

    public async Task DeleteCarAsync(int id)
    {
        await _client.TSsDELETEAsync(id);
    }

    ///---------------------------------
    public async Task<ICollection<ClientGetDto>> GetClientAsync()
    {
        return await _client.ClientsAllAsync();
    }

    public async Task<ClientGetDto> AddClientAsync(ClientPostDto product)
    {
        return await _client.ClientsPOSTAsync(product);
    }

    public async Task UpdateClientAsync(int id, ClientPostDto product)
    {
        await _client.ClientsPUTAsync(id, product);
    }

    public async Task DeleteClientAsync(int id)
    {
        await _client.ClientsDELETEAsync(id);
    }
    ///---------------------------------
    public async Task<ICollection<CourierGetDto>> GetCourierAsync()
    {
        return await _client.CouriersAllAsync();
    }

    public async Task<CourierGetDto> AddCourierAsync(CourierPostDto product)
    {
        return await _client.CouriersPOSTAsync(product);
    }

    public async Task UpdateCourierAsync(int id, CourierPostDto product)
    {
        await _client.CouriersPUTAsync(id, product);
    }

    public async Task DeleteCourierAsync(int id)
    {
        await _client.CouriersDELETEAsync(id);
    }

    ///---------------------------------
    public async Task<ICollection<ShopGetDto>> GetShopAsync()
    {
        return await _client.ShopsAllAsync();
    }

    public async Task<ShopGetDto> AddShopAsync(ShopPostDto product)
    {
        return await _client.ShopsPOSTAsync(product);
    }

    public async Task UpdateShopAsync(int id, ShopPostDto product)
    {
        await _client.ShopsPUTAsync(id, product);
    }

    public async Task DeleteShopAsync(int id)
    {
        await _client.ShopsDELETEAsync(id);
    }


}
