using BookVault.AspireConstants;
using Projects;
using Scalar.Aspire;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<PostgresServerResource> postgresServer = builder
    .AddPostgres(Components.Postgres)
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

IResourceBuilder<RedisResource> redis = builder
    .AddRedis(Components.Redis)
    .WithLifetime(ContainerLifetime.Persistent);

IResourceBuilder<PostgresDatabaseResource> catalogPgDb = postgresServer.AddDatabase(Components.Databases.Catalog);

IResourceBuilder<ProjectResource> catalogApi = builder.AddProject<BookVault_Catalog_Api>(Services.Catalog)
    .WithReference(catalogPgDb).WaitFor(catalogPgDb)
    .WithReference(redis).WaitFor(redis);

// todo: doesn't work
builder.AddScalarApiReference(options => options
        .PreferHttpsEndpoint()
        .AllowSelfSignedCertificates())
    .WithApiReference(catalogApi, options => options.WithOpenApiRoutePattern("/openapi/v1.json"));

await builder.Build().RunAsync();
