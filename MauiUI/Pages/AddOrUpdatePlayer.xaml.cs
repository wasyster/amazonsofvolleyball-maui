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

        player ??= new PlayerModel();
    }

	protected async override void OnAppearing()
	{
        await SetUpPositionPicker();
        SetUpControls();
        SetTitle();
        SetActionPointer();

        player.ValidationCompleted += OnValidationHandler;
        BindingContext = player;
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
	{
        var result = await playerClient.CreateAsync(player);

        if (!result)
            return;
    }

    private async Task UpdatePlayer()
    {
        var result = await playerClient.UpdateAsync(player);

        if (!result)
            return;
    }

    private async void OnSaveClick(object sender, EventArgs e)
    {
        if (player?.HasErrors ?? true)
            return;

		await asyncAction();
    }

    private void OnValidationHandler(Dictionary<string, string?> validationMessages)
    {
        if (validationMessages is null)
            return;

        lblValidationErrorName.Text = validationMessages.GetValueOrDefault("name");
        lblValidationErrorPosition.Text = validationMessages.GetValueOrDefault("positionid");
        lblValidationErrorClub.Text = validationMessages.GetValueOrDefault("club");
        lblValidationErrorWebImageLink.Text = validationMessages.GetValueOrDefault("webimagelink");
        lblValidationErrorBirthPlace.Text = validationMessages.GetValueOrDefault("birthplace");
        lblValidationErrorWeight.Text = validationMessages.GetValueOrDefault("weight");
        lblValidationErrorHeight.Text = validationMessages.GetValueOrDefault("height");
        lblValidationErrorDescription.Text = validationMessages.GetValueOrDefault("description");
    }
}