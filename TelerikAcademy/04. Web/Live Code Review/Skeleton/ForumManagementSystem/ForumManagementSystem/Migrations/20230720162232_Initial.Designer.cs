﻿// <auto-generated />
using System;
using ForumManagementSystem.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230720162232_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ForumManagementSystem.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 3,
                            Content = "This recipe is awesome!",
                            Date = new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5654),
                            PostId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 3,
                            Content = "Very good!",
                            Date = new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5658),
                            PostId = 2
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            Content = "Wow!",
                            Date = new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5660),
                            PostId = 4
                        });
                });

            modelBuilder.Entity("ForumManagementSystem.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OwnerId = 1,
                            PhoneNumber = "0878123456"
                        });
                });

            modelBuilder.Entity("ForumManagementSystem.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 2,
                            Content = "Here is a recipe for a banana smoothie - ready in just 5 minutes!",
                            Date = new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5614),
                            Title = "Healthy breakfast"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Content = "Here is a healthy recipe for a salad with tomatoes and mozzarella!",
                            Date = new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5619),
                            Title = "Healthy lunch"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Content = "Here is a fast recipe breakfast",
                            Date = new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5622),
                            Title = "Breakfast for 5 minutes"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 3,
                            Content = "Very fresh fruit salad with seeds, rich in vitamins!",
                            Date = new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5624),
                            Title = "Fruit Salad with se?ds"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 3,
                            Content = "So this is something I've been experimenting with for a bit, and I wanted to share with you all. It's nothing groundbreaking, but it's helped me a lot. I have two baking stones in my oven and when I make pizza, it's so much easier to transport on parchment on my peel. This is especially since I use Lahey's rather slack pizza dough. I was happy with my crusts, but something was missing. I started taking the parchment out about halfway through and letting the stone come into direct contact with it, and it's made a huge difference. I always just figured that at the super high temp, that moisture was just kind of evaporating anyway, but i think the parchment was still catching some of the sweat. The pizzas go in for a little less than 15 minutes, no parbake, topped and everything, and they've been coming out really good. Enjoy",
                            Date = new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5626),
                            Title = "Great Pizza Tip!"
                        });
                });

            modelBuilder.Entity("ForumManagementSystem.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ForumManagementSystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5414),
                            Email = "admin@yahoo.com",
                            FirstName = "Admin",
                            IsAdmin = true,
                            IsBlocked = false,
                            LastName = "Adminov",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5453),
                            Email = "george@gmail.com",
                            FirstName = "George",
                            IsAdmin = false,
                            IsBlocked = false,
                            LastName = "Georgiev",
                            Username = "george"
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5456),
                            Email = "peter@gmail.com",
                            FirstName = "Peter",
                            IsAdmin = false,
                            IsBlocked = false,
                            LastName = "Peterson",
                            Username = "peter"
                        });
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<int>("PostsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("PostsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("ForumManagementSystem.Models.Comment", b =>
                {
                    b.HasOne("ForumManagementSystem.Models.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId");

                    b.HasOne("ForumManagementSystem.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("ForumManagementSystem.Models.Phone", b =>
                {
                    b.HasOne("ForumManagementSystem.Models.User", "Owner")
                        .WithOne("Phone")
                        .HasForeignKey("ForumManagementSystem.Models.Phone", "OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ForumManagementSystem.Models.Post", b =>
                {
                    b.HasOne("ForumManagementSystem.Models.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("ForumManagementSystem.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForumManagementSystem.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ForumManagementSystem.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("ForumManagementSystem.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Phone");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
