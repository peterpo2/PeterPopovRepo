using ForumManagementSystem.CONTROLLERS;
using ForumManagementSystem.data;
using ForumManagementSystem.Mappers;
using ForumManagementSystem.Repositories;
using ForumManagementSystem.services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ForumManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });

            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<IPostsRepository, PostsRepository>();
            builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<IPhoneRepository, PhoneRepository>();


            builder.Services.AddScoped<IUsersService, UsersService>();
            builder.Services.AddScoped<IPostsService, PostsService>();
            builder.Services.AddScoped<ICommentsService, CommentsService>();
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<IPhoneService, PhoneService>();

            builder.Services.AddScoped<UserMapper>();
            builder.Services.AddScoped<PostMapper>();
            builder.Services.AddScoped<PhoneMapper>();
            builder.Services.AddScoped<CommentMapper>();

            builder.Services.AddScoped<AuthenticationHelper>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}