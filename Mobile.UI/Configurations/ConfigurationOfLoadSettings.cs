namespace Mobile.UI.Configurations;

public static class ConfigurationOfLoadSettings
{
    public static void ConfigurationSettings(this MauiAppBuilder builder)
    {
#if DEBUG
        var file = "Mobile.UI.Development.json";
#else
        var file = "Mobile.UI.Production.json";
#endif

        using var stream = FileSystem.OpenAppPackageFileAsync(file).Result;

        var config = new ConfigurationBuilder().AddJsonStream(stream)
                                               .Build();

        builder.Configuration.AddConfiguration(config);
    }
}
