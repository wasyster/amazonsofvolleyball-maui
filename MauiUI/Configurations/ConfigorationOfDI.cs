namespace MauiUI.Configurations;

public static class ConfigorationOfDI
{
    public static void ConfigureDI(this MauiAppBuilder builder)
    {
        //services
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddMemoryCache();
        builder.Services.AddScoped<IMessenger, WeakReferenceMessenger>();


        builder.Services.AddTransient<IStorageService, StorageService>();
        builder.Services.AddTransient<IPlayerClient, PlayerClient>();
        builder.Services.AddTransient<IPositionClient, PositionClient>();

        //pages
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<AddOrUpdatePlayer>();
    }
}
