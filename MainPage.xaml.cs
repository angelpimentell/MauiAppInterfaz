using MauiAppInterfaz.Services;

namespace MauiAppInterfaz
{
    public partial class MainPage : ContentPage
    {

        public DatabaseService _database;

        public MainPage(DatabaseService database)
        {
            InitializeComponent();
            _database = database;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _database.InitAsync();

            var clients = await _database.GetClientsAsync();
            ClientsView.ItemsSource = clients;
        }
    }

}
