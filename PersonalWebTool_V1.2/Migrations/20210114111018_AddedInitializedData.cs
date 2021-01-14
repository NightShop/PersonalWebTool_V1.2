using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebTool_V1.Migrations
{
    public partial class AddedInitializedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrlManual",
                table: "BlogPosts",
                newName: "ImageUrl");

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
                values: new object[] { 1, new DateTime(2021, 1, 14, 12, 10, 17, 318, DateTimeKind.Local).AddTicks(4767) });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "BlogPostID", "Body", "DateCreated", "ImageName", "ImageUrl", "PostCategoryID", "Title" },
                values: new object[,]
                {
                    { 2, "iiiiiiiiiiiiiiiiiLorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(2021, 1, 14, 12, 10, 17, 318, DateTimeKind.Local).AddTicks(611), "vzhodne-alpe", null, 1, "Initialize Personal Web Tool" },
                    { 5, "iiiiiiiiiiiiiiiiiLorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(2021, 1, 14, 12, 10, 17, 318, DateTimeKind.Local).AddTicks(707), "vzhodne-alpe", null, 1, "AnotherTest" },
                    { 1, "This first blog post in my Personal Web Tool. This first blog post in my Personal Web Tool. This first blog post in my Personal Web Tool. This first blog post in my Personal Web Tool. ", new DateTime(2021, 1, 14, 12, 10, 17, 314, DateTimeKind.Local).AddTicks(9393), "open-sign", null, 4, "Initialize Personal Web Tool" }
                });

            migrationBuilder.InsertData(
                table: "GratefulnessUnits",
                columns: new[] { "GratefulnessUnitID", "Details", "GratefulnessEntryID", "Main" },
                values: new object[] { 1, "Test1", 1, "test1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PostCategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PostCategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GratefulnessUnits",
                keyColumn: "GratefulnessUnitID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PostCategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PostCategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GratefulnessEntries",
                keyColumn: "GratefulnessEntryID",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "BlogPosts",
                newName: "ImageUrlManual");
        }
    }
}
