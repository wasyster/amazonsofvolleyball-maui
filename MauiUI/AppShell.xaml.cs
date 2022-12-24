namespace MauiUI;
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute(PageRoutes.HomePage, typeof(MainPage));
        Routing.RegisterRoute(PageRoutes.DetailsPage, typeof(PlayerDetailsPage));
        Routing.RegisterRoute(PageRoutes.AddOrUpdatePage, typeof(AddOrUpdatePlayer));
    }
}