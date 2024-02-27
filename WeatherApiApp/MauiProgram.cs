using Microcharts.Maui;
using Microsoft.Extensions.Logging;
using WeatherApiApp.Models;
using WeatherApiApp.ViewModels;
using WeatherApiApp.Views;

namespace WeatherApiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMicrocharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<APIViewModel>();
            builder.Services.AddSingleton<BaseViewModel>();
            builder.Services.AddSingleton<InstellingenPage>();

            builder.Services.AddSingleton<InstellingenPage>();
            builder.Services.AddSingleton<WeerPage>();

            return builder.Build();
        }
    }
}