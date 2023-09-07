using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumManagementSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostTag_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Date", "Email", "FirstName", "IsAdmin", "IsBlocked", "LastName", "Password", "Username" },
                values: new object[] { 1, new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5414), "admin@yahoo.com", "Admin", true, false, "Adminov", null, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Date", "Email", "FirstName", "IsAdmin", "IsBlocked", "LastName", "Password", "Username" },
                values: new object[] { 2, new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5453), "george@gmail.com", "George", false, false, "Georgiev", null, "george" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Date", "Email", "FirstName", "IsAdmin", "IsBlocked", "LastName", "Password", "Username" },
                values: new object[] { 3, new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5456), "peter@gmail.com", "Peter", false, false, "Peterson", null, "peter" });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "OwnerId", "PhoneNumber" },
                values: new object[] { 1, 1, "0878123456" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "Date", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Here is a recipe for a banana smoothie - ready in just 5 minutes!", new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5614), "Healthy breakfast" },
                    { 2, 2, "Here is a healthy recipe for a salad with tomatoes and mozzarella!", new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5619), "Healthy lunch" },
                    { 3, 3, "Here is a fast recipe breakfast", new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5622), "Breakfast for 5 minutes" },
                    { 4, 3, "Very fresh fruit salad with seeds, rich in vitamins!", new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5624), "Fruit Salad with se?ds" },
                    { 5, 3, "So this is something I've been experimenting with for a bit, and I wanted to share with you all. It's nothing groundbreaking, but it's helped me a lot. I have two baking stones in my oven and when I make pizza, it's so much easier to transport on parchment on my peel. This is especially since I use Lahey's rather slack pizza dough. I was happy with my crusts, but something was missing. I started taking the parchment out about halfway through and letting the stone come into direct contact with it, and it's made a huge difference. I always just figured that at the super high temp, that moisture was just kind of evaporating anyway, but i think the parchment was still catching some of the sweat. The pizzas go in for a little less than 15 minutes, no parbake, topped and everything, and they've been coming out really good. Enjoy", new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5626), "Great Pizza Tip!" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "Date", "PostId" },
                values: new object[] { 1, 3, "This recipe is awesome!", new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5654), 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "Date", "PostId" },
                values: new object[] { 2, 3, "Very good!", new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5658), 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "Date", "PostId" },
                values: new object[] { 3, 2, "Wow!", new DateTime(2023, 7, 20, 19, 22, 32, 611, DateTimeKind.Local).AddTicks(5660), 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_OwnerId",
                table: "Phones",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagsId",
                table: "PostTag",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
