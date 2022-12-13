namespace Mobile.Clients.Interfaces;

public interface IPlayerClient
{
    Task<List<PlayerModel>> GetAllAsync();
}
