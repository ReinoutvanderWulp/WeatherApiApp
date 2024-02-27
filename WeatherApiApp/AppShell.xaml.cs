using WeatherApiApp.Views;

namespace WeatherApiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(WeerPage), typeof(WeerPage));
            Routing.RegisterRoute(nameof(InstellingenPage), typeof(InstellingenPage));
        }
    }
}