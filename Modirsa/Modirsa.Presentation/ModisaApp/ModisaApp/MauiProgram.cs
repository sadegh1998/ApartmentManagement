
using Microsoft.Extensions.Logging;
using ModisaApp.Services;
using ModisaApp.Shared.Exceptions;
using ModisaApp.Shared.Interfaces.Providers;
using ModisaApp.Shared.Repositories;
using ModisaApp.Shared.Services;
using MudBlazor;
using MudBlazor.Services;

using Microsoft.Extensions.Configuration;

namespace ModisaApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            var ConnectionString = builder.Configuration.GetConnectionString("ModisaDb");
            // Add device-specific services used by the ModisaApp.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopEnd;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });
            builder.Services.AddScoped<HttpResponseExceptionHander>();
            builder.Services.AddScoped<IHttpServiceProvider, HttpServiceProvider>();

            //builder.Services.AddSingleton(sp => new HttpClient
            //{
            //    BaseAddress = new Uri("http://192.168.1.9:5093/api/") // Change to your actual API URL
            //});
            builder.Services.AddSingleton<HttpClient>();

            return builder.Build();
        }
    }
}
