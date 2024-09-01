using Eshoping.Registration.DataBase;
using Eshoping.Registration.userRegistrationServices.UserRegistrationDependency;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Eshoping.Registration.utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//sql Server
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Dependencies
builder.Services.AdduserRegistrationServices();
builder.Services.AddMediatR(typeof(DemoLibraryMediatREntrypoint).Assembly);


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
