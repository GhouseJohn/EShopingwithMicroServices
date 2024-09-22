using Eshoping.GateWay.services.AuthService;
using Eshoping.GateWay.services.defaultService;
using Eshoping.GateWay.services.IAuthService;
using Eshoping.GateWay.services.IServices;
using Eshoping.GateWay.services.Services;
using Eshoping.GateWay.utility;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//SD Services
SD.BookStoredAPIBase = builder.Configuration["ServiceUrls:BookStoredAPIBase"];
SD.AuthApi = builder.Configuration["ServiceUrls:AuthApi"];

//Dependency 

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient<IBookDefaultService, BookDefaultService>();
builder.Services.AddHttpClient<ILoginService, LoginService>();

builder.Services.AddScoped<IBookDefaultService, BookDefaultService>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/api/Auth";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
