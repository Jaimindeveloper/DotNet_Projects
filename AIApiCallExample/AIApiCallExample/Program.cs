using AIApiCallExample.Models;
using AIApiCallExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Register Controller + Views
builder.Services.AddControllersWithViews();

// Register service
builder.Services.AddScoped<MyService>();

// Bind config
builder.Services.Configure<UserSettings>
    (builder.Configuration.GetSection("MySettings"));

var app = builder.Build();

app.MapControllers();
app.UseStaticFiles();

// Directly Get Value from Env File 

// var myValue = builder.Configuration["mykeys"];
// Console.WriteLine($"Value: {myValue}");

app.Run();
