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
        await Navigation.PushModalAsync(new PlayerDetailsModal
        {
            BindingContext = Player
        });
    }
}