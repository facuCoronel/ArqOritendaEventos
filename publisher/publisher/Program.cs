using ExternalIntegration.Interfaces;
using ExternalIntegration.Services;
using Infraestructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Interfaces;
using Domain.Services;

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
//builder.Services.AddDbContext<ContextDb>(options => options.UseSqlServer("name=DefaultConnection"));

builder.Services.AddScoped<IThirdParty,ThirdPartyService>();
//builder.Services.AddScoped<IMessageBroker, MessageBrokerService>();

//MessageBroker
builder.Services.AddTransient<IMessageBroker, MessageBrokerService>(build => new MessageBrokerService(projectId, topicId, Guid.Parse(key)));

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
