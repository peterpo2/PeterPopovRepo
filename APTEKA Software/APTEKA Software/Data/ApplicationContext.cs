using APTEKA_Software.Models;
using Microsoft.EntityFrameworkCore;

namespace APTEKA_Software.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<User> users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    Username = "pesho",
                    Password = "123456",
                    FirstName = "Peter",
                    LastName = "Kompotov",
                    Items = new List<Item>(),
                    DateRegistered = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    Username = "gosho",
                    Password = "222333",
                    FirstName = "George",
                    LastName = "Paprikov",
                    Items = new List<Item>(),
                    DateRegistered = DateTime.Now
                },
                new User
                {
                    Id = 3,
                    Username = "vanio",
                    Password = "432432",
                    FirstName = "Ivan",
                    LastName = "Krushov",
                    Items = new List<Item>(),
                    DateRegistered = DateTime.Now
                },
                new User
                {
                    Id = 4,
                    Username = "sashko",
                    Password = "654321",
                    FirstName = "Alexander",
                    LastName = "Slivov",
                    Items = new List<Item>(),
                    DateRegistered = DateTime.Now
                },
            };
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasData(users);


            List<Item> items = new List<Item>()
            {
                new Item
                {
                    Id = 1,
                    AvailableQuantity = 10,
                    Name = "Валидол",
                    SalePrice = 5,
                    DateCreated = DateTime.Now,
                },
                new Item
                {
                    Id = 2,
                    AvailableQuantity = 20,
                    Name = "NoSpa",
                    SalePrice = 10,
                    DateCreated = DateTime.Now,
                },
                new Item
                {
                    Id = 3,
                    AvailableQuantity = 50,
                    Name = "Vitamin C",
                    SalePrice = 2,
                    DateCreated = DateTime.Now,
                },
                new Item
                {
                    Id = 4,
                    AvailableQuantity = 42,
                    Name = "Vitamin D",
                    SalePrice = 6,
                    DateCreated = DateTime.Now,
                }
            };
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Item>().HasData(items);

            List<Sale> sales = new List<Sale>()
            {
                new Sale
                {
                    Id = 1,
                    SaleDate = DateTime.Now,
                    ItemId = 1,
                    UserId = 1,
                    Quantity = 5,
                    TotalPrice = 25.0M
                },
            };

            modelBuilder.Entity<Sale>().ToTable("Sales");
            modelBuilder.Entity<Sale>().HasData(sales);

            List<Delivery> deliveries = new List<Delivery>()
            {
                new Delivery
                {
                    Id = 1,
                    ItemId = 1,
                    QuantityDelivered = 20,
                    DeliveryDate = DateTime.Now,
                    UserId = 1
                },
            };

            modelBuilder.Entity<Delivery>().ToTable("Deliveries");
            modelBuilder.Entity<Delivery>().HasData(deliveries);

        }
    }
}
