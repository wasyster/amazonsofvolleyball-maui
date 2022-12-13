namespace Mobile.UI.Interfaces;

public interface IPlayerClient
{
    Task<List<PlayerModel>> GetAllAsync();
}
