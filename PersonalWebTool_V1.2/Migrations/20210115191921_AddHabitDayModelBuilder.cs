using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebTool_V1.Migrations
{
    public partial class AddHabitDayModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 15, 20, 19, 20, 597, DateTimeKind.Local).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 1, 15, 20, 19, 20, 600, DateTimeKind.Local).AddTicks(5603));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 1, 15, 20, 19, 20, 600, DateTimeKind.Local).AddTicks(5685));

            migrationBuilder.UpdateData(
                table: "GratefulnessEntries",
                keyColumn: "GratefulnessEntryID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 15, 20, 19, 20, 600, DateTimeKind.Local).AddTicks(8276));

            migrationBuilder.InsertData(
                table: "HabitDays",
                columns: new[] { "HabitDayID", "DateCreated", "Points" },
                values: new object[] { 1, new DateTime(2021, 1, 15, 20, 19, 20, 600, DateTimeKind.Local).AddTicks(9409), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HabitDays",
                keyColumn: "HabitDayID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 15, 20, 0, 56, 360, DateTimeKind.Local).AddTicks(5492));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 1, 15, 20, 0, 56, 363, DateTimeKind.Local).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 1, 15, 20, 0, 56, 363, DateTimeKind.Local).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "GratefulnessEntries",
                keyColumn: "GratefulnessEntryID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 15, 20, 0, 56, 363, DateTimeKind.Local).AddTicks(2807));
        }
    }
}
