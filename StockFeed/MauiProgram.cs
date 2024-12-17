using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using StockFeed.Views;
using StockFeed.Services;
using StockFeed.ViewModels;

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
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<CompaniesPage>();
            builder.Services.AddSingleton<InternetReloadPage>();
            builder.Services.AddSingleton<IBMPage>();
            builder.Services.AddSingleton<ApplePage>();

            builder.Services.AddSingleton<CompaniesService>();
            builder.Services.AddSingleton<CompanyService>();
            builder.Services.AddSingleton<IBMService>();
            builder.Services.AddSingleton<AppleService>();

            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<CompaniesPageViewModel>();
            builder.Services.AddSingleton<CompanyPageViewModel>();
            builder.Services.AddSingleton<IBMPageViewModel>();
            builder.Services.AddSingleton<ApplePageViewModel>();

            // Amazon
            //builder.Services.AddSingleton<AmazonPage>();
            //builder.Services.AddSingleton<AmazonService>();
            //builder.Services.AddSingleton<AmazonPageViewModel>();
            // Facebook
            //builder.Services.AddSingleton<FacebookPage>();
            //builder.Services.AddSingleton<FacebookService>();
            //builder.Services.AddSingleton<FacebookPageViewModel>();
            // Tesla
            //builder.Services.AddSingleton<TeslaPage>();
            //builder.Services.AddSingleton<TeslaService>();
            //builder.Services.AddSingleton<TeslaPageViewModel>();
            // Netflix
            //builder.Services.AddSingleton<NetflixPage>();
            //builder.Services.AddSingleton<NetflixService>();
            //builder.Services.AddSingleton<NetflixPageViewModel>();
            // Alibaba
            //builder.Services.AddSingleton<AlibabaPage>();
            //builder.Services.AddSingleton<AlibabaService>();
            //builder.Services.AddSingleton<AlibabaPageViewModel>();     


            return builder.Build();
        }
    }
}
