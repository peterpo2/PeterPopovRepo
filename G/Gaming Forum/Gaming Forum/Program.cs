using Gaming_Forum.Data;
using Gaming_Forum.Data.Repositories;
using Gaming_Forum.Helpers;
using Gaming_Forum.Repository;
using Gaming_Forum.Repository.Contracts;
using Gaming_Forum.Services;
using Gaming_Forum.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Gaming_Forum
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
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreDemo API", Version = "v1" });
            });
            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                // A connection string for establishing a connection to the locally installed SQL Server Express.
                string connectionString = @"Server=DESKTOP-NNCE23Q;Database=GamingForumDb;Trusted_Connection=True;";
                //string connectionString = @"Server= DESKTOP-4PG8TL1\SQLEXPRESS ;Database=GamingForumDb;Trusted_Connection=True;";
                //string connectionString = @"Server=ADD LOCAL NAME ;Database=GamingForumDb;Trusted_Connection=True;";


                // Configure the application to use the locally installed SQL Server Express.
                options.UseSqlServer(connectionString);
                // The following helps with debugging the trobled relationship between EF and SQL \_(-_-)_/ 
                options.EnableSensitiveDataLogging();
            });
            // Repositories
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
           

            // Services
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAdminService, AdminService>();

            // Helpers
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<AuthManager>();


            var app = builder.Build();

            app.UseDeveloperExceptionPage();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}