namespace Backend.Infrastructure.Clients.Services;

public interface IPlayerClient
{
    Task<bool> CreateAsync(PlayerModel player);
    Task<bool> DeleteAsync(int id);
    Task<List<PlayerModel>> GetAllAsync();
    Task<PlayerModel> GetByIdAsync(int id);
    Task<List<PlayerModel>> PageAsync(int page = 0);
    Task<bool> UpdateAsync(PlayerModel player);
}
