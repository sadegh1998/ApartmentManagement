using _0_Framework.Application;
using AccountManagement.Configuration;
using BuildingManagement.Configuration;
using ExpenseManagement.Configuration;
using Modirsa.Mobile.Shared.Services;
using Modirsa.Mobile.Web.Components;
using Modirsa.Mobile.Web.Services;
using ServiceHost;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpContextAccessor();
// Add device-specific services used by the Modirsa.Mobile.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
var connectionStrings = builder.Configuration.GetConnectionString("ModisaDB");
AccountBootstrapper.Configuration(builder.Services, connectionStrings);
BuildingBootstrapper.Configuration(builder.Services, connectionStrings);
ExpenseBootstrapper.Configuration(builder.Services, connectionStrings);
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
//builder.Services.AddSingleton<HmacTokenHelper>();
builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(Modirsa.Mobile.Shared._Imports).Assembly);

app.Run();
