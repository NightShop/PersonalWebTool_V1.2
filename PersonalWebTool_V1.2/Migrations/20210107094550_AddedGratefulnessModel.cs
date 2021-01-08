using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebTool_V1.Migrations
{
    public partial class AddedGratefulnessModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GratefulnessEntry",
                columns: table => new
                {
                    GratefulnessEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GratefulnessEntry", x => x.GratefulnessEntryID);
                });

            migrationBuilder.CreateTable(
                name: "GratefulnessUnit",
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
                    table.PrimaryKey("PK_GratefulnessUnit", x => x.GratefulnessUnitID);
                    table.ForeignKey(
                        name: "FK_GratefulnessUnit_GratefulnessEntry_GratefulnessEntryID",
                        column: x => x.GratefulnessEntryID,
                        principalTable: "GratefulnessEntry",
                        principalColumn: "GratefulnessEntryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 7, 10, 45, 49, 477, DateTimeKind.Local).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 1, 7, 10, 45, 49, 480, DateTimeKind.Local).AddTicks(8903));

            migrationBuilder.InsertData(
                table: "GratefulnessEntry",
                columns: new[] { "GratefulnessEntryID", "DateCreated" },
                values: new object[] { 1, new DateTime(2021, 1, 7, 10, 45, 49, 497, DateTimeKind.Local).AddTicks(563) });

            migrationBuilder.InsertData(
                table: "GratefulnessUnit",
                columns: new[] { "GratefulnessUnitID", "Details", "GratefulnessEntryID", "Main" },
                values: new object[] { 1, "Test1", 1, "test1" });

            migrationBuilder.CreateIndex(
                name: "IX_GratefulnessUnit_GratefulnessEntryID",
                table: "GratefulnessUnit",
                column: "GratefulnessEntryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GratefulnessUnit");

            migrationBuilder.DropTable(
                name: "GratefulnessEntry");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 5, 14, 26, 28, 265, DateTimeKind.Local).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "BlogPostID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 1, 5, 14, 26, 28, 271, DateTimeKind.Local).AddTicks(298));
        }
    }
}
