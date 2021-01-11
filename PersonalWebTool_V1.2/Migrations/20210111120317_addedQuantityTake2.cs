using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebTool_V1.Migrations
{
    public partial class addedQuantityTake2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "HabitQuantities");

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
    }
}
