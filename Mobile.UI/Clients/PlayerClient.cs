namespace Mobile.UI.Clients;

public class PlayerClient : BaseClient, IPlayerClient
{
    public PlayerClient(IHttpsClientHandlerService httpClientService, IOptions<MobileAppSettings> settings) : base(httpClientService, settings.Value)
    {}

    public async Task<List<PlayerModel>> GetAllAsync()
    {
        var path = @"players/getAllAsync";
        return await SendGetRequestAsync<List<PlayerModel>>(path);
    } 
}