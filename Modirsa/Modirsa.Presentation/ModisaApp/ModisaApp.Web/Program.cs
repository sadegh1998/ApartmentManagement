using ModisaApp.Shared.Exceptions;
using ModisaApp.Shared.Interfaces.Providers;
using ModisaApp.Shared.Repositories;
using ModisaApp.Shared.Services;
using ModisaApp.Web.Components;
using ModisaApp.Web.Services;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
     .AddCircuitOptions(option =>
     {
         //only add details when debugging
         option.DetailedErrors = builder.Environment.IsDevelopment();
         option.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(5);
         option.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
         option.MaxBufferedUnacknowledgedRenderBatches = 10;
     });

// Add RazorPages for Error page support
builder.Services.AddRazorPages();

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
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Log all requests
app.Use(async (context, next) =>
{
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);
    await next();
    logger.LogInformation("Response: {StatusCode}", context.Response.StatusCode);
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(ModisaApp.Shared._Imports).Assembly);

app.MapFallbackToPage("/Error", "/Error");

app.Run();
