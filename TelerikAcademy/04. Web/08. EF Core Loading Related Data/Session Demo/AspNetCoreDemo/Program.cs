using AspNetCoreDemo.Data;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace AspNetCoreDemo
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreDemo API", Version = "v1" });
            });

            // EF 
            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                // A connection string for establishing a connection to the locally installed SQL Server Express.
                string connectionString = @"Server=localhost;Database=BeersDb;Trusted_Connection=True;";
                // Configure the application to use the locally installed SQL Server Express.
                options.UseSqlServer(connectionString);
                // The following helps with debugging the trobled relationship between EF and SQL ¯\_(-_-)_/¯ 
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
