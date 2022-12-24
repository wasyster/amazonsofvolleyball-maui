namespace Backend.Infrastructure.Clients.Services;

public interface IPositionClient
{
    Task<List<PositionModel>> GetAllAsync();
}
