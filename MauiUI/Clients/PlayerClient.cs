namespace MauiUI.Clients;

public class PlayerClient : BaseClient, IPlayerClient
{
    public PlayerClient(HttpClient httpClient, MobileAppSettings settings) : base(httpClient, settings)
    {}

    public async Task<List<PlayerModel>> GetAllAsync()
    {
        return await SendGetRequestAsync<List<PlayerModel>>(EndPoints.Player.GetAllAsync);
    }

    public async Task<bool> CreateAsync(PlayerModel player)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await SendDeleteRequestAsync(EndPoints.Player.DeleteAsync, id);
    }

    public async Task<PlayerModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PlayerModel>> PageAsync(int page)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(PlayerModel player)
    {
        throw new NotImplementedException();
    }
}