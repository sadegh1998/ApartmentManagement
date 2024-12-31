using _0_Framework.Application;
using _0_Framework.Infrstructure;
using AccountManagement.Configuration;
using BuildingManagement.Configuration;
using ExpenseManagement.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Modirsa.Mobile
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
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
                config.SnackbarConfiguration.PreventDuplicates = true;
                config.SnackbarConfiguration.BackgroundBlurred = true;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Outlined;
            });
            var connectionStrings = builder.Configuration.GetConnectionString("ModisaDB");
            AccountBootstrapper.Configuration(builder.Services, connectionStrings);
            BuildingBootstrapper.Configuration(builder.Services, connectionStrings);
            ExpenseBootstrapper.Configuration(builder.Services, connectionStrings);
            builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
            // Add services to the container.
            // builder.Services.AddHttpContextAccessor();
            builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddTransient<IFileUploader, FileUploader>();
            builder.Services.AddTransient<IAuthHelper, AuthHelper>();

            builder.Services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("AdminArea", builder => builder.RequireRole(Roles.Administrator, Roles.BuildingManager));
                options.AddPolicy("Building", builder => builder.RequireRole(Roles.Administrator, Roles.BuildingManager));
                options.AddPolicy("Expense", builder => builder.RequireRole(Roles.Administrator, Roles.BuildingManager, Roles.SiteUser));
                options.AddPolicy("Account", builder => builder.RequireRole(Roles.Administrator, Roles.BuildingManager));

            });
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
