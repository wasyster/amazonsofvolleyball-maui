using Mobile.UI.Interfaces;

namespace Mobile.UI
{
    public partial class MainPage : ContentPage
    {
        private readonly IPlayerClient playerClient;

        public MainPage(IPlayerClient playerClient)
        {
            InitializeComponent();

            this.playerClient = playerClient;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var result = await playerClient.GetAllAsync();
        }
    }
}