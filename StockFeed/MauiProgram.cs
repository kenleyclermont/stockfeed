using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using StockFeed.Views;
using StockFeed.Services;
using StockFeed.ViewModels;
using StockFeed.Data;

namespace StockFeed
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // MainPage
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            // InternetReloadPage
            builder.Services.AddSingleton<InternetReloadPage>();
            // CompaniesPage
            builder.Services.AddSingleton<CompaniesPage>();
            builder.Services.AddSingleton<CompanyService>();
            builder.Services.AddSingleton<CompaniesPageViewModel>();
            // IBMPage
            builder.Services.AddSingleton<IBMPage>();
            builder.Services.AddSingleton<IBMService>();
            builder.Services.AddSingleton<IBMPageViewModel>();
            // ApplePage
            builder.Services.AddSingleton<ApplePage>();
            builder.Services.AddSingleton<AppleService>();
            builder.Services.AddSingleton<ApplePageViewModel>();
            // Microsoft
            builder.Services.AddSingleton<MicrosoftPage>();
            builder.Services.AddSingleton<MicrosoftService>();
            builder.Services.AddSingleton<MicrosoftPageViewModel>();
            // Google
            builder.Services.AddSingleton<GooglePage>();
            builder.Services.AddSingleton<GoogleService>();
            builder.Services.AddSingleton<GooglePageViewModel>();
            // Amazon
            builder.Services.AddSingleton<AmazonPage>();
            builder.Services.AddSingleton<AmazonService>();
            builder.Services.AddSingleton<AmazonPageViewModel>();
            // Facebook
            builder.Services.AddSingleton<FacebookPage>();
            builder.Services.AddSingleton<FacebookService>();
            builder.Services.AddSingleton<FacebookPageViewModel>();
            // Tesla
            builder.Services.AddSingleton<TeslaPage>();
            builder.Services.AddSingleton<TeslaService>();
            builder.Services.AddSingleton<TeslaPageViewModel>();
            // Netflix
            builder.Services.AddSingleton<NetflixPage>();
            builder.Services.AddSingleton<NetflixService>();
            builder.Services.AddSingleton<NetflixPageViewModel>();
            // Alibaba
            builder.Services.AddSingleton<AlibabaPage>();
            builder.Services.AddSingleton<AlibabaService>();
            builder.Services.AddSingleton<AlibabaPageViewModel>();
            // Coca-Cola
            builder.Services.AddSingleton<CocaColaPage>();
            builder.Services.AddSingleton<CocaColaService>();
            builder.Services.AddSingleton<CocaColaPageViewModel>();
            // PepsiCo
            builder.Services.AddSingleton<PepsiCoPage>();
            builder.Services.AddSingleton<PepsiCoService>();
            builder.Services.AddSingleton<PepsiCoPageViewModel>();
            // Visa
            builder.Services.AddSingleton<VisaPage>();
            builder.Services.AddSingleton<VisaService>();
            builder.Services.AddSingleton<VisaPageViewModel>();
            // Walmart
            builder.Services.AddSingleton<WalmartPage>();
            builder.Services.AddSingleton<WalmartService>();
            builder.Services.AddSingleton<WalmartPageViewModel>();



            return builder.Build();
        }
    }
}
