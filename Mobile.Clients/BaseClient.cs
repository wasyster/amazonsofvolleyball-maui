namespace Mobile.Clients;

public abstract class BaseClient
{
    private readonly HttpClient httpClient;
    private readonly MobileAppSettings settings;

    protected BaseClient(HttpClient httpClient, MobileAppSettings settings)
    {
        this.httpClient = httpClient;
        this.settings = settings;
    }

    /// <summary>
    /// Creates a simple get request
    /// </summary>
    /// <typeparam name="T">The return type</typeparam>
    /// <param name="route">The route part without the base url</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    protected async Task<T> SendGetRequestAsync<T>(string route)
    {
        try
        {
            var uri = new Uri(Path.Combine(settings.BaseURL, route));

            var response = await httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Faild to fetch data.");
            }

            var content = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(content);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// Creates a simple get request
    /// </summary>
    /// <typeparam name="T">The return type</typeparam>
    /// <param name="route">The route part without the base url</param>
    /// <param name="routParam">Rout parameter</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    protected async Task<T> SendGetRequestAsync<T>(string route, object routParam)
    {
        try
        {
            var uri = new Uri(Path.Combine(settings.BaseURL, route, $"{routParam}"));

            var response = await httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Faild to fetch data.");
            }

            var content = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(content);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

