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
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
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
                    QuantityDelivered = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryId);
                    table.ForeignKey(
                        name: "FK_Deliveries_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
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
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "AvailableQuantity", "DateCreated", "IsDeleted", "ItemName", "SalePrice" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(7982), false, "Валидол", 5m },
                    { 2, 20, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(7988), false, "NoSpa", 10m },
                    { 3, 50, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(7990), false, "Vitamin C", 2m },
                    { 4, 42, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(7992), false, "Vitamin D", 6m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateRegistered", "FirstName", "IsAdmin", "IsBlocked", "IsDeleted", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(7608), "Peter", true, false, false, "Kompotov", "123456", "pesho" },
                    { 2, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(7648), "George", false, false, false, "Paprikov", "222333", "gosho" },
                    { 3, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(7650), "Ivan", false, false, false, "Krushov", "432432", "vanio" },
                    { 4, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(7653), "Alexander", false, false, false, "Slivov", "654321", "sashko" }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "DeliveryId", "DeliveryDate", "ItemId", "QuantityDelivered", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(8532), 1, 15, 75m, 1 },
                    { 2, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(8541), 2, 11, 110m, 2 },
                    { 3, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(8543), 3, 30, 60m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "ItemId", "QuantitySold", "SaleDate", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 3, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(8069), 15m, 1 },
                    { 2, 2, 2, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(8075), 20m, 2 },
                    { 3, 3, 2, new DateTime(2023, 10, 4, 12, 12, 40, 95, DateTimeKind.Local).AddTicks(8077), 4m, 3 }
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
