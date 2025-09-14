using BookVault.Catalog.Api;
using BookVault.Catalog.Application;
using BookVault.Catalog.Infrastructure;
using BookVault.ServiceDefaults;
using SharedKernel.Api.Endpoints;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddPresentation(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.AddInfrastructure();

builder.AddServiceDefaults();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapEndpoints();

await app.RunAsync();
