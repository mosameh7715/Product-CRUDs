using Identity_Server;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddIdentityServer()
    .AddInMemoryApiResources(IdentityServerConfiguration.ApiResources)
    .AddInMemoryApiScopes(IdentityServerConfiguration.ApiScopes)
    .AddInMemoryClients(IdentityServerConfiguration.Clients)
    .AddTestUsers(IdentityServerConfiguration.TestUsers);

var app = builder.Build();

app.UseIdentityServer();


app.Run();
