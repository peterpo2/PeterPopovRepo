using AspNetCoreDemo.Data;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AspNetCoreDemo
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreDemo API", Version = "v1" });
            });

            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                // The connection string has been moved to appsettings.json
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
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