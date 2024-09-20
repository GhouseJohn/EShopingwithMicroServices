using Eshoping.Registration.DataBase;
using Eshoping.Registration.userRegistrationServices.UserRegistrationDependency;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Eshoping.Registration.utility;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//sql Server
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//JWT Connection
builder.Services.AddDbContext<JwtApplicationDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("JwtConnection")));
//Dependencies
builder.Services.AdduserRegistrationServices();
builder.Services.AddMediatR(typeof(DemoLibraryMediatREntrypoint).Assembly);


//mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
//cors
var MyAllowSpecificOrigins = "http://localhost:4200/";
builder.Services.AddCors(options =>
{

    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          //policy.WithOrigins("http://example.com",
                          //                    "http://www.contoso.com");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
