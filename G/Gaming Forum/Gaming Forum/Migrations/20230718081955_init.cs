using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gaming_Forum.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
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
                name: "PostTags",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 8192, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Replies_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Replies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Replies_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    ReplyId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Like_Replies_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "Replies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Like_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Indie" },
                    { 2, "Gameplay" },
                    { 3, "Preorder" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "IsActive", "IsAdmin", "IsBlocked", "IsDeleted", "IsLoggedIn", "LastName", "Password", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9376), "Adminkata@gmail.com", "ADMIN", true, true, false, false, false, "ADMINOV", "123456", "0898872323", "admin" },
                    { 2, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9412), "JoroJorkov@abv.bg", "Jorkata", true, false, false, false, false, "Jorov", "123456", null, "george" },
                    { 3, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9415), "PeshoPoshov@abv.bg", "Pesho", true, false, false, false, false, "Peshakov", "123456", null, "peter" },
                    { 4, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9419), "lisa.smith@example.com", "Lisa", true, false, false, false, false, "Smith", "123456", null, "lisa" },
                    { 5, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9422), "john.doe@example.com", "John", true, false, false, false, false, "Doe", "123456", null, "john" },
                    { 6, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9429), "sarah.johnson@example.com", "Sarah", true, false, false, false, false, "Johnson", "123456", null, "sarah" },
                    { 7, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9432), "michael.smith@example.com", "Michael", true, false, false, false, false, "Smith", "123456", null, "michael" },
                    { 8, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9435), "emily.jones@example.com", "Emily", true, false, false, false, false, "Jones", "123456", null, "emily" },
                    { 9, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9439), "alex.wilson@example.com", "Alex", true, false, false, false, false, "Wilson", "123456", null, "alex" },
                    { 10, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9443), "jessica.brown@example.com", "Jessica", true, false, false, false, false, "Brown", "123456", null, "jessica" },
                    { 11, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9447), "ryan.smith@example.com", "Ryan", true, false, false, false, false, "Smith", "123456", null, "ryan" },
                    { 12, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9450), "lily.johnson@example.com", "Lily", true, false, false, false, false, "Johnson", "123456", null, "lily" },
                    { 13, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9453), "david.wilson@example.com", "David", true, false, false, false, false, "Wilson", "123456", null, "david" },
                    { 14, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9456), "olivia.brown@example.com", "Olivia", true, false, false, false, false, "Brown", "123456", null, "olivia" },
                    { 15, new DateTime(2023, 7, 18, 11, 19, 54, 800, DateTimeKind.Local).AddTicks(9459), "ethan.johnson@example.com", "Ethan", true, false, false, false, false, "Johnson", "123456", null, "ethan" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "DateCreated", "IsDeleted", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "I originally wanted to ask \"What was your first indie game?\", but I understand that the definition of what is indie and what isn't can be shaky the further you go back in time.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(551), false, "What was the first indie game you played?", 3 },
                    { 2, "ea let one random lets player record 40 minutes of footage", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(562), false, "Immortals Of Aveum 40 minutes of raw gameplay", 2 },
                    { 3, "DROP THE PREORDER LINKS WHEN YOU SEE THEM", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(565), false, "Starfield controller and headset out now!", 1 },
                    { 4, "Looking for suggestions on the best multiplayer games to play with friends. Any recommendations?", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(569), false, "Best Multiplayer Games to Play with Friends", 4 },
                    { 5, "What are some highly anticipated game releases that we can look forward to in 2023?", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(572), false, "Upcoming Game Releases in 2023", 5 },
                    { 6, "Just finished playing Cyberpunk 2077. Here's my review and thoughts on the game.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(635), false, "Game Review: Cyberpunk 2077", 6 },
                    { 7, "Looking for tips and recommendations on building a gaming PC. Any advice?", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(639), false, "Tips for Building a Gaming PC", 7 },
                    { 8, "What are your favorite open-world games and why? Share your recommendations!", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(642), false, "Favorite Open-World Games", 8 },
                    { 9, "Let's discuss the pros and cons of Xbox and PlayStation consoles. Which one do you  prefer     and        why?", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(646), false, "Gaming Console Comparison: Xbox vs PlayStation", 9 },
                    { 10, "Share your list of the best strategy games of all time. Which ones do you consider must-    play          titles?", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(650), false, "Best Strategy Games of All Time", 10 },
                    { 11, "Let's talk about our favorite retro games that bring back nostalgic memories. What are        yours?", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(653), false, "Retro Gaming: Nostalgic Favorites", 11 },
                    { 12, "Looking for game recommendations for casual gamers. Any suggestions that are easy to  pick    up     and      play?", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(656), false, "Game Recommendations for Casual Gamers", 12 },
                    { 13, "What are some of the most anticipated game sequels that you can't wait to play? Share   your            excitement!", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(660), false, "Most Anticipated Game Sequels", 13 },
                    { 14, "Discover and discuss hidden gem games that are underrated or often overlooked. Let's  give      them      some   recognition!", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(663), false, "Hidden Gem Games: Underrated and Overlooked", 14 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DateCreated", "IsDeleted", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "World of Goo. Got frustrated part way through and never finished.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(1465), false, 1, 2 },
                    { 2, "Idk, looks messy. And I really find the main protag and story dull based on story trailers they've released.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(1475), false, 1, 3 },
                    { 3, "Will be refreshing until I can get it today.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(1478), false, 3, 1 },
                    { 4, "I watched that gameplay video, and it looks amazing! Can't wait to play Immortals Of      Aveum.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(1481), false, 2, 4 },
                    { 5, "The graphics and art style in Immortals Of Aveum are stunning. Definitely a game to look     out        for!", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(1484), false, 2, 5 },
                    { 6, "I preordered Starfield! Can't wait to explore the vastness of space in the game.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(1488), false, 3, 6 },
                    { 7, "I'm excited about Starfield's controller and headset. It's going to enhance the  immersive             experience.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(1491), false, 3, 7 },
                    { 8, "Some great multiplayer games to play with friends are Among Us, Fortnite, and Rocket       League.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(1494), false, 4, 8 },
                    { 9, "I highly recommend trying out Overcooked! It's a fun and chaotic multiplayer game.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(1496), false, 4, 9 },
                    { 10, "I'm looking forward to the release of Elder Scrolls VI and Halo Infinite in 2023.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(1500), false, 5, 10 },
                    { 11, "2023 is going to be a great year for gaming! So many exciting releases to lookforward      to.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(1503), false, 5, 11 },
                    { 12, "I enjoyed playing Cyberpunk 2077, but the bugs and performance issues were    disappointing.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(1506), false, 6, 12 },
                    { 13, "I agree, Cyberpunk 2077 had so much potential. Hopefully, future updates will addres   the           issues.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(1508), false, 6, 13 }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "CommentId", "Content", "DateCreated", "IsDeleted", "PostId", "UserId", "UserId1" },
                values: new object[] { 1, 1, "I agree, World of Goo was frustrating at times.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(3039), false, null, 3, null });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "CommentId", "Content", "DateCreated", "IsDeleted", "PostId", "UserId", "UserId1" },
                values: new object[] { 2, 1, "Yeah, some levels were really challenging.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(3051), false, null, 2, null });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "CommentId", "Content", "DateCreated", "IsDeleted", "PostId", "UserId", "UserId1" },
                values: new object[] { 3, 2, "The protagonist's story in Immortals of Aveum could have been better.", new DateTime(2023, 7, 18, 11, 19, 54, 801, DateTimeKind.Local).AddTicks(3054), false, null, 1, null });

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
                name: "IX_Like_ReplyId",
                table: "Like",
                column: "ReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId",
                table: "Like",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagsId",
                table: "PostTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_CommentId",
                table: "Replies",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_PostId",
                table: "Replies",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_UserId",
                table: "Replies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_UserId1",
                table: "Replies",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
