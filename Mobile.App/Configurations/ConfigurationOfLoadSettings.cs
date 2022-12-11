namespace Mobile.UI.Configurations;

public static class ConfigurationOfLoadSettings
{
    public static void ConfigurationSettings(this MauiAppBuilder builder)
    {
        var assembly = Assembly.GetExecutingAssembly();

#if DEBUG
        using var stream = assembly.GetManifestResourceStream("appsettings.Development.json");
#else
        using var stream = assembly.GetManifestResourceStream("appsettings.Production.json");
#endif

        var config = new ConfigurationBuilder().AddJsonStream(stream).Build();

        builder.Configuration.AddConfiguration(config);
    }
}
