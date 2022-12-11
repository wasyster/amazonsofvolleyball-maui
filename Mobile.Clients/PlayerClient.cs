namespace Mobile.Clients;

public class PlayerClient : BaseClient, IPlayerClient
{
    public PlayerClient(HttpClient httpClient, IOptions<MobileAppSettings> settings): base(httpClient, settings.Value)
    {}

    public async Task<List<PlayerModel>> GetAllAsync()
    {
        var path = @"players/getAllAsync";
        return await SendGetRequestAsync<List<PlayerModel>>(path);
    } 
}