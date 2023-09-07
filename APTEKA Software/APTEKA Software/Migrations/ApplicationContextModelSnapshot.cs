﻿// <auto-generated />
using System;
using APTEKA_Software.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APTEKA_Software.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APTEKA_Software.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Items", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableQuantity = 10,
                            DateCreated = new DateTime(2023, 9, 7, 1, 58, 22, 314, DateTimeKind.Local).AddTicks(6795),
                            IsDeleted = false,
                            Name = "Validol",
                            SalePrice = 5m,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            AvailableQuantity = 20,
                            DateCreated = new DateTime(2023, 9, 7, 1, 58, 22, 314, DateTimeKind.Local).AddTicks(6805),
                            IsDeleted = false,
                            Name = "NoSpa",
                            SalePrice = 10m,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            AvailableQuantity = 50,
                            DateCreated = new DateTime(2023, 9, 7, 1, 58, 22, 314, DateTimeKind.Local).AddTicks(6807),
                            IsDeleted = false,
                            Name = "Vitamin C",
                            SalePrice = 2m,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            AvailableQuantity = 42,
                            DateCreated = new DateTime(2023, 9, 7, 1, 58, 22, 314, DateTimeKind.Local).AddTicks(6810),
                            IsDeleted = false,
                            Name = "Vitamin D",
                            SalePrice = 6m,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("APTEKA_Software.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Sales", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemId = 1,
                            Quantity = 5,
                            SaleDate = new DateTime(2023, 9, 7, 1, 58, 22, 314, DateTimeKind.Local).AddTicks(7027),
                            TotalPrice = 25.0m,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("APTEKA_Software.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRegistered = new DateTime(2023, 9, 7, 1, 58, 22, 314, DateTimeKind.Local).AddTicks(5867),
                            FirstName = "Peter",
                            IsDeleted = false,
                            LastName = "Kompotov",
                            Password = "123456",
                            Username = "pesho"
                        },
                        new
                        {
                            Id = 2,
                            DateRegistered = new DateTime(2023, 9, 7, 1, 58, 22, 314, DateTimeKind.Local).AddTicks(5901),
                            FirstName = "George",
                            IsDeleted = false,
                            LastName = "Paprikov",
                            Password = "222333",
                            Username = "gosho"
                        },
                        new
                        {
                            Id = 3,
                            DateRegistered = new DateTime(2023, 9, 7, 1, 58, 22, 314, DateTimeKind.Local).AddTicks(5904),
                            FirstName = "Ivan",
                            IsDeleted = false,
                            LastName = "Krushov",
                            Password = "432432",
                            Username = "vanio"
                        },
                        new
                        {
                            Id = 4,
                            DateRegistered = new DateTime(2023, 9, 7, 1, 58, 22, 314, DateTimeKind.Local).AddTicks(5907),
                            FirstName = "Alexander",
                            IsDeleted = false,
                            LastName = "Slivov",
                            Password = "654321",
                            Username = "sashko"
                        });
                });

            modelBuilder.Entity("APTEKA_Software.Models.Item", b =>
                {
                    b.HasOne("APTEKA_Software.Models.User", "User")
                        .WithMany("Items")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("APTEKA_Software.Models.Sale", b =>
                {
                    b.HasOne("APTEKA_Software.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APTEKA_Software.Models.User", "User")
                        .WithMany("Sales")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("APTEKA_Software.Models.User", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}