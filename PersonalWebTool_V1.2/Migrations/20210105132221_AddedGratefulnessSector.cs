using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebTool_V1.Migrations
{
    public partial class AddedGratefulnessSector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 5, 14, 22, 20, 834, DateTimeKind.Local).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 1, 5, 14, 22, 20, 838, DateTimeKind.Local).AddTicks(1839));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 2, 15, 29, 22, 415, DateTimeKind.Local).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 1, 2, 15, 29, 22, 419, DateTimeKind.Local).AddTicks(1252));
        }
    }
}
