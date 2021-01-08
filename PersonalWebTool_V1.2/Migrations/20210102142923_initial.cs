using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebTool_V1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    PostCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.PostCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    BlogPostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.BlogPostID);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Categories_PostCategoryID",
                        column: x => x.PostCategoryID,
                        principalTable: "Categories",
                        principalColumn: "PostCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "PostCategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Adventure" },
                    { 2, "Optimization" },
                    { 3, "Programming" },
                    { 4, "Miscellaneous" }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "BlogPostID", "Body", "DateCreated", "ImageName", "PostCategoryID", "Title" },
                values: new object[] { 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(2021, 1, 2, 15, 29, 22, 419, DateTimeKind.Local).AddTicks(1252), "vzhodne-alpe", 1, "Initialize Personal Web Tool" });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "BlogPostID", "Body", "DateCreated", "ImageName", "PostCategoryID", "Title" },
                values: new object[] { 1, "This first blog post in my Personal Web Tool. This first blog post in my Personal Web Tool. This first blog post in my Personal Web Tool. This first blog post in my Personal Web Tool. ", new DateTime(2021, 1, 2, 15, 29, 22, 415, DateTimeKind.Local).AddTicks(5875), "open-sign", 4, "Initialize Personal Web Tool" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_PostCategoryID",
                table: "BlogPosts",
                column: "PostCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
