namespace MauiAppInterfaz
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private void OnSaludarClicked(object sender, EventArgs e)
        {
            string nombre = nombreEntrada.Text;
            saludoLabel.Text = $"Hola, {nombre} 👋";
        }
    }

}
