using Eshoping.GateWay.services;
using Eshoping.GateWay.services.IServices;
using Eshoping.GateWay.utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//SD Services
SD.BookStoredAPIBase = builder.Configuration["ServiceUrls:BookStoredAPIBase"];

//Dependency 
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IBookDefaultService, BookDefaultService>();
builder.Services.AddHttpClient();

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
