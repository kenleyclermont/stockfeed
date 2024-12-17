using StockFeed.Views;
namespace StockFeed
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes() 
        {
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(CompaniesPage), typeof(CompaniesPage));
            Routing.RegisterRoute(nameof(InternetReloadPage), typeof(InternetReloadPage));

            Routing.RegisterRoute(nameof(IBMPage), typeof(IBMPage));
            Routing.RegisterRoute(nameof(ApplePage), typeof(ApplePage));
            Routing.RegisterRoute(nameof(AmazonPage), typeof(AmazonPage));
            Routing.RegisterRoute(nameof(FacebookPage), typeof(FacebookPage));
            Routing.RegisterRoute(nameof(TeslaPage), typeof(TeslaPage));
            Routing.RegisterRoute(nameof(NetflixPage), typeof(NetflixPage));
            Routing.RegisterRoute(nameof(AlibabaPage), typeof(AlibabaPage));
        }
    }
}
