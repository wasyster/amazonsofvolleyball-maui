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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var result = playerClient.GetAllAsync().Result;
        }
    }
}