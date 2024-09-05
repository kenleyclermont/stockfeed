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
            // Routes
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(InternetReloadPage), typeof(InternetReloadPage));
            Routing.RegisterRoute(nameof(CompaniesPage), typeof(CompaniesPage));
            Routing.RegisterRoute(nameof(IBMPage), typeof(IBMPage));
            Routing.RegisterRoute(nameof(ApplePage), typeof(ApplePage));
            Routing.RegisterRoute(nameof(MicrosoftPage), typeof(MicrosoftPage));
            Routing.RegisterRoute(nameof(AmazonPage), typeof(AmazonPage));
            Routing.RegisterRoute(nameof(GooglePage), typeof(GooglePage));
            Routing.RegisterRoute(nameof(FacebookPage), typeof(FacebookPage));
            Routing.RegisterRoute(nameof(TeslaPage), typeof(TeslaPage));
            Routing.RegisterRoute(nameof(NetflixPage), typeof(NetflixPage));
            Routing.RegisterRoute(nameof(AlibabaPage), typeof(AlibabaPage));
            Routing.RegisterRoute(nameof(CocaColaPage), typeof(CocaColaPage));
            Routing.RegisterRoute(nameof(PepsiCoPage), typeof(PepsiCoPage));
            Routing.RegisterRoute(nameof(VisaPage), typeof(VisaPage));
            Routing.RegisterRoute(nameof(WalmartPage), typeof(WalmartPage));
        }
    }
}
