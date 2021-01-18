using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebTool_V1.Migrations
{
    public partial class InitialDB : Migration
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
                name: "GratefulnessEntries",
                columns: table => new
                {
                    GratefulnessEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GratefulnessEntries", x => x.GratefulnessEntryID);
                });

            migrationBuilder.CreateTable(
                name: "HabitDays",
                columns: table => new
                {
                    HabitDayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitDays", x => x.HabitDayID);
                });

            migrationBuilder.CreateTable(
                name: "Habits",
                columns: table => new
                {
                    HabitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.HabitID);
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
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "GratefulnessUnits",
                columns: table => new
                {
                    GratefulnessUnitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Main = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GratefulnessEntryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GratefulnessUnits", x => x.GratefulnessUnitID);
                    table.ForeignKey(
                        name: "FK_GratefulnessUnits_GratefulnessEntries_GratefulnessEntryID",
                        column: x => x.GratefulnessEntryID,
                        principalTable: "GratefulnessEntries",
                        principalColumn: "GratefulnessEntryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabitQuantities",
                columns: table => new
                {
                    HabitQuantityID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HabitDayID = table.Column<int>(type: "int", nullable: false),
                    HabitID = table.Column<int>(type: "int", nullable: true),
                    Counter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitQuantities", x => x.HabitQuantityID);
                    table.ForeignKey(
                        name: "FK_HabitQuantities_HabitDays_HabitDayID",
                        column: x => x.HabitDayID,
                        principalTable: "HabitDays",
                        principalColumn: "HabitDayID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabitQuantities_Habits_HabitID",
                        column: x => x.HabitID,
                        principalTable: "Habits",
                        principalColumn: "HabitID",
                        onDelete: ReferentialAction.Restrict);
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
                table: "GratefulnessEntries",
                columns: new[] { "GratefulnessEntryID", "DateCreated" },
                values: new object[] { 1, new DateTime(2021, 1, 15, 20, 0, 56, 363, DateTimeKind.Local).AddTicks(2807) });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "BlogPostID", "Body", "DateCreated", "ImageName", "ImageUrl", "PostCategoryID", "Title" },
                values: new object[,]
                {
                    { 2, "iiiiiiiiiiiiiiiiiLorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(2021, 1, 15, 20, 0, 56, 363, DateTimeKind.Local).AddTicks(209), "vzhodne-alpe", null, 1, "Initialize Personal Web Tool" },
                    { 5, "iiiiiiiiiiiiiiiiiLorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(2021, 1, 15, 20, 0, 56, 363, DateTimeKind.Local).AddTicks(286), "vzhodne-alpe", null, 1, "AnotherTest" },
                    { 1, "This first blog post in my Personal Web Tool. This first blog post in my Personal Web Tool. This first blog post in my Personal Web Tool. This first blog post in my Personal Web Tool. ", new DateTime(2021, 1, 15, 20, 0, 56, 360, DateTimeKind.Local).AddTicks(5492), "open-sign", null, 4, "Initialize Personal Web Tool" }
                });

            migrationBuilder.InsertData(
                table: "GratefulnessUnits",
                columns: new[] { "GratefulnessUnitID", "Details", "GratefulnessEntryID", "Main" },
                values: new object[] { 1, "Test1", 1, "test1" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_PostCategoryID",
                table: "BlogPosts",
                column: "PostCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_GratefulnessUnits_GratefulnessEntryID",
                table: "GratefulnessUnits",
                column: "GratefulnessEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_HabitQuantities_HabitDayID",
                table: "HabitQuantities",
                column: "HabitDayID");

            migrationBuilder.CreateIndex(
                name: "IX_HabitQuantities_HabitID",
                table: "HabitQuantities",
                column: "HabitID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "GratefulnessUnits");

            migrationBuilder.DropTable(
                name: "HabitQuantities");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "GratefulnessEntries");

            migrationBuilder.DropTable(
                name: "HabitDays");

            migrationBuilder.DropTable(
                name: "Habits");
        }
    }
}
