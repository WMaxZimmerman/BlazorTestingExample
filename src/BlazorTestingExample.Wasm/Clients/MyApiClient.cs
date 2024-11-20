using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using BlazorTestingExample.Shared.Models;

namespace BlazorTestingExample.Wasm.Clients;

public interface IMyApiClient
{
    Task<UserDto> AddNewUser(UserDto user);
}

public class MyApiClient(HttpClient client): IMyApiClient
{
    public async Task<UserDto> AddNewUser(UserDto user)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/user/new", jsonContent);
        var newUser = (await response.Content.ReadFromJsonAsync<UserDto>())!;
        return newUser;
    }
}