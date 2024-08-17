namespace IdentityServer;

public class Startup
{
    public IConfiguration Configuration;
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddIdentityServer()
            .AddInMemoryClients(Config.Clients)
            //.AddInMemoryIdentityResources(Config.IdentityResources)
            //.AddInMemoryApiResources(Config.apiResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            //.AddTestUsers(Config.TestUsers)
            //.AddInMemoryPersistedGrants() // Adds in-memory store for persisted grants
            .AddDeveloperSigningCredential();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseIdentityServer();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("hello from identity");
            });
        });
    }




}
