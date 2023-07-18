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


            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreDemo API", Version = "v1" });
            });
            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                // A connection string for establishing a connection to the locally installed SQL Server Express.
                string connectionString = @"Server=DESKTOP-NNCE23Q;Database=GamingForumDb;Trusted_Connection=True;";
                //string connectionString = @"Server= DESKTOP-4PG8TL1\SQLEXPRESS ;Database=GamingForumDb;Trusted_Connection=True;";
                //string connectionString = @"Server=DESKTOP-3RO82EA ;Database=GamingForumDb;Trusted_Connection=True;";


                // Configure the application to use the locally installed SQL Server Express.
                options.UseSqlServer(connectionString);
                // The following helps with debugging the trobled relationship between EF and SQL \_(-_-)_/ 
                options.EnableSensitiveDataLogging();
            });

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Repositories
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<IReplyRepository, ReplyRepository>();



            // Services
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<IReplyService, ReplyService>();

            // Helpers
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<AuthManager>();
            builder.Services.AddHttpContextAccessor();

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

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.Run();
        }
    }
}
