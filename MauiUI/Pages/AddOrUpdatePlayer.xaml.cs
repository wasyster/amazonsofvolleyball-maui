namespace MauiUI.Pages;

[QueryProperty(nameof(Player), "player")]
public partial class AddOrUpdatePlayer : ContentPage
{
    private PlayerModel player;
    public PlayerModel Player
    {
        get => player;
        set
        {
            player = value;
            OnPropertyChanged();
        }
    }


    private readonly IPositionClient positionClient;
	private readonly IPlayerClient playerClient;

	private delegate Task Action();
	private Action asyncAction;

	public AddOrUpdatePlayer(IPositionClient positionClient, IPlayerClient playerClient)
	{
		InitializeComponent();
		SetUpControls();
		SetTitle();
		SetActionPointer();

        this.positionClient = positionClient;
        this.playerClient = playerClient;
    }

	protected async override void OnAppearing()
	{
        BindingContext = player;
        await SetUpPositionPicker();
    }

	private void SetUpControls()
	{
        birthday.MinimumDate = new DateTime(1900, 1, 1);
        birthday.MaximumDate = DateTime.Now.Date;
    }

    private async Task SetUpPositionPicker()
    {
        var positions = await this.positionClient.GetAllAsync();

        positions.Add(new PositionModel
        {
            Id = 0,
            Name = "Select ..."
        });

        position.ItemsSource = positions;
    }

	private void SetTitle()
	{
        Title = this.player is null ?
                "Add new player" :
                 $"Update {player.Name}";
    }

	private void SetActionPointer()
	{
        asyncAction = this.player is null ?
                      AddNewPlayer :
                      UpdatePlayer;
    }

	private async Task AddNewPlayer()
	{ }

    private async Task UpdatePlayer()
    { }

    private async void OnSaveClick(object sender, EventArgs e)
    {
		await asyncAction();
    }
}