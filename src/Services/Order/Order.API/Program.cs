using Order.API;
using Order.Application;
using Order.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container 
builder.Services.AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
app.HandleRequestPipeline();

app.Run();
