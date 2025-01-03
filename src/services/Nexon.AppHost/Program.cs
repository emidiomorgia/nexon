var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Bff_API>("bff-api");

builder.Build().Run();
