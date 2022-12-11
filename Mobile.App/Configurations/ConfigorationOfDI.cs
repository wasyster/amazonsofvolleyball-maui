namespace Mobile.UI.Configurations;

public static class ConfigorationOfDI
{
    public static void ConfigureDI(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<IPlayerClient, PlayerClient>();

        // Add useful interface for accessing the HttpContext outside a controller.
        builder.Services.AddHttpClient();
    }
}
