namespace Mobile.UI.Clients;

public abstract class BaseClient
{
    private readonly HttpClient httpClient;
    private readonly MobileAppSettings settings;

    private string BaseURL
    {
        get
        {
            return DeviceInfo.Platform == DevicePlatform.Android ? this.settings.AndroidBaseURL : this.settings.IosBaseURL;
        }
    }

    protected BaseClient(HttpClient httpClient, MobileAppSettings settings)
    {
        this.settings = settings;

        this.httpClient = BuildHttpClient(httpClient);
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
            var uri = BuildUri(route);

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
            var uri = BuildUri(route, $"{routParam}");

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

    private HttpClient BuildHttpClient(HttpClient httpClient)
    {
#if DEBUG
        var httpClientService = new HttpsClientHandlerService();
        var handler = httpClientService.GetPlatformMessageHandler();
        if (handler != null)
            httpClient = new HttpClient(handler);
        else
            httpClient = new HttpClient();
#else
            httpClient = new HttpClient();
#endif

        return httpClient;
    }

    private Uri BuildUri(string route)
    { 
        return new Uri(Path.Combine(BaseURL, settings.ApiVersion, route));
    }

    private Uri BuildUri(string route, object routParam)
    {
        return new Uri(Path.Combine(BaseURL, settings.ApiVersion, route, $"{routParam}"));
    }
}

