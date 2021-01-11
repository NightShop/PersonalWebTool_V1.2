using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebTool_V1.Migrations
{
    public partial class AddedQuantityOfHabits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_HabitDays_HabitDayID",
                table: "Habits");

            migrationBuilder.DropIndex(
                name: "IX_Habits_HabitDayID",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "HabitDayID",
                table: "Habits");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 11, 11, 27, 16, 846, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 1, 11, 11, 27, 16, 850, DateTimeKind.Local).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "GratefulnessEntries",
                keyColumn: "GratefulnessEntryID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 11, 11, 27, 16, 851, DateTimeKind.Local).AddTicks(3055));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HabitDayID",
                table: "Habits",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 8, 13, 26, 28, 519, DateTimeKind.Local).AddTicks(8750));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 1, 8, 13, 26, 28, 523, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "GratefulnessEntries",
                keyColumn: "GratefulnessEntryID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 8, 13, 26, 28, 523, DateTimeKind.Local).AddTicks(9556));

            migrationBuilder.CreateIndex(
                name: "IX_Habits_HabitDayID",
                table: "Habits",
                column: "HabitDayID");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_HabitDays_HabitDayID",
                table: "Habits",
                column: "HabitDayID",
                principalTable: "HabitDays",
                principalColumn: "HabitDayID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
