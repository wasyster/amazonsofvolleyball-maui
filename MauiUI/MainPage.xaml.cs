using Backend.Models.Messages;
using CommunityToolkit.Mvvm.Messaging;

namespace MauiUI;

public partial class MainPage : ContentPage
{
    private readonly IPlayerClient playerClient;

    private ObservableCollection<PlayerModel> players;

    public MainPage(IPlayerClient playerClient)
    {
        InitializeComponent();

        this.playerClient = playerClient;

        SubScribeOnDelte();
    }

    private void SubScribeOnDelte()
    {
        WeakReferenceMessenger.Default.Register<DeletePlayerMessage>(this, (recepient, messaage) =>
        {
            OnDelete(messaage);
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

    private async Task OnDelete(DeletePlayerMessage message)
    {
        if (message is null)
            return;

        var player = players.FirstOrDefault(x => x.Id == message.Id);

        if (player is null)
            return;

        await playerClient.DeleteAsync(message.Id);
        
        var index = players.IndexOf(player);
        players.RemoveAt(index);
    }

}