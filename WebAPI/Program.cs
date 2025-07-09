using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using Repositories.EFCore;
using Services.Contracts;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config")); // Load NLog configuration from file

builder.Services.AddControllers(config => // Add MVC controllers with specific configuration
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
})
    .AddCustomCsvFormatter() // Add custom CSV formatter for handling CSV requests and responses
    .AddXmlDataContractSerializerFormatters() // Add XML formatter for handling XML requests and responses
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly) // Add application parts from the specified assembly
    .AddNewtonsoftJson(); // Add Newtonsoft JSON formatter for handling JSON requests and responses

builder.Services.Configure<ApiBehaviorOptions>(options => // Configure API behavior options
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer(); // Add support for API endpoint exploration
builder.Services.AddSwaggerGen(); // Add Swagger generation for API documentation

builder.Services.ConfigureSqlContext(builder.Configuration); // Configure SQL context using connection string from configuration
builder.Services.ConfigureRepositoryManager(); // Configure repository manager for data access
builder.Services.ConfigureServiceManager(); // Configure service manager for business logic
builder.Services.ConfigureLoggerService(); // Configure custom logger service for logging
builder.Services.AddAutoMapper(typeof(Program)); // Add AutoMapper for object mapping

var app = builder.Build(); // Build the application

var logger = app.Services.GetRequiredService<ILoggerService>(); // Get the logger service from the service provider
app.ConfigureExceptionHandler(logger); // Configure global exception handling with a custom logger

if (app.Environment.IsDevelopment()) // Use Swagger in development environment
{
    app.UseSwagger(); // Enable Swagger middleware
    app.UseSwaggerUI(); // Enable Swagger UI middleware
}

if (app.Environment.IsProduction()) // Use HSTS in production environment
{
    app.UseHsts(); // Enable HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // Enable HTTPS redirection

app.UseAuthorization(); // Enable authorization middleware

app.MapControllers(); // Map controllers to routes

app.Run(); // Run the application
