namespace Mobile.UI.Clients;

public class PlayerClient : BaseClient, IPlayerClient
{
    public PlayerClient(HttpClient httpClient, MobileAppSettings settings) : base(httpClient, settings)
    {}

    public async Task<List<PlayerModel>> GetAllAsync()
    {
        var path = @"players/get-all";
        return await SendGetRequestAsync<List<PlayerModel>>(path);
    } 
}