using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APTEKA_Software.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    DeliveryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityDelivered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryId);
                    table.ForeignKey(
                        name: "FK_Deliveries_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantitySold = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "AvailableQuantity", "DateCreated", "DeliveryPrice", "IsDeleted", "Name", "SalePrice" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5459), 0m, false, "Валидол", 5m },
                    { 2, 20, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5464), 0m, false, "NoSpa", 10m },
                    { 3, 50, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5466), 0m, false, "Vitamin C", 2m },
                    { 4, 42, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5468), 0m, false, "Vitamin D", 6m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateRegistered", "FirstName", "IsDeleted", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5234), "Peter", false, "Kompotov", "123456", "pesho" },
                    { 2, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5270), "George", false, "Paprikov", "222333", "gosho" },
                    { 3, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5272), "Ivan", false, "Krushov", "432432", "vanio" },
                    { 4, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5275), "Alexander", false, "Slivov", "654321", "sashko" }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "DeliveryId", "DeliveryDate", "ItemId", "QuantityDelivered", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5933), 1, 15, 1 },
                    { 2, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5939), 2, 11, 2 },
                    { 3, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5941), 3, 30, 3 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "ItemId", "QuantitySold", "SaleDate", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 3, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5537), 10.0m, 1 },
                    { 2, 2, 2, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5543), 5.0m, 2 },
                    { 3, 3, 2, new DateTime(2023, 9, 13, 11, 56, 10, 4, DateTimeKind.Local).AddTicks(5546), 20.0m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_ItemId",
                table: "Deliveries",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_UserId",
                table: "Deliveries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ItemId",
                table: "Sales",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
