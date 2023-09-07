using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AspNetCoreDemo
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			// Swagger allows you to explore your rest api in a more interactive way.
			// To test this functionality, update the launchUrl in Properties/launchSettings.json
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreDemo API", Version = "v1" });
			});

			// Repositories
			services.AddScoped<IBeersRepository, BeersRepository>();
			services.AddScoped<IStylesRepository, StylesRepository>();
			services.AddScoped<IUsersRepository, UsersRepository>();

			// Services
			services.AddScoped<IBeersService, BeersService>();
			services.AddScoped<IStylesService, StylesService>();
			services.AddScoped<IUsersService, UsersService>();

			// Helpers
			services.AddScoped<ModelMapper>();
			services.AddScoped<AuthManager>();
		}

		public void Configure(IApplicationBuilder app)
		{
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
		}
	}
}
