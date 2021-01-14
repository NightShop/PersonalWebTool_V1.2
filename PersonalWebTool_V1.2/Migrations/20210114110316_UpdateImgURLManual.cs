using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebTool_V1.Migrations
{
    public partial class UpdateImgURLManual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "BlogPosts",
                newName: "ImageUrlManual");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrlManual",
                table: "BlogPosts",
                newName: "ImageUrl");
        }
    }
}
