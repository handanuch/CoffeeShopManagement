using DotNetEnv;
using CoffeeShop.Utils.Attributes;
using CoffeeShop.Utils.Helpers;
using CoffeeShop.Utils.Session;

Env.Load();
DBCHelper.Load();
SessionHelper.ClearExpires();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options => options.Filters.Add(new JWTAttribute()))
.AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseStaticFiles();
app.UseCors();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();