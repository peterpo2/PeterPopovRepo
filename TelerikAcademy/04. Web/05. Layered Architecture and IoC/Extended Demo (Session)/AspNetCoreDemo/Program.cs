using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreDemo
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Repositories
            builder.Services.AddSingleton<IBeersRepository, BeersRepository>();
            builder.Services.AddScoped<IStylesRepository, StylesRepository>();

            // Services
            builder.Services.AddScoped<IBeersService, BeersService>();
            builder.Services.AddScoped<IStylesService, StylesService>();

            // Helpers
            builder.Services.AddScoped<ModelMapper>();


            var app = builder.Build();

            app.UseRouting();

            app.MapControllers();

            app.Run();
        }
    }
}
