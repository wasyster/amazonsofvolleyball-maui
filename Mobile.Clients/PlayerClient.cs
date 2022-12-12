namespace Mobile.Clients;

public class PlayerClient : BaseClient, IPlayerClient
{
    public PlayerClient(HttpClient httpClient, IHttpsClientHandlerService httpClientService, IOptions<MobileAppSettings> settings) :
           base(httpClient, httpClientService, settings.Value)
    {}

    public async Task<List<PlayerModel>> GetAllAsync()
    {
        var path = @"players/getAllAsync";
        return await SendGetRequestAsync<List<PlayerModel>>(path);
    } 
}