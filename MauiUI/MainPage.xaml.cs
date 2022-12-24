namespace MauiUI;

public partial class MainPage : ContentPage
{
    private readonly IPlayerClient playerClient;


    private ObservableCollection<PlayerModel> players;

    public MainPage(IPlayerClient playerClient)
    {
        InitializeComponent();

        this.playerClient = playerClient;

        MessagingCenter.Subscribe<PlayerListComponent, PlayerModel>(this, MobileEventBusKey.DeletePlayerAsync, async (sender, arg) =>
        {
            await OnDelete(arg);
        });
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        players = new ObservableCollection<PlayerModel>(await playerClient.GetAllAsync());
        collectionView.ItemsSource = players;
    }

    private async void OnAddNew(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(PageRoutes.AddOrUpdatePage);
    }

    private async Task OnDelete(PlayerModel player)
    {
        if (player is null)
            return;

        await playerClient.DeleteAsync(player.Id);
        
        var index = players.IndexOf(player);
        players.RemoveAt(index);
    }

}