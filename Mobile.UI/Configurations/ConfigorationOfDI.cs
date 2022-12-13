namespace Mobile.UI.Configurations;

public static class ConfigorationOfDI
{
    public static void ConfigureDI(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<IPlayerClient, PlayerClient>();
        builder.Services.AddTransient<IHttpsClientHandlerService, HttpsClientHandlerService>();

    }
}
