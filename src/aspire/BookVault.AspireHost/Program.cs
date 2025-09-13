using BookVault.AspireConstants;
using Projects;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<PostgresServerResource> postgresServer = builder
    .AddPostgres(Components.Postgres)
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

IResourceBuilder<RedisResource> redis = builder
    .AddRedis(Components.Redis)
    .WithLifetime(ContainerLifetime.Persistent);

IResourceBuilder<PostgresDatabaseResource> catalogPgDb = postgresServer.AddDatabase(Components.Databases.Catalog);

builder.AddProject<BookVault_Catalog_Api>(Services.Catalog)
    .WithReference(catalogPgDb).WaitFor(catalogPgDb)
    .WithReference(redis).WaitFor(redis);

await builder.Build().RunAsync();
