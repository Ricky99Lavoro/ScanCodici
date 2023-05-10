using DXMauiApp_ScanCodici.Pages;

namespace DXMauiApp_ScanCodici
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}