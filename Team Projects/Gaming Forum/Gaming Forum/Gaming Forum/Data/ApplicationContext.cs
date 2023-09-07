using Gaming_Forum.Models;
using Microsoft.EntityFrameworkCore;

namespace Gaming_Forum.Data
{
    public class ApplicationContext:DbContext 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed the database with users
            List<User> users = new List<User>()
            {
                new User {
                    Id = 1,
                    Username = "admin",
                    Password = "123456",
                    Email = "Adminkata@gmail.com",
                    FirstName = "ADMIN",
                    LastName = "ADMINOV",
                    PhoneNumber = "0898872323",
                    IsAdmin = true,
                    Comments= new List<Comment>(),
                    Posts= new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new User { 
                    Id = 2, 
                    Username = "george", 
                    Password = "123456", 
                    FirstName = "Jorkata", 
                    LastName = "Jorov", 
                    Email = "JoroJorkov@abv.bg",  
                    Comments= new List<Comment>(), 
                    Posts= new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new User { 
                    Id = 3, 
                    Username = "peter",  
                    Password = "123456", 
                    FirstName = "Pesho", 
                    LastName = "Peshakov", 
                    Email = "PeshoPoshov@abv.bg", 
                    Comments= new List<Comment>(), 
                    Posts= new List<Post>(),
                    Likes= new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                }
            };
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<User>()
                .HasMany(user => user.Posts)
                .WithOne(post => post.User)
                .OnDelete(DeleteBehavior.NoAction);

            // Seed the database with posts
            List<Post> posts = new List<Post>()
            {
                new Post { 
                    Id = 1, 
                    UserId = 3, 
                    Title = "What was the first indie game you played?",
                    Content = "I originally wanted to ask \"What was your first indie game?\", but I understand that the definition of what is indie and what isn't can be shaky the further you go back in time.",
                    Comments= new List<Comment>(), 
                    Replies= new List<Post>(),
                    Tags = new List<Tag>(),
                    Likes = new List<Like>(),
                },
                new Post { 
                    Id = 2, 
                    UserId = 2, 
                    Title = "Immortals Of Aveum 40 minutes of raw gameplay",
                    Content = "ea let one random lets player record 40 minutes of footage", 
                    Comments= new List<Comment>(), 
                    Replies= new List<Post>(),
                    Tags = new List<Tag>(),
                    Likes = new List<Like>()
                },
                new Post {
                    Id = 3, 
                    UserId = 1, 
                    Title = "Starfield controller and headset out now!", 
                    Content = "DROP THE PREORDER LINKS WHEN YOU SEE THEM", 
                    Comments = new List<Comment>(), 
                    Replies = new List<Post>(),
                    Tags = new List<Tag>(),
                    Likes = new List<Like>()
                }
            };
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<Post>().HasData(posts);

            modelBuilder.Entity<Post>()
                .HasMany<Comment>(r => r.Comments)
                .WithOne(u => u.Post)
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed the database with comments
            List<Comment> comments = new List<Comment>()
            {
                new Comment {
                    Id = 1,
                    UserId = 2,
                    PostId = 1,
                    Content= "World of Goo. Got frustrated part way through and never finished.",
                    DateCreated = DateTime.Now,
                    Replies = new List<Comment>(),
                    Likes = new List<Like>()                    
                },
                new Comment {
                    Id = 2,
                    UserId = 3,
                    PostId = 1,
                    Content = "Idk, looks messy. And I really find the main protag and story dull based on story trailers they've released.",
                    DateCreated = DateTime.Now,
                    Replies = new List<Comment>(),
                    Likes = new List<Like>()
                },
                new Comment {
                    Id = 3,
                    UserId = 1,
                    PostId = 3,
                    Content = "Will be refreshing until I can get it today.",
                    DateCreated = DateTime.Now,
                    Replies = new List<Comment>(),
                    Likes = new List<Like>()
                }
            };
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Comment>().HasData(comments);
            modelBuilder.Entity<Comment>()
                .HasOne<User>(r => r.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
