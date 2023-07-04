using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gaming_Forum.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsLoggedIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 8192, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 8192, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
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
                        name: "FK_PostTag_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Like_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Like_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "IsActive", "IsAdmin", "IsBlocked", "IsDeleted", "IsLoggedIn", "LastName", "Password", "PhoneNumber", "Username" },
                values: new object[] { 1, new DateTime(2023, 7, 4, 16, 39, 50, 511, DateTimeKind.Local).AddTicks(3651), "Adminkata@gmail.com", "ADMIN", true, true, false, false, false, "ADMINOV", "123456", "0898872323", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "IsActive", "IsAdmin", "IsBlocked", "IsDeleted", "IsLoggedIn", "LastName", "Password", "PhoneNumber", "Username" },
                values: new object[] { 2, new DateTime(2023, 7, 4, 16, 39, 50, 511, DateTimeKind.Local).AddTicks(3691), "JoroJorkov@abv.bg", "Jorkata", true, false, false, false, false, "Jorov", "123456", null, "george" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "IsActive", "IsAdmin", "IsBlocked", "IsDeleted", "IsLoggedIn", "LastName", "Password", "PhoneNumber", "Username" },
                values: new object[] { 3, new DateTime(2023, 7, 4, 16, 39, 50, 511, DateTimeKind.Local).AddTicks(3694), "PeshoPoshov@abv.bg", "Pesho", true, false, false, false, false, "Peshakov", "123456", null, "peter" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "DateCreated", "IsDeleted", "PostId", "Title", "UserId" },
                values: new object[] { 1, "I originally wanted to ask \"What was your first indie game?\", but I understand that the definition of what is indie and what isn't can be shaky the further you go back in time.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "What was the first indie game you played?", 3 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "DateCreated", "IsDeleted", "PostId", "Title", "UserId" },
                values: new object[] { 2, "ea let one random lets player record 40 minutes of footage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Immortals Of Aveum 40 minutes of raw gameplay", 2 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "DateCreated", "IsDeleted", "PostId", "Title", "UserId" },
                values: new object[] { 3, "DROP THE PREORDER LINKS WHEN YOU SEE THEM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Starfield controller and headset out now!", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentId", "Content", "DateCreated", "IsDeleted", "PostId", "UserId" },
                values: new object[] { 1, null, "World of Goo. Got frustrated part way through and never finished.", new DateTime(2023, 7, 4, 16, 39, 50, 511, DateTimeKind.Local).AddTicks(5842), false, 1, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentId", "Content", "DateCreated", "IsDeleted", "PostId", "UserId" },
                values: new object[] { 2, null, "Idk, looks messy. And I really find the main protag and story dull based on story trailers they've released.", new DateTime(2023, 7, 4, 16, 39, 50, 511, DateTimeKind.Local).AddTicks(5896), false, 1, 3 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentId", "Content", "DateCreated", "IsDeleted", "PostId", "UserId" },
                values: new object[] { 3, null, "Will be refreshing until I can get it today.", new DateTime(2023, 7, 4, 16, 39, 50, 511, DateTimeKind.Local).AddTicks(5900), false, 3, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_CommentId",
                table: "Like",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_PostId",
                table: "Like",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId",
                table: "Like",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostId",
                table: "Posts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagsId",
                table: "PostTag",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
