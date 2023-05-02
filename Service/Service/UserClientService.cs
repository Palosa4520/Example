using Service.Interface;
using System.Net.Http.Headers;

namespace Service.Service;

public class UserClientService : IUserClientService
{
    // Constants
    const string HttpClientName = "UserClient";

    // Fields
    private string? _ApiBaseUrl = "http://localhost:3000";

    // Services
    private readonly IHttpClientFactory _httpClientFactory;

    // CTOR
    public UserClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // Implementations
    public async Task<string?> SearchUsersAsync(CancellationToken cancellationToken)
    {
        return await GetAsync("SearchUser", null, cancellationToken);
    }

    public async Task<string?> SearchOrderAsync(CancellationToken cancellationToken)
    {
        return await GetAsync("SearchOrder", null, cancellationToken);
    }

    public async Task<string?> SearchRoleAsync(CancellationToken cancellationToken)
    {
        return await GetAsync("SearchRole", null, cancellationToken);
    }

    // Private methode
    private async Task<string?> GetAsync(string uRL, object? payload, CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient(HttpClientName);
        var result = await httpClient.GetAsync($"{_ApiBaseUrl!.Trim('/')}/{uRL}?{payload?.ToQueryString()}", cancellationToken);
        var stringContent = await result.Content.ReadAsStringAsync(cancellationToken);
        if (!result.IsSuccessStatusCode)
            throw new Exception("Error from external service!");
        return stringContent;
    }
}
