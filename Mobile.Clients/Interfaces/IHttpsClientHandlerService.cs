namespace Mobile.Clients.Interfaces;

public interface IHttpsClientHandlerService
{
    HttpMessageHandler GetPlatformMessageHandler();
}
