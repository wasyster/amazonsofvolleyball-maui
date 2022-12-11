namespace Backend.Infrastructure.Interfaces.Clients;

public interface IPlayerClient
{
    Task<List<PlayerModel>> GetAllAsync();
}
