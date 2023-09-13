using ExternalIntegration.Interfaces;
using ExternalIntegration.Services;
using Infraestructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Services;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;
using Infraestructure.SqlServer.Repositories;
using Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

//get projectId & topicId
var projectId = configuration.GetValue<string>("projectId");
var topicId = configuration.GetValue<string>("topicId");
var key = configuration.GetValue<string>("key");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IThirdPartyService,ThirdPartyService>();
builder.Services.AddScoped<IMessageBrokerRepository, MessageBrokerRepository>();
builder.Services.Configure<Message>(builder => new Message(null, topicId, projectId, Guid.Parse(key)));

//MessageBroker
builder.Services.AddTransient<IMessageBroker, MessageBrokerService>();

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
