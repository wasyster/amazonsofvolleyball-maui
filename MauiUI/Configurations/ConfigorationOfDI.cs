﻿namespace MauiUI.Configurations;

public static class ConfigorationOfDI
{
    public static void ConfigureDI(this MauiAppBuilder builder)
    {
        //services
        builder.Services.AddSingleton<HttpClient>();

        builder.Services.AddTransient<IPlayerClient, PlayerClient>();

        //pages
        builder.Services.AddSingleton<MainPage>();
    }
}