using Gaming_Forum.Models;
using Microsoft.EntityFrameworkCore;

namespace Gaming_Forum.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Reply> Replies { get; set; }




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
                },
                new User
                {
                    Id = 4,
                    Username = "lisa",
                    Password = "123456",
                    FirstName = "Lisa",
                    LastName = "Smith",
                    Email = "lisa.smith@example.com",
                    Comments = new List<Comment>(),
                    Posts = new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 5,
                    Username = "john",
                    Password = "123456",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Comments = new List<Comment>(),
                    Posts = new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 6,
                    Username = "sarah",
                    Password = "123456",
                    FirstName = "Sarah",
                    LastName = "Johnson",
                    Email = "sarah.johnson@example.com",
                    Comments = new List<Comment>(),
                    Posts = new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 7,
                    Username = "michael",
                    Password = "123456",
                    FirstName = "Michael",
                    LastName = "Smith",
                    Email = "michael.smith@example.com",
                    Comments = new List<Comment>(),
                    Posts = new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 8,
                    Username = "emily",
                    Password = "123456",
                    FirstName = "Emily",
                    LastName = "Jones",
                    Email = "emily.jones@example.com",
                    Comments = new List<Comment>(),
                    Posts = new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 9,
                    Username = "alex",
                    Password = "123456",
                    FirstName = "Alex",
                    LastName = "Wilson",
                    Email = "alex.wilson@example.com",
                    Comments = new List<Comment>(),
                    Posts = new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 10,
                    Username = "jessica",
                    Password = "123456",
                    FirstName = "Jessica",
                    LastName = "Brown",
                    Email = "jessica.brown@example.com",
                    Comments = new List<Comment>(),
                    Posts = new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 11,
                    Username = "ryan",
                    Password = "123456",
                    FirstName = "Ryan",
                    LastName = "Smith",
                    Email = "ryan.smith@example.com",
                    Comments = new List<Comment>(),
                    Posts = new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 12,
                    Username = "lily",
                    Password = "123456",
                    FirstName = "Lily",
                    LastName = "Johnson",
                    Email = "lily.johnson@example.com",
                    Comments = new List<Comment>(),
                    Posts = new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 13,
                    Username = "david",
                    Password = "123456",
                    FirstName = "David",
                    LastName = "Wilson",
                    Email = "david.wilson@example.com",
                    Comments = new List<Comment>(),
                    Posts = new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 14,
                    Username = "olivia",
                    Password = "123456",
                    FirstName = "Olivia",
                    LastName = "Brown",
                    Email = "olivia.brown@example.com",
                    Comments = new List<Comment>(),
                    Posts = new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 15,
                    Username = "ethan",
                    Password = "123456",
                    FirstName = "Ethan",
                    LastName = "Johnson",
                    Email = "ethan.johnson@example.com",
                    Comments = new List<Comment>(),
                    Posts = new List<Post>(),
                    Likes = new List<Like>(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
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
                    Replies= new List<Reply>(),
                    Tags = new List<Tag>(),
                    Likes = new List<Like>(),
                    DateCreated = DateTime.Now
                },
                new Post {
                    Id = 2,
                    UserId = 2,
                    Title = "Immortals Of Aveum 40 minutes of raw gameplay",
                    Content = "ea let one random lets player record 40 minutes of footage",
                    Comments= new List<Comment>(),
                    Replies= new List<Reply>(),
                    Tags = new List<Tag>(),
                    Likes = new List<Like>(),
                    DateCreated = DateTime.Now
                },
                new Post {
                    Id = 3,
                    UserId = 1,
                    Title = "Starfield controller and headset out now!",
                    Content = "DROP THE PREORDER LINKS WHEN YOU SEE THEM",
                    Comments = new List<Comment>(),
                    Replies = new List<Reply>(),
                    Tags = new List<Tag>(),
                    Likes = new List<Like>(),
                    DateCreated = DateTime.Now
                },
                new Post{
                    Id = 4,
                    UserId = 4,
                    Title = "Best Multiplayer Games to Play with Friends",
                    Content = "Looking for suggestions on the best multiplayer games to play with friends. Any recommendations?",
                    Comments = new List<Comment>(),
                    Replies = new List<Reply>(),
                    Tags = new List<Tag>(),
                    Likes = new List<Like>(),
                    DateCreated = DateTime.Now
                 },
                 new Post{

                     Id = 5,
                     UserId = 5,
                     Title = "Upcoming Game Releases in 2023",
                     Content = "What are some highly anticipated game releases that we can look forward to in 2023?",
                     Comments = new List<Comment>(),
                     Replies = new List<Reply>(),
                     Tags = new List<Tag>(),
                     Likes = new List<Like>(),
                     DateCreated = DateTime.Now
                  },
                 new Post{
                 
                     Id = 6,
                     UserId = 6,
                     Title = "Game Review: Cyberpunk 2077",
                     Content = "Just finished playing Cyberpunk 2077. Here's my review and thoughts on the game.",
                     Comments = new List<Comment>(),
                     Replies = new List<Reply>(),
                     Tags = new List<Tag>(),
                     Likes = new List<Like>(),
                     DateCreated = DateTime.Now
                 },
                 new Post
                 {
                     Id = 7,
                     UserId = 7,
                     Title = "Tips for Building a Gaming PC",
                     Content = "Looking for tips and recommendations on building a gaming PC. Any advice?",
                     Comments = new List<Comment>(),
                     Replies = new List<Reply>(),
                     Tags = new List<Tag>(),
                     Likes = new List<Like>(),
                     DateCreated = DateTime.Now
                 },
                 new Post
                 {
                     Id = 8,
                     UserId = 8,
                     Title = "Favorite Open-World Games",
                     Content = "What are your favorite open-world games and why? Share your recommendations!",
                     Comments = new List<Comment>(),
                     Replies = new List<Reply>(),
                     Tags = new List<Tag>(),
                     Likes = new List<Like>(),
                     DateCreated = DateTime.Now
                 },
                 new Post
                 {
                     Id = 9,
                     UserId = 9,
                     Title = "Gaming Console Comparison: Xbox vs PlayStation",
                     Content = "Let's discuss the pros and cons of Xbox and PlayStation consoles. Which one do you  prefer     and        why?",
                     Comments = new List<Comment>(),
                     Replies = new List<Reply>(),
                     Tags = new List<Tag>(),
                     Likes = new List<Like>(),
                     DateCreated = DateTime.Now
                 },
                 new Post
                 {
                     Id = 10,
                     UserId = 10,
                     Title = "Best Strategy Games of All Time",
                     Content = "Share your list of the best strategy games of all time. Which ones do you consider must-    play          titles?",
                     Comments = new List<Comment>(),
                     Replies = new List<Reply>(),
                     Tags = new List<Tag>(),
                     Likes = new List<Like>(),
                     DateCreated = DateTime.Now
                 },
                 new Post
                 {
                     Id = 11,
                     UserId = 11,
                     Title = "Retro Gaming: Nostalgic Favorites",
                     Content = "Let's talk about our favorite retro games that bring back nostalgic memories. What are        yours?",
                     Comments = new List<Comment>(),
                     Replies = new List<Reply>(),
                     Tags = new List<Tag>(),
                     Likes = new List<Like>(),
                     DateCreated = DateTime.Now
                 },
                 new Post
                 {
                     Id = 12,
                     UserId = 12,
                     Title = "Game Recommendations for Casual Gamers",
                     Content = "Looking for game recommendations for casual gamers. Any suggestions that are easy to  pick    up     and      play?",
                     Comments = new List<Comment>(),
                     Replies = new List<Reply>(),
                     Tags = new List<Tag>(),
                     Likes = new List<Like>(),
                     DateCreated = DateTime.Now
                 },
                 new Post
                 {
                     Id = 13,
                     UserId = 13,
                     Title = "Most Anticipated Game Sequels",
                     Content = "What are some of the most anticipated game sequels that you can't wait to play? Share   your            excitement!",
                     Comments = new List<Comment>(),
                     Replies = new List<Reply>(),
                     Tags = new List<Tag>(),
                     Likes = new List<Like>(),
                     DateCreated = DateTime.Now
                 },
                 new Post
                 {
                     Id = 14,
                     UserId = 14,
                     Title = "Hidden Gem Games: Underrated and Overlooked",
                     Content = "Discover and discuss hidden gem games that are underrated or often overlooked. Let's  give      them      some   recognition!",
                     Comments = new List<Comment>(),
                     Replies = new List<Reply>(),
                     Tags = new List<Tag>(),
                     Likes = new List<Like>(),
                     DateCreated = DateTime.Now
                 },
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
                    Replies = new List<Reply>(),
                    Likes = new List<Like>()
                },
                new Comment {
                    Id = 2,
                    UserId = 3,
                    PostId = 1,
                    Content = "Idk, looks messy. And I really find the main protag and story dull based on story trailers they've released.",
                    DateCreated = DateTime.Now,
                    Replies = new List<Reply>(),
                    Likes = new List<Like>()
                },
                new Comment {
                    Id = 3,
                    UserId = 1,
                    PostId = 3,
                    Content = "Will be refreshing until I can get it today.",
                    DateCreated = DateTime.Now,
                    Replies = new List<Reply>(),
                    Likes = new List<Like>()
                },
                new Comment
                 {
                     Id = 4,
                     UserId = 4,
                     PostId = 2,
                     Content = "I watched that gameplay video, and it looks amazing! Can't wait to play Immortals Of      Aveum.",
                     DateCreated = DateTime.Now,
                     Replies = new List<Reply>(),
                     Likes = new List<Like>()
                 },
                 new Comment
                 {
                     Id = 5,
                     UserId = 5,
                     PostId = 2,
                     Content = "The graphics and art style in Immortals Of Aveum are stunning. Definitely a game to look     out        for!",
                     DateCreated = DateTime.Now,
                     Replies = new List<Reply>(),
                     Likes = new List<Like>()
                 },
                 new Comment
                 {
                     Id = 6,
                     UserId = 6,
                     PostId = 3,
                     Content = "I preordered Starfield! Can't wait to explore the vastness of space in the game.",
                     DateCreated = DateTime.Now,
                     Replies = new List<Reply>(),
                     Likes = new List<Like>()
                 },
                 new Comment
                 {
                     Id = 7,
                     UserId = 7,
                     PostId = 3,
                     Content = "I'm excited about Starfield's controller and headset. It's going to enhance the  immersive             experience.",
                     DateCreated = DateTime.Now,
                     Replies = new List<Reply>(),
                     Likes = new List<Like>()
                 },
                 new Comment
                 {
                     Id = 8,
                     UserId = 8,
                     PostId = 4,
                     Content = "Some great multiplayer games to play with friends are Among Us, Fortnite, and Rocket       League.",
                     DateCreated = DateTime.Now,
                     Replies = new List<Reply>(),
                     Likes = new List<Like>()
                 },
                 new Comment
                 {
                     Id = 9,
                     UserId = 9,
                     PostId = 4,
                     Content = "I highly recommend trying out Overcooked! It's a fun and chaotic multiplayer game.",
                     DateCreated = DateTime.Now,
                     Replies = new List<Reply>(),
                     Likes = new List<Like>()
                 },
                 new Comment
                 {
                     Id = 10,
                     UserId = 10,
                     PostId = 5,
                     Content = "I'm looking forward to the release of Elder Scrolls VI and Halo Infinite in 2023.",
                     DateCreated = DateTime.Now,
                     Replies = new List<Reply>(),
                     Likes = new List<Like>()
                 },
                 new Comment
                 {
                     Id = 11,
                     UserId = 11,
                     PostId = 5,
                     Content = "2023 is going to be a great year for gaming! So many exciting releases to lookforward      to.",
                     DateCreated = DateTime.Now,
                     Replies = new List<Reply>(),
                     Likes = new List<Like>()
                 },
                 new Comment
                 {
                     Id = 12,
                     UserId = 12,
                     PostId = 6,
                     Content = "I enjoyed playing Cyberpunk 2077, but the bugs and performance issues were    disappointing.",
                     DateCreated = DateTime.Now,
                     Replies = new List<Reply>(),
                     Likes = new List<Like>()
                 },
                 new Comment
                 {
                     Id = 13,
                     UserId = 13,
                     PostId = 6,
                     Content = "I agree, Cyberpunk 2077 had so much potential. Hopefully, future updates will addres   the           issues.",
                     DateCreated = DateTime.Now,
                     Replies = new List<Reply>(),
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

            // Seed the database with tags
            List<Tag> tags = new List<Tag>()
            {
                new Tag { Id = 1, Value = "Indie" },
                new Tag { Id = 2, Value = "Gameplay" },
                new Tag { Id = 3, Value = "Preorder" }
            };
            modelBuilder.Entity<Tag>().ToTable("Tags");
            modelBuilder.Entity<Tag>().HasData(tags);

            modelBuilder.Entity<Tag>()
                .HasMany(tag => tag.Posts)
                .WithMany(post => post.Tags)
                .UsingEntity(j => j.ToTable("PostTags"));

            //Seed the database with replies

            List<Reply> replies = new List<Reply>()
            {
                new Reply
                {
                    Id = 1,
                    UserId = 3,
                    CommentId = 1,
                    Content = "I agree, World of Goo was frustrating at times.",
                    DateCreated = DateTime.Now,
                    Likes = new List<Like>()
                },
                new Reply
                {
                    Id = 2,
                    UserId = 2,
                    CommentId = 1,
                    Content = "Yeah, some levels were really challenging.",
                    DateCreated = DateTime.Now,
                    Likes = new List<Like>()
                },
                new Reply
                {
                    Id = 3,
                    UserId = 1,
                    CommentId = 2,
                    Content = "The protagonist's story in Immortals of Aveum could have been better.",
                    DateCreated = DateTime.Now,
                    Likes = new List<Like>()
                }
            };

            modelBuilder.Entity<Reply>().ToTable("Replies");
            modelBuilder.Entity<Reply>().HasData(replies);
            modelBuilder.Entity<Reply>()
                .HasOne<User>(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Reply>()
                .HasOne<Comment>(r => r.Comment)
                .WithMany(c => c.Replies)
                .HasForeignKey(r => r.CommentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
