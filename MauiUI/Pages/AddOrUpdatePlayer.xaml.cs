namespace MauiUI.Pages;

public partial class AddOrUpdatePlayer : ContentPage
{
	private PlayerModel player;

	public AddOrUpdatePlayer(PlayerModel player = null)
	{
		InitializeComponent();

		this.player = player;
		BindingContext = this.player;

		Title = this.player is null ?
				"Add new player" :
				$"Update {player.Name}";
    }
}