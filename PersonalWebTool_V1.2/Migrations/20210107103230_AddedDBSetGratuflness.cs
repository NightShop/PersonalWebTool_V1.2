using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebTool_V1.Migrations
{
    public partial class AddedDBSetGratuflness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GratefulnessUnit_GratefulnessEntry_GratefulnessEntryID",
                table: "GratefulnessUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GratefulnessUnit",
                table: "GratefulnessUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GratefulnessEntry",
                table: "GratefulnessEntry");

            migrationBuilder.RenameTable(
                name: "GratefulnessUnit",
                newName: "GratefulnessUnits");

            migrationBuilder.RenameTable(
                name: "GratefulnessEntry",
                newName: "GratefulnessEntries");

            migrationBuilder.RenameIndex(
                name: "IX_GratefulnessUnit_GratefulnessEntryID",
                table: "GratefulnessUnits",
                newName: "IX_GratefulnessUnits_GratefulnessEntryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GratefulnessUnits",
                table: "GratefulnessUnits",
                column: "GratefulnessUnitID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GratefulnessEntries",
                table: "GratefulnessEntries",
                column: "GratefulnessEntryID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_GratefulnessUnits_GratefulnessEntries_GratefulnessEntryID",
                table: "GratefulnessUnits",
                column: "GratefulnessEntryID",
                principalTable: "GratefulnessEntries",
                principalColumn: "GratefulnessEntryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GratefulnessUnits_GratefulnessEntries_GratefulnessEntryID",
                table: "GratefulnessUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GratefulnessUnits",
                table: "GratefulnessUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GratefulnessEntries",
                table: "GratefulnessEntries");

            migrationBuilder.RenameTable(
                name: "GratefulnessUnits",
                newName: "GratefulnessUnit");

            migrationBuilder.RenameTable(
                name: "GratefulnessEntries",
                newName: "GratefulnessEntry");

            migrationBuilder.RenameIndex(
                name: "IX_GratefulnessUnits_GratefulnessEntryID",
                table: "GratefulnessUnit",
                newName: "IX_GratefulnessUnit_GratefulnessEntryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GratefulnessUnit",
                table: "GratefulnessUnit",
                column: "GratefulnessUnitID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GratefulnessEntry",
                table: "GratefulnessEntry",
                column: "GratefulnessEntryID");

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

            migrationBuilder.UpdateData(
                table: "GratefulnessEntry",
                keyColumn: "GratefulnessEntryID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 1, 7, 10, 45, 49, 497, DateTimeKind.Local).AddTicks(563));

            migrationBuilder.AddForeignKey(
                name: "FK_GratefulnessUnit_GratefulnessEntry_GratefulnessEntryID",
                table: "GratefulnessUnit",
                column: "GratefulnessEntryID",
                principalTable: "GratefulnessEntry",
                principalColumn: "GratefulnessEntryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
