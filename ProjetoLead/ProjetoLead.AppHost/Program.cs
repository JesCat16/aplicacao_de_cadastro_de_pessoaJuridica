var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.ProjetoLead_ApiService>("apiservice");

builder.AddProject<Projects.ProjetoLead_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
