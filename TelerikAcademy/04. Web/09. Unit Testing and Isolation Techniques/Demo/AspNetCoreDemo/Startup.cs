using AspNetCoreDemo.Data;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using Newtonsoft.Json;

namespace AspNetCoreDemo
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
				.AddNewtonsoftJson(options =>
				{
					options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
				});
			
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreDemo API", Version = "v1" });
			});

			services.AddDbContext<ApplicationContext>(options =>
			{
				options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
				options.EnableSensitiveDataLogging();
			});

			services.AddScoped<IBeersRepository, BeersRepository>();
			services.AddScoped<IStylesRepository, StylesRepository>();
			services.AddScoped<IUsersRepository, UsersRepository>();

			services.AddScoped<IBeersService, BeersService>();
			services.AddScoped<IStylesService, StylesService>();
			services.AddScoped<IUsersService, UsersService>();

			services.AddScoped<ModelMapper>();
			services.AddScoped<AuthManager>();
		}

		public void Configure(IApplicationBuilder app)
		{
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
		}
	}
}
