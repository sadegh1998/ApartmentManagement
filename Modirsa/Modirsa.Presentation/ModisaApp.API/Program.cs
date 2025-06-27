using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration,builder.Environment);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAll"); // اضافه کردن CORS
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
