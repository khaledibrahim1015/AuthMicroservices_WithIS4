﻿namespace IdentityServer;

public class Startup
{
    public IConfiguration Configuration;
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddIdentityServer()
            .AddInMemoryClients(Config.Clients)
            .AddInMemoryIdentityResources(Config.IdentityResources)
            //.AddInMemoryApiResources(Config.ApiResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddTestUsers(Config.TestUsers)
            //.AddInMemoryPersistedGrants() // Adds in-memory store for persisted grants
            .AddDeveloperSigningCredential();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseStaticFiles();
        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();
        //app.UseEndpoints(endpoints =>
        //{
        //    endpoints.MapGet("/", async context =>
        //    {
        //        await context.Response.WriteAsync("hello from identity");
        //    });
        //});

        app.UseEndpoints(endpoints =>
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        });
    }




}
