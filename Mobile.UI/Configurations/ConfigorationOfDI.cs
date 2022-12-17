namespace Mobile.UI.Configurations;

public static class ConfigorationOfDI
{
    public static void ConfigureDI(this MauiAppBuilder builder)
    {
        //services
        builder.Services.AddHttpClient<IActionContextAccessor, ActionContextAccessor>();

        builder.Services.AddTransient<IPlayerClient, PlayerClient>();
        builder.Services.AddTransient<IHttpsClientHandlerService, HttpsClientHandlerService>();

        //pages
        builder.Services.AddSingleton<MainPage>();
    }
}
