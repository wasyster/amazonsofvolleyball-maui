namespace MauiUI.Clients;

public class PlayerClient : BaseClient, IPlayerClient
{
    public PlayerClient(HttpClient httpClient, MobileAppSettings settings) : base(httpClient, settings)
    {}

    public async Task<List<PlayerModel>> GetAllAsync()
    {
        var path = @"players/get-all";
        return await SendGetRequestAsync<List<PlayerModel>>(path);
    }

    Task IPlayerService.CreateAsync(PlayerModel player)
    {
        throw new NotImplementedException();
    }

    Task IPlayerService.DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<PlayerModel> IPlayerService.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<List<PlayerModel>> IPlayerService.PageAsync(int page)
    {
        throw new NotImplementedException();
    }

    Task IPlayerService.UpdateAsync(PlayerModel player)
    {
        throw new NotImplementedException();
    }
}