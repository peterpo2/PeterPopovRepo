using AspNetCoreDemo.Data;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Repositories.Contracts;
using AspNetCoreDemo.Services;
using AspNetCoreDemo.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;

namespace AspNetCoreDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews()
				.AddNewtonsoftJson(options =>
				{
					options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
				});

			builder.Services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreDemo API", Version = "v1" });
			});

			builder.Services.AddDbContext<ApplicationContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
				options.EnableSensitiveDataLogging();
			});

			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromSeconds(1000);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});

			builder.Services.AddScoped<IBeersRepository, BeersRepository>();
			builder.Services.AddScoped<IStylesRepository, StylesRepository>();
			builder.Services.AddScoped<IUsersRepository, UsersRepository>();

			builder.Services.AddScoped<IBeersService, BeersService>();
			builder.Services.AddScoped<IStylesService, StylesService>();
			builder.Services.AddScoped<IUsersService, UsersService>();

			builder.Services.AddScoped<ModelMapper>();
			builder.Services.AddScoped<AuthManager>();

			var app = builder.Build();

			app.UseDeveloperExceptionPage();
			app.UseRouting();

			app.UseSession();

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "AspNetCoreDemo API V1");
				options.RoutePrefix = "api/swagger";
			});

			// Enables the views to use resources from wwwroot
			app.UseStaticFiles();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});

			app.Run();
		}
    }
}
