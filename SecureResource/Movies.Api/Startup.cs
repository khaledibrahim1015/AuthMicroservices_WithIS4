using Microsoft.EntityFrameworkCore;
using Movies.Api.Data;

namespace Movies.Api;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddSwaggerGen(cfg =>
        {
            cfg.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Movies.Api", Version = "v1" });

        });


        services.AddDbContext<MovieDbContext>(option =>
        {
            option.UseInMemoryDatabase("MoviesDb");
        });

        //  add auth 
        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:5005";
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = false
                };
            });

        // add claims based authorization 
        services.AddAuthorization(option =>
        {
            option.AddPolicy("ClientIdPloicy", configurePloicy => configurePloicy.RequireClaim("client_id", "movieClient"));
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Movies.Api v1");
            });

        }
        app.UseHttpsRedirection();


        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });





    }


}
