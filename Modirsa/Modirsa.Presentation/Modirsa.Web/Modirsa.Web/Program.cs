using _0_Framework.Application;
using _0_Framework.Infrstructure;
using AccountManagement.Configuration;
using BuildingManagement.Configuration;
using ExpenseManagement.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Modirsa.Web;
using Modirsa.Web.Data;
using MudBlazor;
using MudBlazor.Services;
using System.ComponentModel.Design;
using System.Text.Encodings.Web;
using System.Text.Unicode;


var builder = WebApplication.CreateBuilder(args);
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
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminArea", builder => builder.RequireRole(Roles.Administrator, Roles.BuildingManager));
    options.AddPolicy("Building", builder => builder.RequireRole(Roles.Administrator, Roles.BuildingManager));
    options.AddPolicy("Expense", builder => builder.RequireRole(Roles.Administrator, Roles.BuildingManager, Roles.SiteUser));
    options.AddPolicy("Account", builder => builder.RequireRole(Roles.Administrator, Roles.BuildingManager));

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
