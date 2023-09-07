using AspNetCoreDemo.Mappers;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreDemo
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			// Repositories
			services.AddSingleton<IBeersRepository, BeersRepository>();
			services.AddSingleton<IStylesRepository, StylesRepository>();
			// Services
			services.AddScoped<IBeersService, BeersService>();
			services.AddScoped<IStylesService, StylesService>();
			// Helpers
			services.AddScoped<ModelMapper>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
