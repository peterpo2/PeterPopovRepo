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
            string connectionString =
                @"Server=192.168.0.120;Database=AptekaDb;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";

            options.UseSqlServer(connectionString, sql =>
            {
                // sql.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName);
                sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });

            if (builder.Environment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            }
        });

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "APTEKA Software", Version = "v1" });
        });

        builder.Services.AddDistributedMemoryCache();
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
        builder.Services.AddScoped<IAdminService, AdminService>();

        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        builder.Services.AddScoped<AuthManager>();
        builder.Services.AddHttpContextAccessor();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                db.Database.Migrate();
            }
            catch (Exception ex)
            {
                app.Logger.LogError(ex, "Database migration failed.");
            }
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "APTEKA Software v1");
            });
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });

        app.Run();
    }
}
