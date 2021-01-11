using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebTool_V1.Migrations
{
    public partial class HabitPointNonNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Points",
                table: "Habits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 11, 14, 1, 53, 878, DateTimeKind.Local).AddTicks(3109));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 1, 11, 14, 1, 53, 885, DateTimeKind.Local).AddTicks(3526));

            migrationBuilder.UpdateData(
                table: "GratefulnessEntries",
                keyColumn: "GratefulnessEntryID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 11, 14, 1, 53, 886, DateTimeKind.Local).AddTicks(875));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Points",
                table: "Habits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 11, 13, 3, 16, 354, DateTimeKind.Local).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 1, 11, 13, 3, 16, 360, DateTimeKind.Local).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "GratefulnessEntries",
                keyColumn: "GratefulnessEntryID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 11, 13, 3, 16, 361, DateTimeKind.Local).AddTicks(218));
        }
    }
}
