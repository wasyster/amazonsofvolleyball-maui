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
            OnPropertyChanged("player");
        }
    }

    private readonly IMemoryCache memoryCache;
    private readonly IPlayerClient playerClient;


    private delegate Task Action();
    private Action asyncAction;


    public AddOrUpdatePlayer(IMemoryCache memoryCache, IPlayerClient playerClient)
    {
        this.memoryCache = memoryCache;
        this.playerClient = playerClient;

        InitializeComponent();
        SetUpControls();
    }

    protected override void OnAppearing()
    {
        player ??= new PlayerModel();
        player.ValidationCompleted += OnValidationHandler;

        var positionIndex = GetIndexForPositionPicker();

        BindingContext = player;

        position.SelectedIndex = positionIndex;

        SetUpControls();
        SetTitle();
        SetActionPointer();
    }

    private void SetUpControls()
    {
        birthday.Date= DateTime.Now.Date;
        birthday.MinimumDate = new DateTime(1900, 1, 1);
        birthday.MaximumDate = DateTime.Now.Date.AddDays(-1);

        memoryCache.TryGetValue(CacheKeys.Positions, out List<PositionModel> positions);
        position.ItemsSource = positions;
    }

    private int GetIndexForPositionPicker()
    {
        memoryCache.TryGetValue(CacheKeys.Positions, out List<PositionModel> positions);
        var selectedPosition = positions.FirstOrDefault(x => x.Id == player?.Position?.Id);
        return positions.IndexOf(selectedPosition);
    }

    private void SetTitle()
    {
        Title = this.player?.Id == 0 ?
                "Add new player" :
                $"Update {player?.Name}";
    }

    private void SetActionPointer()
    {
        asyncAction = this.player?.Id == 0 ?
                      AddNewPlayer :
                      UpdatePlayer;
    }

    private async Task AddNewPlayer()
    {
        var result = await playerClient.CreateAsync(player);

        if (!result)
        {
            await DisplayAlert("ERROR", "There was an error while saving a new player!", "OK");
            return;
        }

        await DisplayAlert("", "New player saved successfully!", "OK");
    }

    private async Task UpdatePlayer()
    {
        var result = await playerClient.UpdateAsync(player);

        if (!result)
        {
            await DisplayAlert("ERROR", "There was an error while updating a player!", "OK");
            return;
        }

        await DisplayAlert("", "Player updated successfully!", "OK");
    }

    private async void OnSaveClick(object sender, EventArgs e)
    {
        if (player?.HasErrors ?? true)
            return;

        await asyncAction();
        await Shell.Current.GoToAsync(PageRoutes.HomePage);
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