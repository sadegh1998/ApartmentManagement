using BuildingManagement.Configuration;
using ExpenseManagement.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modirsa.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
var connectionStrings = string.IsNullOrWhiteSpace(builder.Configuration.GetConnectionString("ModirsaDb")) ? "" : builder.Configuration.GetConnectionString("ModirsaDb");
ExpenseBootstrapper.Configuration(builder.Services, connectionStrings);
BuildingBootstrapper.Configuration(builder.Services, connectionStrings);
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
