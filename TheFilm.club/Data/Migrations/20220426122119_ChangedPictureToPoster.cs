using Microsoft.EntityFrameworkCore.Migrations;

namespace TheFilm.club.Data.Migrations
{
    public partial class ChangedPictureToPoster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Films",
                newName: "Poster");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Poster",
                table: "Films",
                newName: "Picture");
        }
    }
}
