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
                    DeliveryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityDelivered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryID);
                    table.ForeignKey(
                        name: "FK_Deliveries_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantitySold = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK_Sales_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "AvailableQuantity", "DateCreated", "IsDeleted", "Name", "SalePrice" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2023, 9, 12, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(5691), false, "Валидол", 5m },
                    { 2, 20, new DateTime(2023, 9, 12, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(5696), false, "NoSpa", 10m },
                    { 3, 50, new DateTime(2023, 9, 12, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(5698), false, "Vitamin C", 2m },
                    { 4, 42, new DateTime(2023, 9, 12, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(5701), false, "Vitamin D", 6m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateRegistered", "FirstName", "IsDeleted", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 12, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(5500), "Peter", false, "Kompotov", "123456", "pesho" },
                    { 2, new DateTime(2023, 9, 12, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(5536), "George", false, "Paprikov", "222333", "gosho" },
                    { 3, new DateTime(2023, 9, 12, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(5539), "Ivan", false, "Krushov", "432432", "vanio" },
                    { 4, new DateTime(2023, 9, 12, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(5541), "Alexander", false, "Slivov", "654321", "sashko" }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "DeliveryID", "DeliveryDate", "ItemID", "QuantityDelivered", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 9, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(6186), 1, 15, 1 },
                    { 2, new DateTime(2023, 9, 19, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(6191), 2, 11, 2 },
                    { 3, new DateTime(2023, 9, 16, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(6194), 3, 30, 3 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleID", "ItemID", "QuantitySold", "SaleDate", "TotalAmount", "UserID" },
                values: new object[,]
                {
                    { 1, 1, 3, new DateTime(2023, 9, 20, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(5768), 10.0m, 1 },
                    { 2, 2, 2, new DateTime(2023, 9, 18, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(5774), 5.0m, 2 },
                    { 3, 3, 2, new DateTime(2023, 9, 18, 10, 50, 1, 327, DateTimeKind.Local).AddTicks(5777), 20.0m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_ItemID",
                table: "Deliveries",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_UserID",
                table: "Deliveries",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ItemID",
                table: "Sales",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserID",
                table: "Sales",
                column: "UserID");
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
