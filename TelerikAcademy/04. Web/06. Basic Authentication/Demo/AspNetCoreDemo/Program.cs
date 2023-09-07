using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;

namespace AspNetCoreDemo
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Swagger allows you to explore your rest api in a more interactive way.
            // To test this functionality, update the launchUrl in Properties/launchSettings.json
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreDemo API", Version = "v1" });
            });

            // Repositories
            builder.Services.AddScoped<IBeersRepository, BeersRepository>();
            builder.Services.AddScoped<IStylesRepository, StylesRepository>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();

            // Services
            builder.Services.AddScoped<IBeersService, BeersService>();
            builder.Services.AddScoped<IStylesService, StylesService>();
            builder.Services.AddScoped<IUsersService, UsersService>();

            // Helpers
            builder.Services.AddScoped<ModelMapper>();
            builder.Services.AddScoped<AuthManager>();

            var app = builder.Build();

            app.UseDeveloperExceptionPage();
            app.UseRouting();
            // Enables the endpoint http://localhost:5000/api/swagger
            // Use it as an alternative to Postman for sending POST requests
            // Use launchSettings.json to change the launch url.
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AspNetCoreDemo API V1");
                options.RoutePrefix = "api/swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
