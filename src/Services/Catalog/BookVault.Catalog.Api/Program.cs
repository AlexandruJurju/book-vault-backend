using System.Reflection;
using BookVault.Catalog.Api;
using BookVault.Catalog.Application;
using BookVault.Catalog.Infrastructure;
using BookVault.ServiceDefaults;
using Scalar.AspNetCore;
using Serilog;
using SharedKernel.Api.Endpoints;
using SharedKernel.Api.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddOpenApi();

builder.Services.AddPresentation(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.AddInfrastructure();

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.AddServiceDefaults();

WebApplication app = builder.Build();

app.MapEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestContextLoggingMiddleware>();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

await app.RunAsync();
