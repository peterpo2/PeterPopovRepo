using APTEKA_Software.Data;
using APTEKA_Software.Helpers;
using APTEKA_Software.Repositories;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services;
using APTEKA_Software.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<ApplicationContext>(options =>
        {
            string connectionString = @"Server=DESKTOP-NNCE23Q;Database=AptekaSoftware;Trusted_Connection=True;Encrypt=False;";

            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging();
        });

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "APTEKA Software", Version = "v1" });
        });

        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(1000);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IItemRepository, ItemRepository>();
        builder.Services.AddScoped<ISaleRepository, SaleRepository>();
        builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();

        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IItemService, ItemService>();
        builder.Services.AddScoped<ISalesService, SalesService>();
        builder.Services.AddScoped<IDeliveryService, DeliveryService>();

        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        builder.Services.AddScoped<AuthManager>();
        builder.Services.AddHttpContextAccessor();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "APTEKA Software v1");
        });

        app.UseDeveloperExceptionPage();

        app.UseRouting();

        app.UseSession();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });

        app.Run();
    }
}
