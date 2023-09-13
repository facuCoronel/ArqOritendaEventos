using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using ExternalIntegration.Interfaces;
using ExternalIntegration.Services;
using Infraestructure.SqlServer.EventsDbContext;
using Infraestructure.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//EventosCore
builder.Services.AddScoped<IEventCoreService, EventCoreService>();
builder.Services.AddScoped<IEventCoreRepository, EventCoreRepository>();
builder.Services.AddScoped<IThirdPartyService, ThirdPartyService>();

//ExternalServices
builder.Services.AddScoped<IThirdPartyService, ThirdPartyService>();



builder.Services.AddDbContext<EventDbContext>(opctions => opctions.UseSqlServer("name=DefaultConnection"));

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
