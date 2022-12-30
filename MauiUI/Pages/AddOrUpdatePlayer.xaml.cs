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

        this.positionClient = positionClient;
        this.playerClient = playerClient;

		SetUpControls();
		SetTitle();
		SetActionPointer();

        player = player ?? new PlayerModel();
    }

	protected async override void OnAppearing()
	{
        BindingContext = player;
        player.ValidationCompleted += OnValidationHandler;

        await SetUpPositionPicker();
    }

    private void SetUpControls()
	{
        birthday.MinimumDate = new DateTime(1900, 1, 1);
        birthday.MaximumDate = DateTime.Now.Date;
    }

    private async Task SetUpPositionPicker()
    {
        position.ItemsSource = await this.positionClient.GetAllAsync();
    }

	private void SetTitle()
	{
        Title = this.player is null ?
                "Add new player" :
                 $"Update {player?.Name}";
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

    private void OnValidationHandler(Dictionary<string, string?> validationMessages)
    {
        if (validationMessages is null)
            return;

        lblValidationErrorName.Text = validationMessages.GetValueOrDefault("name");
        lblValidationErrorClub.Text = validationMessages.GetValueOrDefault("club");
    }
}