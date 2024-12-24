using Azure.Monitor.OpenTelemetry.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();

// Add OpenTelemetry and configure it to use Azure Monitor.
//builder.Services.AddOpenTelemetry().UseAzureMonitor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSerilogRequestLogging(); // Enable Serilog request logging

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
