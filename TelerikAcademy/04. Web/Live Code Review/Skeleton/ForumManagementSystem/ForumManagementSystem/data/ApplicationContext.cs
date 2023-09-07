using ForumManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ForumManagementSystem.data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
		}

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Phone> Phones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Phone)
                .WithOne(ph => ph.Owner)
                .HasForeignKey<Phone>(ph => ph.OwnerId)
                .IsRequired(false);

            List<User> users = new List<User>()
            {
                new User { Id = 1, Username = "admin", FirstName = "Admin", LastName = "Adminov", Email = "admin@yahoo.com", IsAdmin = true },
                new User { Id = 2, Username = "george", FirstName = "George", LastName = "Georgiev", Email = "george@gmail.com", IsAdmin = false },
                new User { Id = 3, Username = "peter", FirstName = "Peter", LastName = "Peterson", Email = "peter@gmail.com", IsAdmin = false }
            };
            modelBuilder.Entity<User>().HasData(users);

            Phone phone = new Phone() { Id = 1, PhoneNumber = "0878123456", OwnerId = 1 };
            modelBuilder.Entity<Phone>().HasData(phone);

            List<Post> posts = new List<Post>()
            {
                new Post { Id = 1, Title = "Healthy breakfast", Content = "Here is a recipe for a banana smoothie - ready in just 5 minutes!", AuthorId = 2},
                new Post { Id = 2, Title = "Healthy lunch", Content = "Here is a healthy recipe for a salad with tomatoes and mozzarella!", AuthorId = 2},
                new Post { Id = 3, Title = "Breakfast for 5 minutes", Content = "Here is a fast recipe breakfast", AuthorId = 3},
                new Post { Id = 4, Title = "Fruit Salad with se?ds", Content = "Very fresh fruit salad with seeds, rich in vitamins!", AuthorId = 3},
                new Post { Id = 5, Title = "Great Pizza Tip!", Content = "So this is something I\'ve been experimenting with for a bit, and I wanted to share with you all. It\'s nothing groundbreaking, but it\'s helped me a lot. I have two baking stones in my oven and when I make pizza, it\'s so much easier to transport on parchment on my peel. This is especially since I use Lahey\'s rather slack pizza dough. I was happy with my crusts, but something was missing. I started taking the parchment out about halfway through and letting the stone come into direct contact with it, and it\'s made a huge difference. I always just figured that at the super high temp, that moisture was just kind of evaporating anyway, but i think the parchment was still catching some of the sweat. The pizzas go in for a little less than 15 minutes, no parbake, topped and everything, and they\'ve been coming out really good. Enjoy", AuthorId = 3}
            };
            modelBuilder.Entity<Post>().HasData(posts);

            List<Comment> Comments = new List<Comment>()
            {
                new Comment { Id = 1, PostId = 1, AuthorId = 3, Content = "This recipe is awesome!" },
                new Comment { Id = 2, PostId = 2, AuthorId = 3, Content = "Very good!" },
                new Comment { Id = 3, PostId = 4, AuthorId = 2, Content = "Wow!" }
            };
            modelBuilder.Entity<Comment>().HasData(Comments);

        }
    }
}
