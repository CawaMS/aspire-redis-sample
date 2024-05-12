var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache").AsAzureRedis();

var apiService = builder.AddProject<Projects.AspireSln11_ApiService>("apiservice")
                        .WithReference(cache);

builder.AddProject<Projects.AspireSln11_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
