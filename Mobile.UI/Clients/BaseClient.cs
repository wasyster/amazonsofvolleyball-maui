namespace Mobile.UI.Clients;

public abstract class BaseClient
{
    private readonly HttpClient httpClient;
    private readonly MobileAppSettings settings;

    private string BaseURL
    {
        get
        {
            return DeviceInfo.Platform == DevicePlatform.Android ?
                                          this.settings.AndroidBaseURL : 
                                          this.settings.IosBaseURL;
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

            var content = await SerializeResponse<T>(response.Content);
            return content;
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
            var uri = BuildUri(route, routParam);

            var response = await httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Faild to fetch data.");
            }

            var content = await SerializeResponse<T>(response.Content);
            return content;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private HttpClient BuildHttpClient(HttpClient httpClient)
    {
#if DEBUG
        var handler = new HttpsClientHandlerService();
        httpClient = new HttpClient(handler.GetPlatformMessageHandler());
#endif

        httpClient.BaseAddress = new Uri(BaseURL);

        httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
        httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
        httpClient.DefaultRequestHeaders.Add("Host", "amazonsofvolleyball");

        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));

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

    private async Task<T> SerializeResponse<T>(HttpContent content)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        using var stream = await content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<T>(stream, options);
        
        return result;
    }
}

