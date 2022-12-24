using Backend.Models.Common;

namespace MauiUI.Components;

public partial class PlayerListComponent : ContentView
{
    public static readonly BindableProperty PlayerProperty = BindableProperty.Create(nameof(Player), typeof(PlayerModel), typeof(PlayerListComponent), null);

    public PlayerModel Player
    {
        get => (PlayerModel)GetValue(PlayerProperty);
        set => SetValue(PlayerProperty, value);
    }

    public PlayerListComponent()
	{
		InitializeComponent();
    }

    private async void OnTappHandler(object sender, TappedEventArgs args)
    {
        await Navigation.PushAsync(new PlayerDetailsPage
        {
            BindingContext = Player
        });
    }

    private void OnDeleteEventHandler(object sender, EventArgs e)
    {
        MessagingCenter.Send<PlayerListComponent, PlayerModel>(this, MobileEventBusKey.DeletePlayerAsync, Player);
    }
}