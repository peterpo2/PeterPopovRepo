using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreDemo
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app)
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
