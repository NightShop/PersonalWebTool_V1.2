using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebTool_V1.Migrations
{
    public partial class CorrectedSlugBlogpPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Points = table.Column<int>(type: "int", nullable: true),
                    HabitDayID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.HabitID);
                    table.ForeignKey(
                        name: "FK_Habits_HabitDays_HabitDayID",
                        column: x => x.HabitDayID,
                        principalTable: "HabitDays",
                        principalColumn: "HabitDayID",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habits");

            migrationBuilder.DropTable(
                name: "HabitDays");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 7, 11, 32, 29, 665, DateTimeKind.Local).AddTicks(516));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 1, 7, 11, 32, 29, 670, DateTimeKind.Local).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "GratefulnessEntries",
                keyColumn: "GratefulnessEntryID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 7, 11, 32, 29, 670, DateTimeKind.Local).AddTicks(8208));
        }
    }
}
