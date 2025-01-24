using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraduationProjectAPI.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessibilityType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageOnline = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libraryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    libraryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Study = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paypal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    writerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookPrice = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    bookImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageOnline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdBookType = table.Column<int>(type: "int", nullable: false),
                    BookTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_BookTypes_BookTypeId",
                        column: x => x.BookTypeId,
                        principalTable: "BookTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdContent = table.Column<int>(type: "int", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageOnline = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    referenceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdContent = table.Column<int>(type: "int", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.Id);
                    table.ForeignKey(
                        name: "FK_References_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    test = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdContent = table.Column<int>(type: "int", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    complaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    followId = table.Column<int>(type: "int", nullable: true),
                    followedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follows_Users_followId",
                        column: x => x.followId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Follows_Users_followedId",
                        column: x => x.followedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameUsers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookLibraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBook = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    IdLibrary = table.Column<int>(type: "int", nullable: false),
                    LibraryId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLibraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookLibraries_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookLibraries_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookWriters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBook = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    IdWriter = table.Column<int>(type: "int", nullable: false),
                    WriterId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookWriters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookWriters_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookWriters_Writers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Writers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageOnline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IdContent = table.Column<int>(type: "int", nullable: true),
                    ContentId = table.Column<int>(type: "int", nullable: true),
                    IdGroup = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGroup = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserReferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IdReference = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserReferences_References_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "References",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserReferences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<bool>(type: "bit", nullable: false),
                    IdTest = table.Column<int>(type: "int", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAccessibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAccessibility = table.Column<int>(type: "int", nullable: true),
                    AccessibilityId = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IdGroup = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    IdLibrary = table.Column<int>(type: "int", nullable: true),
                    LibraryId = table.Column<int>(type: "int", nullable: true),
                    IdTest = table.Column<int>(type: "int", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    IdReference = table.Column<int>(type: "int", nullable: true),
                    ReferenceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccessibilities_Accessibilities_AccessibilityId",
                        column: x => x.AccessibilityId,
                        principalTable: "Accessibilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAccessibilities_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAccessibilities_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAccessibilities_References_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "References",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAccessibilities_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAccessibilities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Buybooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IdBookLibrary = table.Column<int>(type: "int", nullable: false),
                    BookLibraryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buybooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buybooks_BookLibraries_BookLibraryId",
                        column: x => x.BookLibraryId,
                        principalTable: "BookLibraries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Buybooks_Users_UserId",
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
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPost = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Interaction = table.Column<bool>(type: "bit", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IdPost = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Accessibilities",
                columns: new[] { "Id", "AccessibilityType" },
                values: new object[,]
                {
                    { 1, "All" },
                    { 2, "Add" },
                    { 3, "Update" },
                    { 4, "Delete" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "CorrectAnswer", "IdTest", "TestId", "answer" },
                values: new object[,]
                {
                    { 1, true, 1, null, "yes" },
                    { 2, false, 1, null, "No" },
                    { 3, true, 2, null, "yes" },
                    { 4, false, 2, null, "No" },
                    { 5, true, 3, null, "yes" },
                    { 6, false, 3, null, "No" },
                    { 7, true, 4, null, "yes" },
                    { 8, false, 4, null, "No" }
                });

            migrationBuilder.InsertData(
                table: "BookLibraries",
                columns: new[] { "Id", "BookId", "IdBook", "IdLibrary", "IsDeleted", "LibraryId" },
                values: new object[,]
                {
                    { 1, null, 1, 1, false, null },
                    { 2, null, 2, 1, false, null },
                    { 3, null, 3, 1, false, null },
                    { 4, null, 4, 1, false, null },
                    { 5, null, 5, 1, false, null },
                    { 6, null, 6, 1, false, null },
                    { 7, null, 7, 1, false, null },
                    { 8, null, 8, 1, false, null },
                    { 9, null, 9, 1, false, null },
                    { 10, null, 10, 1, false, null },
                    { 11, null, 11, 1, false, null },
                    { 12, null, 12, 1, false, null },
                    { 13, null, 13, 1, false, null },
                    { 14, null, 14, 1, false, null },
                    { 15, null, 15, 1, false, null },
                    { 16, null, 16, 1, false, null },
                    { 17, null, 17, 1, false, null },
                    { 18, null, 18, 1, false, null },
                    { 19, null, 19, 1, false, null },
                    { 20, null, 20, 1, false, null },
                    { 21, null, 21, 1, false, null },
                    { 22, null, 22, 1, false, null },
                    { 23, null, 23, 1, false, null },
                    { 24, null, 24, 1, false, null },
                    { 25, null, 25, 1, false, null },
                    { 26, null, 26, 1, false, null },
                    { 27, null, 27, 1, false, null },
                    { 28, null, 28, 1, false, null },
                    { 29, null, 29, 1, false, null },
                    { 30, null, 30, 1, false, null },
                    { 31, null, 31, 1, false, null },
                    { 32, null, 32, 1, false, null },
                    { 33, null, 33, 1, false, null },
                    { 34, null, 34, 1, false, null },
                    { 35, null, 1, 2, false, null },
                    { 36, null, 2, 2, false, null },
                    { 37, null, 3, 2, false, null },
                    { 38, null, 4, 2, false, null },
                    { 39, null, 5, 2, false, null },
                    { 40, null, 6, 2, false, null },
                    { 41, null, 7, 2, false, null },
                    { 42, null, 8, 2, false, null },
                    { 43, null, 9, 2, false, null },
                    { 44, null, 10, 2, false, null },
                    { 45, null, 11, 2, false, null },
                    { 46, null, 12, 2, false, null },
                    { 47, null, 13, 2, false, null },
                    { 48, null, 14, 2, false, null },
                    { 49, null, 15, 2, false, null },
                    { 50, null, 16, 2, false, null },
                    { 51, null, 17, 2, false, null },
                    { 52, null, 18, 2, false, null },
                    { 53, null, 19, 2, false, null },
                    { 54, null, 20, 2, false, null },
                    { 55, null, 21, 2, false, null },
                    { 56, null, 22, 2, false, null },
                    { 57, null, 23, 2, false, null },
                    { 58, null, 24, 2, false, null },
                    { 59, null, 25, 2, false, null },
                    { 60, null, 26, 2, false, null },
                    { 61, null, 27, 2, false, null },
                    { 62, null, 28, 2, false, null },
                    { 63, null, 29, 2, false, null },
                    { 64, null, 30, 2, false, null },
                    { 65, null, 31, 2, false, null },
                    { 66, null, 32, 2, false, null },
                    { 67, null, 33, 2, false, null },
                    { 68, null, 34, 2, false, null },
                    { 69, null, 1, 3, false, null },
                    { 70, null, 2, 3, false, null },
                    { 71, null, 3, 3, false, null },
                    { 72, null, 4, 3, false, null },
                    { 73, null, 5, 3, false, null },
                    { 74, null, 6, 3, false, null },
                    { 75, null, 7, 3, false, null },
                    { 76, null, 8, 3, false, null },
                    { 77, null, 9, 3, false, null },
                    { 78, null, 10, 3, false, null },
                    { 79, null, 11, 3, false, null },
                    { 80, null, 12, 3, false, null },
                    { 81, null, 13, 3, false, null },
                    { 82, null, 14, 3, false, null },
                    { 83, null, 15, 3, false, null },
                    { 84, null, 16, 3, false, null },
                    { 85, null, 17, 3, false, null },
                    { 86, null, 18, 3, false, null },
                    { 87, null, 19, 3, false, null },
                    { 88, null, 20, 3, false, null },
                    { 89, null, 21, 3, false, null },
                    { 90, null, 22, 3, false, null },
                    { 91, null, 23, 3, false, null },
                    { 92, null, 24, 3, false, null },
                    { 93, null, 25, 3, false, null },
                    { 94, null, 26, 3, false, null },
                    { 95, null, 27, 3, false, null },
                    { 96, null, 28, 3, false, null },
                    { 97, null, 29, 3, false, null },
                    { 98, null, 30, 3, false, null },
                    { 99, null, 31, 3, false, null },
                    { 100, null, 32, 3, false, null },
                    { 101, null, 33, 3, false, null },
                    { 102, null, 34, 3, false, null },
                    { 103, null, 1, 4, false, null },
                    { 104, null, 2, 4, false, null },
                    { 105, null, 3, 4, false, null },
                    { 106, null, 4, 4, false, null },
                    { 107, null, 5, 4, false, null },
                    { 108, null, 6, 4, false, null },
                    { 109, null, 7, 4, false, null },
                    { 110, null, 8, 4, false, null },
                    { 111, null, 9, 4, false, null },
                    { 112, null, 10, 4, false, null },
                    { 113, null, 11, 4, false, null },
                    { 114, null, 12, 4, false, null },
                    { 115, null, 13, 4, false, null },
                    { 116, null, 14, 4, false, null },
                    { 117, null, 15, 4, false, null },
                    { 118, null, 16, 4, false, null },
                    { 119, null, 17, 4, false, null },
                    { 120, null, 18, 4, false, null },
                    { 121, null, 19, 4, false, null },
                    { 122, null, 20, 4, false, null },
                    { 123, null, 21, 4, false, null },
                    { 124, null, 22, 4, false, null },
                    { 125, null, 23, 4, false, null },
                    { 126, null, 24, 4, false, null },
                    { 127, null, 25, 4, false, null },
                    { 128, null, 26, 4, false, null },
                    { 129, null, 27, 4, false, null },
                    { 130, null, 28, 4, false, null },
                    { 131, null, 29, 4, false, null },
                    { 132, null, 30, 4, false, null },
                    { 133, null, 31, 4, false, null },
                    { 134, null, 32, 4, false, null },
                    { 135, null, 33, 4, false, null },
                    { 136, null, 34, 4, false, null }
                });

            migrationBuilder.InsertData(
                table: "BookTypes",
                columns: new[] { "Id", "IsDeleted", "bookType" },
                values: new object[,]
                {
                    { 1, false, "Self Development" },
                    { 2, false, "Police Novels" },
                    { 3, false, "Psychology" },
                    { 4, false, "Marketing" },
                    { 5, false, "History" },
                    { 6, false, "Sport" }
                });

            migrationBuilder.InsertData(
                table: "BookWriters",
                columns: new[] { "Id", "BookId", "IdBook", "IdWriter", "IsDeleted", "WriterId" },
                values: new object[,]
                {
                    { 1, null, 1, 1, false, null },
                    { 2, null, 2, 2, false, null },
                    { 3, null, 3, 3, false, null },
                    { 4, null, 4, 4, false, null },
                    { 5, null, 5, 5, false, null },
                    { 6, null, 6, 6, false, null },
                    { 7, null, 7, 7, false, null },
                    { 8, null, 8, 8, false, null },
                    { 9, null, 9, 9, false, null },
                    { 10, null, 10, 10, false, null },
                    { 11, null, 11, 11, false, null },
                    { 12, null, 12, 12, false, null },
                    { 13, null, 15, 12, false, null },
                    { 14, null, 13, 13, false, null },
                    { 15, null, 14, 14, false, null },
                    { 16, null, 16, 15, false, null },
                    { 17, null, 17, 15, false, null },
                    { 18, null, 18, 15, false, null },
                    { 19, null, 19, 15, false, null },
                    { 20, null, 20, 15, false, null },
                    { 21, null, 21, 16, false, null },
                    { 22, null, 22, 17, false, null },
                    { 23, null, 23, 18, false, null },
                    { 24, null, 24, 19, false, null },
                    { 25, null, 25, 20, false, null },
                    { 26, null, 26, 21, false, null },
                    { 27, null, 27, 22, false, null },
                    { 28, null, 28, 23, false, null },
                    { 29, null, 29, 24, false, null },
                    { 30, null, 30, 25, false, null },
                    { 31, null, 31, 26, false, null },
                    { 32, null, 32, 27, false, null },
                    { 33, null, 33, 28, false, null },
                    { 34, null, 34, 29, false, null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookName", "BookPrice", "BookTypeId", "IdBookType", "ImageOnline", "IsDeleted", "bookImage" },
                values: new object[,]
                {
                    { 1, "Happy Planning", 1000, null, 1, "https://i.ibb.co/nR1gVnp/images-q-tbn-ANd9-Gc-TOHUK4p-Rvv-Aj3-H8-82kl-OYjb-DIDYsmlx-JLBw-s.jpg", false, null },
                    { 2, "The High 5 Habit", 1000, null, 1, "https://i.ibb.co/j8tZ7Vw/71-Dp-YJgr-Bp-L-AC-UF1000-1000-QL80.jpg", false, null },
                    { 3, "Big Magic", 1000, null, 1, "https://i.ibb.co/VQ2XmtQ/814-Po-Pnr-BQL.jpg", false, null },
                    { 4, "Set Boundaries ,Find Peace", 1000, null, 1, "https://i.ibb.co/vmNSCLF/416-Fj8-Hb6o-L-AC-SY200-QL15.jpg", false, null },
                    { 5, "The Power Of Writing It Down", 1000, null, 1, "https://i.ibb.co/ySZQsyF/71hyo-OY1xu-L-AC-UF1000-1000-QL80.jpg", false, null },
                    { 6, "Life Is In The Transitions", 1000, null, 1, "https://i.ibb.co/0Y5Jc8W/714vn15-Nyx-L-AC-UF1000-1000-QL80.jpg", false, null },
                    { 7, "Why Social Media is Ruining Your Life", 1000, null, 1, "https://i.ibb.co/5Rt5Rjt/38509966.jpg", false, null },
                    { 8, "Peak Mind", 1000, null, 1, "https://i.ibb.co/NTzTDbK/71-Uqm-q-Ds9-L.jpg", false, null },
                    { 9, "Working Hard, Hardly Working", 1000, null, 1, "https://i.ibb.co/BL01qMh/57086146.jpg", false, null },
                    { 10, "The Everyday Hero Manifesto", 1000, null, 1, "https://i.ibb.co/XzLfwFz/711-Rrs3-Tb-UL-AC-UF1000-1000-QL80.jpg", false, null },
                    { 11, "All Of Us Are Broken", 1000, null, 2, "https://i.ibb.co/vQ0rqh1/images-q-tbn-ANd9-Gc-S21v-XUs-Oi-UAR8-OOatxhfsmr-SR43-Llb-Ipk-XFw-s.jpg", false, null },
                    { 12, "Burial Of Ghosts", 1000, null, 2, "https://i.ibb.co/wM80pgV/810-V9ul77j-L-UF1000-1000-QL80.jpg", false, null },
                    { 13, "The Cat Who Caught A Killer", 1000, null, 2, "https://i.ibb.co/jr0MvXM/61171523.jpg", false, null },
                    { 14, "Dirt Town", 1000, null, 2, "https://i.ibb.co/yPfZHRr/59633393.jpg", false, null },
                    { 15, "The Rising Tide", 1000, null, 2, "https://i.ibb.co/yRVrQnn/58413941.jpg", false, null },
                    { 16, "A Murder is Announced", 1000, null, 2, "https://i.ibb.co/6ByLwBm/81-C-MXPJZz-L-AC-UF1000-1000-QL80.jpg", false, null },
                    { 17, "The Mysterious Affair at Styles", 1000, null, 2, "https://i.ibb.co/pz7fJTn/91-OPp9ldt9-L-AC-UF1000-1000-QL80.jpg", false, null },
                    { 18, "The Murder of Roger Ackroyd", 1000, null, 2, "https://i.ibb.co/3sMVj94/81ps3-TVSf-SL-AC-UF1000-1000-QL80.jpg", false, null },
                    { 19, "Murder on the Orient Express", 1000, null, 2, "https://i.ibb.co/n8JZy4m/853510.jpg", false, null },
                    { 20, "Crooked House", 1000, null, 2, "https://i.ibb.co/wwFGqRS/Crooked-House-First-Edition-Cover-1949.jpg", false, null },
                    { 21, "Thinking, Fast and Slow", 1000, null, 3, "https://i.ibb.co/nk2yv0s/61fdr-Eu-PJw-L.jpg", false, null },
                    { 22, "Influence: Science and Practice", 1000, null, 3, "https://i.ibb.co/LPcwgXX/71txgfwih-YL.jpg", false, null },
                    { 23, "The Happiness Hypothesis", 1000, null, 3, "https://i.ibb.co/3mTszXQ/81z-C1p-SRNIL.jpg", false, null },
                    { 24, "Predictably Irrational", 1000, null, 3, "https://i.ibb.co/58qp7nw/61cj-ZXBNl2-L.jpg", false, null },
                    { 25, "Emotional Intelligence", 1000, null, 3, "https://i.ibb.co/FHg4gJN/71z-XQz-Rcl-L.jpg", false, null },
                    { 26, "Contagious: Why Things Catch On", 1000, null, 4, "https://i.ibb.co/CH8Zc7g/61x-FJd8-Oz-ML.jpg", false, null },
                    { 27, "This is Marketing: You Can’t Be Seen Until You Learn To See", 1000, null, 4, "https://i.ibb.co/TL1z87C/71un70-E9wh-L.jpg", false, null },
                    { 28, "Building a StoryBrand: Clarify Your Message So Customers Will Listen", 1000, null, 4, "https://i.ibb.co/yf239WG/71-M92-Awhq-IL.jpg", false, null },
                    { 29, "Blue Ocean Strategy", 1000, null, 4, "https://i.ibb.co/syv0MC7/91-YCWH4j-Fd-L-AC-UF894-1000-QL80.jpg", false, null },
                    { 30, "Top of Mind (PB)", 1000, null, 4, "https://i.ibb.co/RjBkkLN/71-Dczw-Xi-W5-L.jpg", false, null },
                    { 31, "The Guns of August", 1000, null, 5, "https://i.ibb.co/zRBp0Fz/71vkx-Iftlz-L.jpg", false, null },
                    { 32, "Guns, Germs, and Steel", 1000, null, 5, "https://i.ibb.co/0FvywGZ/61-V8g4-Ggqd-L-AC-UF1000-1000-QL80.jpg", false, null },
                    { 33, "1776", 1000, null, 5, "https://i.ibb.co/YkMLfDQ/81j0-BRX2-FHL-AC-UF894-1000-QL80.jpg", false, null },
                    { 34, "The Devil in the White City", 1000, null, 5, "https://i.ibb.co/JyXqPPV/91-Nr-JMBpqc-L-AC-UF894-1000-QL80.jpg", false, null }
                });

            migrationBuilder.InsertData(
                table: "Buybooks",
                columns: new[] { "Id", "Address", "BookLibraryId", "Count", "IdBookLibrary", "IdUser", "Price", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, 3, 1, 1, 3000.0, null },
                    { 2, null, null, 4, 42, 1, 4000.0, null },
                    { 3, null, null, 3, 83, 1, 3000.0, null },
                    { 4, null, null, 3, 124, 1, 3000.0, null },
                    { 5, null, null, 3, 5, 2, 3000.0, null },
                    { 6, null, null, 3, 55, 2, 3000.0, null },
                    { 7, null, null, 3, 56, 2, 3000.0, null },
                    { 8, null, null, 3, 123, 2, 3000.0, null },
                    { 9, null, null, 3, 136, 2, 3000.0, null },
                    { 10, null, null, 3, 7, 3, 3000.0, null },
                    { 11, null, null, 3, 45, 3, 3000.0, null },
                    { 12, null, null, 3, 88, 3, 3000.0, null },
                    { 13, null, null, 3, 102, 3, 3000.0, null },
                    { 14, null, null, 3, 9, 4, 3000.0, null },
                    { 15, null, null, 3, 27, 4, 3000.0, null },
                    { 16, null, null, 3, 89, 4, 3000.0, null },
                    { 17, null, null, 3, 135, 4, 3000.0, null },
                    { 18, null, null, 3, 33, 5, 3000.0, null },
                    { 19, null, null, 3, 44, 5, 3000.0, null },
                    { 20, null, null, 3, 122, 5, 3000.0, null },
                    { 21, null, null, 3, 134, 5, 3000.0, null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Comment", "IdPost", "IdUser", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Wow", 1, 2, null, null },
                    { 2, "i do not Now That Before", 1, 3, null, null },
                    { 3, "very silly", 1, 4, null, null },
                    { 4, "nice one!", 1, 5, null, null },
                    { 5, "Wow", 2, 2, null, null },
                    { 6, "i do not Now That Before", 2, 3, null, null },
                    { 7, "very silly", 2, 4, null, null },
                    { 8, "nice one!", 2, 5, null, null },
                    { 9, "Wow", 3, 2, null, null },
                    { 10, "i do not Now That Before", 3, 3, null, null },
                    { 11, "very silly", 3, 4, null, null },
                    { 12, "nice one!", 3, 5, null, null },
                    { 13, "Wow", 4, 2, null, null },
                    { 14, "i do not Now That Before", 4, 3, null, null },
                    { 15, "very silly", 4, 4, null, null },
                    { 16, "nice one!", 4, 5, null, null },
                    { 17, "Wow", 5, 2, null, null },
                    { 18, "i do not Now That Before", 5, 3, null, null },
                    { 19, "very silly", 5, 4, null, null },
                    { 20, "nice one!", 5, 5, null, null },
                    { 21, "Wow", 6, 2, null, null },
                    { 22, "i do not Now That Before", 6, 3, null, null },
                    { 23, "very silly", 6, 4, null, null },
                    { 24, "nice one!", 6, 5, null, null },
                    { 25, "Wow", 7, 2, null, null },
                    { 26, "i do not Now That Before", 7, 3, null, null },
                    { 27, "very silly", 7, 4, null, null },
                    { 28, "nice one!", 7, 5, null, null },
                    { 29, "Wow", 8, 2, null, null },
                    { 30, "i do not Now That Before", 8, 3, null, null },
                    { 31, "very silly", 8, 4, null, null },
                    { 32, "nice one!", 8, 5, null, null },
                    { 33, "Wow", 9, 2, null, null },
                    { 34, "i do not Now That Before", 9, 3, null, null },
                    { 35, "very silly", 9, 4, null, null },
                    { 36, "nice one!", 9, 5, null, null },
                    { 37, "Wow", 10, 2, null, null },
                    { 38, "i do not Now That Before", 10, 3, null, null },
                    { 39, "very silly", 10, 4, null, null },
                    { 40, "nice one!", 10, 5, null, null },
                    { 41, "Wow", 11, 2, null, null },
                    { 42, "i do not Now That Before", 11, 3, null, null },
                    { 43, "very silly", 11, 4, null, null },
                    { 44, "nice one!", 11, 5, null, null },
                    { 45, "Wow", 12, 2, null, null },
                    { 46, "i do not Now That Before", 12, 3, null, null },
                    { 47, "very silly", 12, 4, null, null },
                    { 48, "nice one!", 12, 5, null, null },
                    { 49, "Wow", 13, 2, null, null },
                    { 50, "i do not Now That Before", 13, 3, null, null },
                    { 51, "very silly", 13, 4, null, null },
                    { 52, "nice one!", 13, 5, null, null },
                    { 53, "good", 13, 5, null, null },
                    { 54, "Wow", 14, 2, null, null },
                    { 55, "i do not Now That Before", 14, 3, null, null },
                    { 56, "very silly", 14, 4, null, null },
                    { 57, "nice one!", 14, 5, null, null },
                    { 58, "good", 14, 5, null, null },
                    { 59, "Wow", 15, 2, null, null },
                    { 60, "i do not Now That Before", 15, 3, null, null },
                    { 61, "very silly", 15, 4, null, null },
                    { 62, "nice one!", 15, 5, null, null },
                    { 63, "good", 15, 5, null, null },
                    { 64, "Wow", 16, 2, null, null },
                    { 65, "i do not Now That Before", 16, 3, null, null },
                    { 66, "very silly", 16, 4, null, null },
                    { 67, "nice one!", 16, 5, null, null },
                    { 68, "good", 16, 5, null, null },
                    { 69, "Wow", 17, 2, null, null },
                    { 70, "i do not Now That Before", 17, 3, null, null },
                    { 71, "very silly", 17, 4, null, null },
                    { 72, "nice one!", 17, 5, null, null },
                    { 73, "good", 17, 5, null, null },
                    { 74, "Wow", 18, 2, null, null },
                    { 75, "i do not Now That Before", 18, 3, null, null },
                    { 76, "very silly", 18, 4, null, null },
                    { 77, "nice one!", 18, 5, null, null },
                    { 78, "good", 18, 5, null, null },
                    { 79, "Wow", 19, 2, null, null },
                    { 80, "i do not Now That Before", 19, 3, null, null },
                    { 81, "very silly", 19, 4, null, null },
                    { 82, "nice one!", 19, 5, null, null },
                    { 83, "good", 19, 5, null, null },
                    { 84, "Wow", 20, 2, null, null },
                    { 85, "i do not Now That Before", 20, 3, null, null },
                    { 86, "very silly", 20, 4, null, null },
                    { 87, "nice one!", 20, 5, null, null },
                    { 88, "good", 20, 5, null, null },
                    { 89, "Wow", 22, 2, null, null },
                    { 90, "i do not Now That Before", 22, 3, null, null },
                    { 91, "very silly", 22, 4, null, null },
                    { 92, "nice one!", 22, 5, null, null },
                    { 93, "good", 22, 5, null, null },
                    { 94, "Wow", 23, 2, null, null },
                    { 95, "i do not Now That Before", 23, 3, null, null },
                    { 96, "very silly", 23, 4, null, null },
                    { 97, "nice one!", 23, 5, null, null },
                    { 98, "good", 23, 5, null, null },
                    { 99, "Wow", 24, 2, null, null },
                    { 100, "i do not Now That Before", 24, 3, null, null },
                    { 101, "very silly", 24, 4, null, null },
                    { 102, "nice one!", 24, 5, null, null },
                    { 103, "good", 24, 5, null, null },
                    { 104, "Wow", 25, 2, null, null },
                    { 105, "i do not Now That Before", 25, 3, null, null },
                    { 106, "very silly", 25, 4, null, null },
                    { 107, "nice one!", 25, 5, null, null },
                    { 108, "good", 25, 5, null, null },
                    { 109, "Wow", 26, 2, null, null },
                    { 110, "i do not Now That Before", 26, 3, null, null },
                    { 111, "very silly", 26, 4, null, null },
                    { 112, "nice one!", 26, 5, null, null },
                    { 113, "good", 26, 5, null, null },
                    { 114, "Wow", 27, 2, null, null },
                    { 115, "i do not Now That Before", 27, 3, null, null },
                    { 116, "very silly", 27, 4, null, null },
                    { 117, "nice one!", 27, 5, null, null },
                    { 118, "good", 27, 5, null, null },
                    { 119, "Wow", 28, 2, null, null },
                    { 120, "i do not Now That Before", 28, 3, null, null },
                    { 121, "very silly", 28, 4, null, null },
                    { 122, "nice one!", 28, 5, null, null },
                    { 123, "good", 28, 5, null, null },
                    { 124, "Wow", 29, 2, null, null },
                    { 125, "i do not Now That Before", 29, 3, null, null },
                    { 126, "very silly", 29, 4, null, null },
                    { 127, "nice one!", 29, 5, null, null },
                    { 128, "good", 29, 5, null, null },
                    { 129, "Wow", 30, 2, null, null },
                    { 130, "i do not Now That Before", 30, 3, null, null },
                    { 131, "very silly", 30, 4, null, null },
                    { 132, "nice one!", 30, 5, null, null },
                    { 133, "good!", 30, 5, null, null },
                    { 134, "Wow", 31, 2, null, null },
                    { 135, "i do not Now That Before", 31, 3, null, null },
                    { 136, "very silly", 31, 4, null, null },
                    { 137, "nice one!", 31, 5, null, null },
                    { 138, "good", 31, 5, null, null },
                    { 139, "Wow", 32, 2, null, null },
                    { 140, "i do not Now That Before", 32, 3, null, null },
                    { 141, "very silly", 32, 4, null, null },
                    { 142, "nice one!", 32, 5, null, null },
                    { 143, "good!", 32, 5, null, null },
                    { 144, "Wow", 33, 2, null, null },
                    { 145, "i do not Now That Before", 33, 3, null, null },
                    { 146, "very silly", 33, 4, null, null },
                    { 147, "nice one!", 33, 5, null, null },
                    { 148, "good", 33, 5, null, null },
                    { 149, "Wow", 34, 2, null, null },
                    { 150, "i do not Now That Before", 34, 3, null, null },
                    { 151, "very silly", 34, 4, null, null },
                    { 152, "nice one!", 34, 5, null, null },
                    { 153, "good", 34, 5, null, null },
                    { 154, "Wow", 35, 2, null, null },
                    { 155, "i do not Now That Before", 35, 3, null, null },
                    { 156, "very silly", 35, 4, null, null },
                    { 157, "nice one!", 35, 5, null, null },
                    { 158, "good", 35, 5, null, null },
                    { 159, "Wow", 36, 2, null, null },
                    { 160, "i do not Now That Before", 36, 3, null, null },
                    { 161, "very silly", 36, 4, null, null },
                    { 162, "nice one!", 36, 5, null, null },
                    { 163, "good!", 36, 5, null, null },
                    { 164, "Wow", 37, 2, null, null },
                    { 165, "i do not Now That Before", 37, 3, null, null },
                    { 166, "very silly", 37, 4, null, null },
                    { 167, "nice one!", 37, 5, null, null },
                    { 168, "good", 37, 5, null, null },
                    { 169, "Wow", 38, 2, null, null },
                    { 170, "i do not Now That Before", 38, 3, null, null },
                    { 171, "very silly", 38, 4, null, null },
                    { 172, "nice one!", 38, 5, null, null },
                    { 173, "good!", 38, 5, null, null },
                    { 174, "Wow", 39, 2, null, null },
                    { 175, "i do not Now That Before", 39, 3, null, null },
                    { 176, "very silly", 39, 4, null, null },
                    { 177, "nice one!", 39, 5, null, null },
                    { 178, "good", 39, 5, null, null },
                    { 179, "Wow", 41, 2, null, null },
                    { 180, "i do not Now That Before", 41, 3, null, null },
                    { 181, "very silly", 41, 4, null, null },
                    { 182, "nice one!", 41, 5, null, null }
                });

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "IdUser", "UserId", "complaint", "type" },
                values: new object[,]
                {
                    { 1, 2, null, "Please accept my request to join the group", 0 },
                    { 2, 2, null, "I want to have admin authority", 1 },
                    { 3, 2, null, "Please allow me to add new content", 2 },
                    { 4, 3, null, "Please accept my request to join the group", 0 },
                    { 5, 3, null, "I want to have admin authority", 1 },
                    { 6, 3, null, "Please allow me to add new content", 2 },
                    { 7, 4, null, "Please accept my request to join the group", 0 },
                    { 8, 4, null, "I want to have admin authority", 1 },
                    { 9, 4, null, "Please allow me to add new content", 2 },
                    { 10, 5, null, "Please accept my request to join the group", 0 },
                    { 11, 5, null, "I want to have admin authority", 1 },
                    { 12, 5, null, "Please allow me to add new content", 2 }
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "typeName" },
                values: new object[,]
                {
                    { 1, "Physics" },
                    { 2, "Earth" },
                    { 3, "Medicine" },
                    { 4, "Technology" },
                    { 5, "General Science" }
                });

            migrationBuilder.InsertData(
                table: "GameUsers",
                columns: new[] { "Id", "GameId", "IdGame", "IdUser", "Score", "UserId", "userLevel" },
                values: new object[,]
                {
                    { 1, null, 1, 2, 1, null, "1" },
                    { 2, null, 2, 2, 1, null, "1" },
                    { 3, null, 3, 2, 1, null, "1" },
                    { 4, null, 4, 2, 1, null, "1" },
                    { 5, null, 5, 2, 1, null, "1" },
                    { 6, null, 1, 3, 1, null, "1" },
                    { 7, null, 2, 3, 1, null, "1" },
                    { 8, null, 3, 3, 1, null, "1" },
                    { 9, null, 4, 3, 1, null, "1" },
                    { 10, null, 5, 3, 1, null, "1" },
                    { 11, null, 1, 4, 1, null, "1" },
                    { 12, null, 2, 4, 1, null, "1" },
                    { 13, null, 3, 4, 1, null, "1" },
                    { 14, null, 4, 4, 1, null, "1" },
                    { 15, null, 5, 4, 1, null, "1" },
                    { 16, null, 1, 5, 1, null, "1" },
                    { 17, null, 2, 5, 1, null, "1" },
                    { 18, null, 3, 5, 1, null, "1" },
                    { 19, null, 4, 5, 1, null, "1" },
                    { 20, null, 5, 5, 1, null, "1" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "GameLevel", "GameName", "Image", "ImageOnline" },
                values: new object[,]
                {
                    { 1, null, "Letter Game", null, "https://i.ibb.co/xGKJcvf/images-q-tbn-ANd9-Gc-Rw8-Qk-MHrqvcxrk-IOFOBVR3r13-MQk-VUc-ZGCe-Q-s.jpg" },
                    { 2, null, "Word Game", null, "https://i.ibb.co/stHdMZr/images-q-tbn-ANd9-Gc-Qp-Nt4uu-KVWsowdvn-Hq-Jk-G-FCIV8-SYZm-EENLjri0-M7v-Whid-MEq-OGLMg-IFSfe-Jg-GZe.jpg" },
                    { 3, null, "Math Game", null, "https://i.ibb.co/JvyfVxK/images-q-tbn-ANd9-Gc-SV6r-E2cz9-L57-CJd-DPAX2zi-S2a-x3-WRn-VKZCQ-s.jpg" },
                    { 4, null, "Foucs Game", null, "https://i.ibb.co/St8m7bP/pic7490663.jpg" },
                    { 5, null, "Packet Game", null, "https://i.ibb.co/BjkJBNs/images-q-tbn-ANd9-Gc-Tm9-XZwoit0-w-EJ-Br-Qu7-Cw-Vjqagyre-BYYebg-s.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "ContentId", "Description", "IdContent", "Image", "ImageOnline", "groupName" },
                values: new object[,]
                {
                    { 1, null, "A Group Of People Interested in History", 1, null, "https://i.ibb.co/3MXDTVP/9781108429474.jpg", "Thee Physicists" },
                    { 2, null, "A Group Of People Interested in Geography", 2, null, "https://i.ibb.co/QKHsd9h/images-q-tbn-ANd9-Gc-Rye0p7-Kqc-VF8-FU3-Ntc-CV8v-Nys4gl-Uo-BE-xk-Q-s.png", "The Earth" },
                    { 3, null, "A Group Of People Interested in Medicine", 3, null, "https://i.ibb.co/y6yGK7f/images-q-tbn-ANd9-Gc-SJcvnce-GVp-Qzmf-UGZLCZGWOi54r-Tkza-Ah6n-A-s.jpg", "Medicine Informations" },
                    { 4, null, "A Group Of People Interested in Technology", 4, null, "https://i.ibb.co/Tmj3GRR/images-q-tbn-ANd9-Gc-Tw6winz-Nu9y-P-ZOtk-LLiri-Gn-Lw-Um9-CP0o8-YA-s.png", "Technology" },
                    { 5, null, "A Group Of People Interested in Literature", 5, null, "https://i.ibb.co/g3LFQTZ/images-q-tbn-ANd9-Gc-Tr-Ls-F370q-Sz-Yx-I09-UVe-KYzuz-O8-Rn-Ghx-6-HYQ-s.png", "The Science " }
                });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "libraryAddress", "libraryName" },
                values: new object[,]
                {
                    { 1, "AlSabel Street", "Sham" },
                    { 2, "Aljamelia", "Dar AlTurath" },
                    { 3, "AlMokambo", "Dar AlRabiea" },
                    { 4, "AlShahbaa", "Shahmaa" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "ContentId", "Description", "GroupId", "IdContent", "IdGroup", "IdUser", "Image", "ImageOnline", "UserId", "dateTime" },
                values: new object[,]
                {
                    { 1, null, "Physics is a science that studies the general properties of matter and the laws that seek to modify its state or motion without changing its nature.", null, 1, 0, 2, null, "https://i.ibb.co/Jdw0mns/images-q-tbn-ANd9-Gc-S2kgzs-C9-Xz-Rm-Id-S9-L16-RTZtewm-XAx-OAJUeg-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9531) },
                    { 2, null, "Astrophysics is a branch of astronomy that studies the properties and physical phenomena of celestial bodies. It depends primarily on the spectrometer that analyzes starlight and shows the materials that make up it and the physical conditions prevailing on its surface and in its atmosphere.", null, 1, 0, 3, null, "https://i.ibb.co/ZSCB5Hb/images-q-tbn-ANd9-Gc-QUJte8veo0-ULHb-C-q81sdf8c53-UOSEgu30gg-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9556) },
                    { 3, null, "Radiation is the process by which energy such as subatomic particles is emitted and transmitted. This process is characterized by the transmission of energy in straight lines in a source through a known medium such as air, water or vacuum.", null, 1, 0, 4, null, "https://i.ibb.co/Pgyg0ZC/radiation2.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9564) },
                    { 4, null, "Heat is a physical measure of the feeling of hotness or coldness resulting from contact with an object", null, 1, 0, 5, null, "https://i.ibb.co/k0f640h/698ca25d-3356-4149-a215-453aab0309b2-Getty-Images-139944098.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9571) },
                    { 5, null, "Gravity is the mutual attraction between two bodies and its strength depends on the masses of the two bodies and the distance between them", null, 1, 1, 2, null, "https://i.ibb.co/8BqRr8m/images-q-tbn-ANd9-Gc-Sscuymg7-GI-Q-XSUUVOGf-WFvrsps-K-v4-Nag-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9579) },
                    { 6, null, "X-rays are similar to light rays, but they are more frequent. The most recent of them are objects under the influence of cathode rays. They were discovered by the scientist Roentgen and are sometimes called by his name. They are electromagnetic waves.", null, 1, 1, 3, null, "https://i.ibb.co/mhmFXnr/images-q-tbn-ANd9-Gc-Rhuwykc2qsn4l-KV517u-Eb-BTv-Gj8h-Pjt-Cd1-Iw-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9588) },
                    { 7, null, "Frequency is the number of waves or cycles that leave a known point or reach it per second. This word or convention is most often used in alternating electric current, light and sound waves.", null, 1, 1, 4, null, "https://i.ibb.co/Wc9fFDx/images-q-tbn-ANd9-Gc-Q9-BSu-I-9z7o72fy6c5y-K0t-UOH9po-YWz-FJRYA-s.png", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9595) },
                    { 8, null, "Gamma rays are special electromagnetic rays emitted by radium and some other radioactive materials", null, 1, 1, 5, null, "https://i.ibb.co/ZHR61BH/images-q-tbn-ANd9-Gc-R-g-CN7-XUYUe3-HVvynr-LTPf-ATy7-IHS-h-WTp8-A-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9602) },
                    { 10, null, "The hurricane is a region of low atmospheric pressure in which the winds move in a spiral movement towards the center, and the spiral movement is counterclockwise in the northern hemisphere and agrees with it in the southern hemisphere", null, 2, 0, 2, null, "https://i.ibb.co/g3N6SRs/images-q-tbn-ANd9-Gc-Rye0x-Bk-JWn8gj-L87-Ic-g-Qijx-H3p39-Jt5m-Tww-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9609) },
                    { 11, null, "What is the definition of land shake?It is a tremor in the earth's crust caused either by volcanic activity underground or by the movement of rocks below the surface", null, 2, 0, 3, null, "https://i.ibb.co/C9H8cs0/images-q-tbn-ANd9-Gc-Qx-Wq-SAQd-Vx5ms0i-Uz-Wn4ub-X6-J0-KUca-OOud-FA-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9618) },
                    { 12, null, "Soil in stratigraphy is the part of the Earth's surface that contains a mixture of rock particles, minerals and organic matter that helps plant growth", null, 2, 0, 4, null, "https://i.ibb.co/TLwP87r/images-q-tbn-ANd9-Gc-RORohfl-KFF8s-AWbp-SXCwb3-Ms-Ds-Pl-Ju-Zyb-THw-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9625) },
                    { 13, null, "The South Pole is the southernmost point on the Earth's surface, and it is one of two points that border the imaginary line that represents the axis of rotation of the earth around itself", null, 2, 0, 5, null, "https://i.ibb.co/fxpkbDm/images-q-tbn-ANd9-Gc-T4en1-Ri-Vtz-Yv6e-Jmuri7-O0-QW4-LRo9-Vgg-I0x-A-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9633) },
                    { 14, null, "The continent is a wide area of   land surrounded by seas and continents are Asia, Africa, America, Oceania, and occupies less than a third of the surface of the globe", null, 2, 2, 2, null, "https://i.ibb.co/BL5BXgK/images-q-tbn-ANd9-Gc-SPjgo-Jxn1y-R7-MDYLFWl-z4-IC2-Nl-Ue-Ynv-Ngw-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9639) },
                    { 15, null, "cumulus :  It is a group of pieces of rock that descended to a steep slope", null, 2, 2, 3, null, "https://i.ibb.co/m4bvDmn/images-q-tbn-ANd9-Gc-QIe-Gx5-RXZ9-IOLA3-Vd-Qdj-Jja-QN5-PPMHIu-ITQ-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9646) },
                    { 16, null, "marble : A metamorphic rock consisting of calcite, which is a variable limestone that can be polished beautifully", null, 2, 2, 4, null, "https://i.ibb.co/Drxh9D0/images-q-tbn-ANd9-Gc-Qqr-Tv-W9-VXykz-Ty-Cn-fb5-PKb-Aahf5-LZ50-Lb-FA-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9654) },
                    { 17, null, "The North Pole is the point located in the far north of the Earth's surface, and it is one of the two points through which the imaginary line passes, which is the axis of the Earth's rotation around itself.", null, 2, 2, 5, null, "https://i.ibb.co/CK7mrWp/images-q-tbn-ANd9-Gc-RBH7j95w-TEy-To2-Yk-Ax-l5-OUBKBl-OV6pm8-Q-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9703) },
                    { 18, null, "Kidney is not  the only excretory organ ,but it is the most imporatnt", null, 3, 0, 2, null, "https://i.ibb.co/QmL8M58/images-q-tbn-ANd9-Gc-TARvz-P4c87n-Sc3-NAEi-S7h-N9-NPyd-WKib8i-T4-A-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9711) },
                    { 19, null, "The Femur is the longest bone in the human body", null, 3, 0, 3, null, "https://i.ibb.co/gwfdm3v/images-q-tbn-ANd9-Gc-Tf-Sd-Tn-GYo-Usp-BMo9-O2-Gc-VKj-CMO0-Uh1nmk-N1w-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9720) },
                    { 20, null, "There are 4 loose ribs in the human body", null, 3, 0, 4, null, "https://i.ibb.co/vVp4VzG/images-q-tbn-ANd9-Gc-Rkmc-W2v-ML6h-1-Yg8-RE2-Hg-Zu-E8-Kw6k-Tc-Z137w-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9727) },
                    { 21, null, "When inhaling, the diaphragm muscle contracts", null, 3, 0, 5, null, "https://i.ibb.co/YWjxCXv/images-q-tbn-ANd9-Gc-Tu5t7j-Sn-kr-C8-Efd-IXFy-Yr4n-urcl-Hf-Wdp4-Q-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9735) },
                    { 22, null, "Most food is absorbed in the intestines", null, 3, 3, 2, null, "https://i.ibb.co/2gkLWn8/images-q-tbn-ANd9-Gc-QC2ab6-XMXlj-8-Vh3g-VH3r-ZRAwjcjlqo-EPw-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9742) },
                    { 23, null, "The tricuspid valve is located between the right atrium and the right ventricle", null, 3, 3, 3, null, "https://i.ibb.co/0CnFs85/images-q-tbn-ANd9-Gc-Rkcx-1-KTBm3-p-SAtz-Cb8-Dbci4-QVc-MJ8-Ged-PQ-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9749) },
                    { 24, null, "There are 7 cervical vertebrae, 12 thoracic vertebrae, 5 lumbar vertebrae, 5 sacral vertebrae, and 4 coccygeal vertebrae.", null, 3, 3, 4, null, "https://i.ibb.co/W2bgDHp/images-q-tbn-ANd9-Gc-Qf-YZFRrsfia-Ja-Ly-MP2eb-BLy-DJMdtbu-E44ka-A-s.png", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9756) },
                    { 25, null, "The eye lives within a cavity called the pilgrims", null, 3, 3, 5, null, "https://i.ibb.co/kcBGpyJ/images-q-tbn-ANd9-Gc-TH7-LLr3-Yv5-GJfe-B5n-ARhsr-B3-Azoqnf-QLb-V6-Q-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9763) },
                    { 26, null, "The most used application is Facebook, with 1.3 billion users, while the second most used application is WeChat, with 1.26 billion users.", null, 4, 0, 2, null, "https://i.ibb.co/pKbKCFB/images-q-tbn-ANd9-Gc-QR4q8-OUDk-OYe-GIs0-Oa44-Uth-A-ZFLtq5eqy-YQ-s.png", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9770) },
                    { 27, null, "PAN, LAN, MAN, GAN, WAN and VPN are a kind of networking technology", null, 4, 0, 3, null, "https://i.ibb.co/T4K2bbx/images-q-tbn-ANd9-Gc-Rqu-J0-JYPrc10-Laeh-JFzgl-Vdotdn3-Bx-IT07-Zg-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9778) },
                    { 28, null, "SD-WAN is one of the fastest emerging segments in network technologies over the past two years", null, 4, 0, 4, null, "https://i.ibb.co/NKXCNCr/images-q-tbn-ANd9-Gc-R3-Rzq-Exfg-P81904m-Nutu6l-XF-QVVNvpdrrcw-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9785) },
                    { 29, null, "Artificial intelligence  - Artificial Intelligence - is a simulation and tradition of human intelligence in the machines programmed to think such as humans and images their actions such as electronic devices and robots, this term can also indicate any machine that displays attributes related to the human mind such as learning and solving problems", null, 4, 0, 5, null, "https://i.ibb.co/c871rk0/images-q-tbn-ANd9-Gc-R9c-Yn8-Y9k0-RBx-H0l-Pu3-Ys7-C5f-288cwvads-A-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9792) },
                    { 30, null, "A GPU is a processor similar to the one on a computer's motherboard.  The job that the graphics card processor performs is to keep the graphics card connected to the computer system.  It is considered the most important component of the graphics card that processes graphics, and the graphics card processor is not separable, that is, it cannot be updated to a higher category.", null, 4, 4, 2, null, "https://i.ibb.co/txX97yK/images-q-tbn-ANd9-Gc-RU48-LUUzj-j-Eg-FU3x-Aq-Ze7rr-Tlc3jbp-Es-Qcg-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9799) },
                    { 31, null, "CPU is a machine or an electrical circuit that operates other machines or electronic circuits by giving them orders to perform operations or algorithms;  Most of these operations are data processing.", null, 4, 4, 3, null, "https://i.ibb.co/JFNGGw4/images-q-tbn-ANd9-Gc-Sh4-J-1o0u-OQDY22-BOX1-DTSi76os-KCsn-Euy-Cg-s.png", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9806) },
                    { 32, null, "Deepfake or deep falsification is a technique used to fake video clips in a way that makes it difficult for humans to distinguish between what is real and what is fake", null, 4, 4, 4, null, "https://i.ibb.co/qFxBC4j/images-q-tbn-ANd9-Gc-Sgw-Jj-CVXTu-Cx-Re-Qm-KZju-Yzvk-LY0-N0-Fx-T4w-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9813) },
                    { 33, null, "Bots download, Spam bots, Ticket Bots, Distributed Denial of Service (DDoS) bots, Fraudulent bots, File sharing bots and Social media bots are kind of Malicious bots", null, 4, 4, 5, null, "https://i.ibb.co/LZKv73q/images-q-tbn-ANd9-Gc-S9-O4-MIX7xl-GVVk6v01c2-Yf1-VFxib-Ys-Ls-Yf-Q-s.jpg", null, new DateTime(2025, 1, 14, 20, 5, 13, 866, DateTimeKind.Local).AddTicks(9820) }
                });

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "Id", "ContentId", "IdContent", "Link", "referenceName" },
                values: new object[,]
                {
                    { 1, null, 3, "https://accessmedicine.mhmedical.com/book.aspx?bookid=3095#259856986", "dont now" },
                    { 2, null, 3, "https://accessmedicine.mhmedical.com/book.aspx?bookid=3212#269128176", "dont now" },
                    { 3, null, 3, "https://accessmedicine.mhmedical.com/book.aspx?bookid=1477", "dont now" },
                    { 4, null, 3, "https://accessmedicine.mhmedical.com/book.aspx?bookid=2969", "dont now" },
                    { 5, null, 1, "https://openstax.org/books/college-physics-2e/pages/1-introduction-to-science-and-the-realm-of-physics-physical-quantities-and-units", "dont now" },
                    { 6, null, 1, "https://openstax.org/books/college-physics-2e/pages/1-1-physics-an-introduction", "dont now" },
                    { 7, null, 1, "https://openstax.org/books/college-physics-2e/pages/1-2-physical-quantities-and-units", "dont now" },
                    { 8, null, 1, "https://openstax.org/books/college-physics-2e/pages/1-4-approximation", "dont now" },
                    { 9, null, 2, "https://www.amazon.com/Alfred-Wegener-Creator-Continental-Science/dp/0816061742", "Alfred Wegener: Creator of the Continental Drift Theory (Makers of Modern Science)" },
                    { 10, null, 2, "https://www.amazon.com/Earth-Very-Short-Introduction/dp/0192803077/ref=sr_1_9?dchild=1&keywords=earth+very+short&qid=1628980604&s=books&sr=1-9", "The Earth: A Very Short Introduction" },
                    { 11, null, 2, "https://www.amazon.com/Essentials-Geology-12th-Frederick-Lutgens/dp/0321947738/ref=sr_1_2?dchild=1&keywords=essential+geology+fredrick&qid=1628980672&s=books&sr=1-2-spell", "Essentials of Geology (12th Edition)" },
                    { 12, null, 2, "https://www.amazon.com/Plate-Tectonics-Short-Introduction-Introductions/dp/0198728263/ref=sr_1_3?dchild=1&keywords=earth+science+vsi&qid=1628980553&s=books&sr=1-3", "Plate Tectonics: A Very Short Introduction (Very Short Introductions): Molnar, Peter" },
                    { 13, null, 4, "https://www.free-ebooks.net/internet-technology/R-Programming-in-Statistics", "R Programming in Statistics by Balasubramanian Thiagarajan" },
                    { 14, null, 4, "https://www.free-ebooks.net/internet-technology/DISCOVER-YOUR-SPECIALTY", "DISCOVER YOUR SPECIALTY by DISCOVER YOUR SPECIALTY" },
                    { 15, null, 4, "https://www.free-ebooks.net/internet-technology/10-Ways-to-Create-The-Perfect-Online-Video", "Become A Pro Designer Overnight. by Clickdesigns" },
                    { 16, null, 4, "https://www.amazon.com/Plate-Tectonics-Short-Introduction-Introductions/dp/0198728263/ref=sr_1_3?dchild=1&keywords=earth+science+vsi&qid=1628980553&s=books&sr=1-3", "10 Ways to Create The Perfect Online Video by Mathew" },
                    { 17, null, 4, "https://www.free-ebooks.net/internet-technology/Deep-Analytics-Technologies-for-Humanity-AI-Security", "Deep Analytics: Technologies for Humanity, AI & Security" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "ContentId", "IdContent", "test" },
                values: new object[,]
                {
                    { 1, null, 1, "hell" },
                    { 2, null, 1, "hi" },
                    { 3, null, 2, "hello" },
                    { 4, null, 2, "hi" }
                });

            migrationBuilder.InsertData(
                table: "UserAccessibilities",
                columns: new[] { "Id", "AccessibilityId", "GroupId", "IdAccessibility", "IdGroup", "IdLibrary", "IdReference", "IdTest", "IdUser", "LibraryId", "ReferenceId", "TestId", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, 1, 1, 1, 1, null, 2, null, null, null, null },
                    { 2, null, null, 1, 2, 2, 1, null, 3, null, null, null, null },
                    { 3, null, null, 1, 3, 3, 2, null, 4, null, null, null, null },
                    { 4, null, null, 1, 5, 5, 3, null, 5, null, null, null, null },
                    { 5, null, null, 2, 2, 2, 1, null, 2, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "GroupId", "IdGroup", "IdUser", "UserId" },
                values: new object[,]
                {
                    { 1, null, 1, 2, null },
                    { 2, null, 2, 2, null },
                    { 3, null, 3, 2, null },
                    { 4, null, 4, 2, null },
                    { 5, null, 5, 2, null },
                    { 6, null, 1, 3, null },
                    { 7, null, 2, 3, null },
                    { 8, null, 3, 3, null },
                    { 9, null, 4, 3, null },
                    { 10, null, 5, 3, null },
                    { 11, null, 1, 4, null },
                    { 12, null, 2, 4, null },
                    { 13, null, 3, 4, null },
                    { 14, null, 4, 4, null },
                    { 15, null, 5, 4, null },
                    { 16, null, 1, 5, null },
                    { 17, null, 2, 5, null },
                    { 18, null, 3, 5, null },
                    { 19, null, 4, 5, null },
                    { 20, null, 5, 5, null }
                });

            migrationBuilder.InsertData(
                table: "UserPosts",
                columns: new[] { "Id", "IdPost", "IdUser", "Interaction", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 2, true, null, null },
                    { 2, 2, 2, true, null, null },
                    { 3, 3, 2, true, null, null },
                    { 4, 4, 2, true, null, null },
                    { 5, 5, 2, true, null, null },
                    { 6, 6, 2, true, null, null },
                    { 7, 7, 2, true, null, null },
                    { 8, 8, 2, true, null, null },
                    { 9, 9, 2, true, null, null },
                    { 10, 10, 2, true, null, null },
                    { 11, 11, 2, true, null, null },
                    { 12, 12, 2, true, null, null },
                    { 13, 13, 2, true, null, null },
                    { 14, 14, 2, true, null, null },
                    { 15, 15, 2, true, null, null },
                    { 16, 16, 2, true, null, null },
                    { 17, 17, 2, true, null, null },
                    { 18, 18, 2, true, null, null },
                    { 19, 19, 2, true, null, null },
                    { 20, 20, 2, true, null, null },
                    { 21, 21, 2, true, null, null },
                    { 22, 22, 2, true, null, null },
                    { 23, 23, 2, true, null, null },
                    { 24, 24, 2, true, null, null },
                    { 25, 25, 2, true, null, null },
                    { 26, 26, 2, true, null, null },
                    { 27, 27, 2, true, null, null },
                    { 28, 28, 2, true, null, null },
                    { 29, 29, 2, true, null, null },
                    { 30, 30, 2, true, null, null },
                    { 31, 31, 2, true, null, null },
                    { 32, 32, 2, true, null, null },
                    { 33, 33, 2, true, null, null },
                    { 34, 1, 3, true, null, null },
                    { 35, 2, 3, true, null, null },
                    { 36, 3, 3, true, null, null },
                    { 37, 4, 3, true, null, null },
                    { 38, 5, 3, true, null, null },
                    { 39, 6, 3, true, null, null },
                    { 40, 7, 3, true, null, null },
                    { 41, 8, 3, true, null, null },
                    { 42, 9, 3, true, null, null },
                    { 43, 10, 3, true, null, null },
                    { 44, 11, 3, true, null, null },
                    { 45, 12, 3, true, null, null },
                    { 46, 13, 3, true, null, null },
                    { 47, 14, 3, true, null, null },
                    { 48, 15, 3, true, null, null },
                    { 49, 16, 3, true, null, null },
                    { 50, 17, 3, true, null, null },
                    { 51, 18, 3, true, null, null },
                    { 52, 19, 3, true, null, null },
                    { 53, 20, 3, true, null, null },
                    { 54, 21, 3, true, null, null },
                    { 55, 22, 3, true, null, null },
                    { 56, 23, 3, true, null, null },
                    { 57, 24, 3, true, null, null },
                    { 58, 25, 3, true, null, null },
                    { 59, 26, 3, true, null, null },
                    { 60, 27, 3, true, null, null },
                    { 61, 28, 3, true, null, null },
                    { 62, 29, 3, true, null, null },
                    { 63, 30, 3, true, null, null },
                    { 64, 31, 3, true, null, null },
                    { 65, 32, 3, true, null, null },
                    { 66, 33, 3, true, null, null },
                    { 67, 1, 4, true, null, null },
                    { 68, 2, 4, true, null, null },
                    { 69, 3, 4, true, null, null },
                    { 70, 4, 4, true, null, null },
                    { 71, 5, 4, true, null, null },
                    { 72, 6, 4, true, null, null },
                    { 73, 7, 4, true, null, null },
                    { 74, 8, 4, true, null, null },
                    { 75, 9, 4, true, null, null },
                    { 76, 10, 4, true, null, null },
                    { 77, 11, 4, true, null, null },
                    { 78, 12, 4, true, null, null },
                    { 79, 13, 4, true, null, null },
                    { 80, 14, 4, true, null, null },
                    { 81, 15, 4, true, null, null },
                    { 82, 16, 4, true, null, null },
                    { 83, 17, 4, true, null, null },
                    { 84, 18, 4, true, null, null },
                    { 85, 19, 4, true, null, null },
                    { 86, 20, 4, true, null, null },
                    { 87, 21, 4, true, null, null },
                    { 88, 22, 4, true, null, null },
                    { 89, 23, 4, true, null, null },
                    { 90, 24, 4, true, null, null },
                    { 91, 25, 4, true, null, null },
                    { 92, 26, 4, true, null, null },
                    { 93, 27, 4, true, null, null },
                    { 94, 28, 4, true, null, null },
                    { 95, 29, 4, true, null, null },
                    { 96, 30, 4, true, null, null },
                    { 97, 31, 4, true, null, null },
                    { 98, 32, 4, true, null, null },
                    { 99, 33, 4, true, null, null },
                    { 100, 1, 5, true, null, null },
                    { 101, 2, 5, true, null, null },
                    { 102, 3, 5, true, null, null },
                    { 103, 4, 5, true, null, null },
                    { 104, 5, 5, true, null, null },
                    { 105, 6, 5, true, null, null },
                    { 106, 7, 5, true, null, null },
                    { 107, 8, 5, true, null, null },
                    { 108, 9, 5, true, null, null },
                    { 109, 10, 5, true, null, null },
                    { 110, 11, 5, true, null, null },
                    { 111, 12, 5, true, null, null },
                    { 112, 13, 5, true, null, null },
                    { 113, 14, 5, true, null, null },
                    { 114, 15, 5, true, null, null },
                    { 115, 16, 5, true, null, null },
                    { 116, 17, 5, true, null, null },
                    { 117, 18, 5, true, null, null },
                    { 118, 19, 5, true, null, null },
                    { 119, 20, 5, true, null, null },
                    { 120, 21, 5, true, null, null },
                    { 121, 22, 5, true, null, null },
                    { 122, 23, 5, true, null, null },
                    { 123, 24, 5, true, null, null },
                    { 124, 25, 5, true, null, null },
                    { 125, 26, 5, true, null, null },
                    { 126, 27, 5, true, null, null },
                    { 127, 28, 5, true, null, null },
                    { 128, 29, 5, true, null, null },
                    { 129, 30, 5, true, null, null },
                    { 130, 31, 5, true, null, null },
                    { 131, 32, 5, true, null, null },
                    { 132, 33, 5, true, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserReferences",
                columns: new[] { "Id", "IdReference", "IdUser", "ReferenceId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 2, null, null },
                    { 2, 2, 3, null, null },
                    { 3, 3, 4, null, null },
                    { 4, 4, 5, null, null },
                    { 5, 5, 2, null, null },
                    { 6, 6, 3, null, null },
                    { 7, 7, 4, null, null },
                    { 8, 8, 5, null, null },
                    { 9, 9, 2, null, null },
                    { 10, 10, 3, null, null },
                    { 11, 11, 4, null, null },
                    { 12, 12, 5, null, null },
                    { 13, 13, 2, null, null },
                    { 14, 14, 3, null, null },
                    { 15, 15, 4, null, null },
                    { 16, 16, 5, null, null },
                    { 17, 17, 5, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Age", "Description", "Email", "Image", "Name", "Password", "Paypal", "Phone", "Study", "UserName" },
                values: new object[,]
                {
                    { 1, "Null", "100", "Null", "Admin@gmail.com", null, "Admin", "Admin", "Null", "Null", "Null", "Admin" },
                    { 2, "ALfurkan next to SeriaTell", "22", "Love Life", "AsiaBadenjki@gmail.com", null, "Asia Badenjki", "0000", "123451", "0911223344", "Information Technology", "Asia21" },
                    { 3, "Halab Aljadeda", "23", "Enjoy ALL Day", "HayaYousfi@gmail.com", null, "Haya Yousfi", "1111", "123452", "0922113344", "Information Technology", "Haya22" },
                    { 4, "ALfourkan", "18", "Be Happy", "Hamzi18@gmail.com", null, "Hamze Badenjki", "2222", "123453", "0922553344", "HighSchool", "Hamze18" },
                    { 5, "ALShahba Aljadeda", "35", "null", "JawadMohammad@gmail.com", null, "Jawad Mohammad", "3333", "123454", "0922553377", "Null", "Jawad35" }
                });

            migrationBuilder.InsertData(
                table: "Writers",
                columns: new[] { "Id", "IsDeleted", "writerName" },
                values: new object[,]
                {
                    { 1, false, "Charlotte Blaine" },
                    { 2, false, "Mel Robbins" },
                    { 3, false, "Elizabeth Gilbert" },
                    { 4, false, "Nedra Glover Tawab" },
                    { 5, false, "Allison Fallon" },
                    { 6, false, "Bruce Feiler" },
                    { 7, false, "Catherine Ormerod" },
                    { 8, false, "Amish Jha" },
                    { 9, false, "Grace Beverly" },
                    { 10, false, "Robin Sharma" },
                    { 11, false, "Fiona Cummins" },
                    { 12, false, "Ann Cleeves" },
                    { 13, false, "L T Shearer" },
                    { 14, false, "Hayley Scrivenor" },
                    { 15, false, "Agatha Christie" },
                    { 16, false, "Daniel Kahneman" },
                    { 17, false, "Robert Cialdini" },
                    { 18, false, "Jonathan Haidt" },
                    { 19, false, "Dan Ariely" },
                    { 20, false, "Daniel Goleman" },
                    { 21, false, "Jonah Berger" },
                    { 22, false, "Seth Godin" },
                    { 23, false, "Donald Miller" },
                    { 24, false, "W. Chan Kim" },
                    { 25, false, "John Hall" },
                    { 26, false, "Barbara W. Tuchman" },
                    { 27, false, "Jared Diamond" },
                    { 28, false, "David McCullough" },
                    { 29, false, "Erik Larson" },
                    { 30, false, "Edward Said" },
                    { 31, false, "Nick Hornby" },
                    { 32, false, "Andre Agassi" },
                    { 33, false, "Joe McGinniss" },
                    { 34, false, "Michael Lewis" },
                    { 35, false, "Bill Barich" }
                });

            migrationBuilder.InsertData(
                table: "Follows",
                columns: new[] { "Id", "followId", "followedId" },
                values: new object[,]
                {
                    { 1, 2, 3 },
                    { 2, 2, 4 },
                    { 3, 2, 5 },
                    { 4, 3, 2 },
                    { 5, 3, 4 },
                    { 6, 3, 5 },
                    { 7, 4, 2 },
                    { 8, 4, 3 },
                    { 9, 4, 5 },
                    { 10, 5, 2 },
                    { 11, 5, 3 },
                    { 12, 5, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TestId",
                table: "Answers",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLibraries_BookId",
                table: "BookLibraries",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLibraries_LibraryId",
                table: "BookLibraries",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookTypeId",
                table: "Books",
                column: "BookTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookWriters_BookId",
                table: "BookWriters",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookWriters_WriterId",
                table: "BookWriters",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_Buybooks_BookLibraryId",
                table: "Buybooks",
                column: "BookLibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Buybooks_UserId",
                table: "Buybooks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_UserId",
                table: "Complaints",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_followedId",
                table: "Follows",
                column: "followedId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_followId",
                table: "Follows",
                column: "followId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUsers_GameId",
                table: "GameUsers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUsers_UserId",
                table: "GameUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ContentId",
                table: "Groups",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ContentId",
                table: "Posts",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GroupId",
                table: "Posts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_References_ContentId",
                table: "References",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_ContentId",
                table: "Tests",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessibilities_AccessibilityId",
                table: "UserAccessibilities",
                column: "AccessibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessibilities_GroupId",
                table: "UserAccessibilities",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessibilities_LibraryId",
                table: "UserAccessibilities",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessibilities_ReferenceId",
                table: "UserAccessibilities",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessibilities_TestId",
                table: "UserAccessibilities",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessibilities_UserId",
                table: "UserAccessibilities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupId",
                table: "UserGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_UserId",
                table: "UserGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPosts_PostId",
                table: "UserPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPosts_UserId",
                table: "UserPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReferences_ReferenceId",
                table: "UserReferences",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReferences_UserId",
                table: "UserReferences",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "BookWriters");

            migrationBuilder.DropTable(
                name: "Buybooks");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "GameUsers");

            migrationBuilder.DropTable(
                name: "UserAccessibilities");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "UserPosts");

            migrationBuilder.DropTable(
                name: "UserReferences");

            migrationBuilder.DropTable(
                name: "Writers");

            migrationBuilder.DropTable(
                name: "BookLibraries");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Accessibilities");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BookTypes");

            migrationBuilder.DropTable(
                name: "Contents");
        }
    }
}
