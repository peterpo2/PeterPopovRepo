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
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    QuantityDelivered = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
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
                columns: new[] { "Id", "AvailableQuantity", "DateCreated", "IsDeleted", "Name", "SalePrice", "UserId" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2023, 9, 8, 16, 50, 1, 962, DateTimeKind.Local).AddTicks(6303), false, "Валидол", 5m, null },
                    { 2, 20, new DateTime(2023, 9, 8, 16, 50, 1, 962, DateTimeKind.Local).AddTicks(6308), false, "NoSpa", 10m, null },
                    { 3, 50, new DateTime(2023, 9, 8, 16, 50, 1, 962, DateTimeKind.Local).AddTicks(6310), false, "Vitamin C", 2m, null },
                    { 4, 42, new DateTime(2023, 9, 8, 16, 50, 1, 962, DateTimeKind.Local).AddTicks(6312), false, "Vitamin D", 6m, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateRegistered", "FirstName", "IsDeleted", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 8, 16, 50, 1, 962, DateTimeKind.Local).AddTicks(6124), "Peter", false, "Kompotov", "123456", "pesho" },
                    { 2, new DateTime(2023, 9, 8, 16, 50, 1, 962, DateTimeKind.Local).AddTicks(6156), "George", false, "Paprikov", "222333", "gosho" },
                    { 3, new DateTime(2023, 9, 8, 16, 50, 1, 962, DateTimeKind.Local).AddTicks(6159), "Ivan", false, "Krushov", "432432", "vanio" },
                    { 4, new DateTime(2023, 9, 8, 16, 50, 1, 962, DateTimeKind.Local).AddTicks(6161), "Alexander", false, "Slivov", "654321", "sashko" }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "Id", "DeliveryDate", "ItemId", "QuantityDelivered", "UserId" },
                values: new object[] { 1, new DateTime(2023, 9, 8, 16, 50, 1, 962, DateTimeKind.Local).AddTicks(6779), 1, 20, 1 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "ItemId", "Quantity", "SaleDate", "TotalPrice", "UserId" },
                values: new object[] { 1, 1, 5, new DateTime(2023, 9, 8, 16, 50, 1, 962, DateTimeKind.Local).AddTicks(6412), 25.0m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_ItemId",
                table: "Deliveries",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_UserId",
                table: "Deliveries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserId",
                table: "Items",
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
