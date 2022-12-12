namespace Backend.Infrastructure.Interfaces.Clients;

public interface IHttpsClientHandlerService
{
    HttpMessageHandler GetPlatformMessageHandler();
}
