using ModisaApp.Shared.Exceptions;
using ModisaApp.Shared.Interfaces.Providers;
using ModisaApp.Shared.Repositories;
using ModisaApp.Shared.Services;
using ModisaApp.Web.Components;
using ModisaApp.Web.Services;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
     .AddCircuitOptions(option =>
     {
         //only add details when debugging
         option.DetailedErrors = builder.Environment.IsDevelopment();
     });

// Add device-specific services used by the ModisaApp.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddScoped<HttpResponseExceptionHander>();
builder.Services.AddScoped<IHttpServiceProvider, HttpServiceProvider>();
builder.Services.AddHttpClient();



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
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(ModisaApp.Shared._Imports).Assembly);


app.Run();
