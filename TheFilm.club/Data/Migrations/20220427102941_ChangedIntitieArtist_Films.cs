using Microsoft.EntityFrameworkCore.Migrations;

namespace TheFilm.club.Data.Migrations
{
    public partial class ChangedIntitieArtist_Films : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Films_Artists_ArtistId",
                table: "Artist_Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Films_Films_FilmId",
                table: "Artist_Films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist_Films",
                table: "Artist_Films");

            migrationBuilder.RenameTable(
                name: "Artist_Films",
                newName: "Artists_Films");

            migrationBuilder.RenameIndex(
                name: "IX_Artist_Films_FilmId",
                table: "Artists_Films",
                newName: "IX_Artists_Films_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists_Films",
                table: "Artists_Films",
                columns: new[] { "ArtistId", "FilmId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Films_Artists_ArtistId",
                table: "Artists_Films",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Films_Films_FilmId",
                table: "Artists_Films",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Films_Artists_ArtistId",
                table: "Artists_Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Films_Films_FilmId",
                table: "Artists_Films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists_Films",
                table: "Artists_Films");

            migrationBuilder.RenameTable(
                name: "Artists_Films",
                newName: "Artist_Films");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_Films_FilmId",
                table: "Artist_Films",
                newName: "IX_Artist_Films_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist_Films",
                table: "Artist_Films",
                columns: new[] { "ArtistId", "FilmId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Films_Artists_ArtistId",
                table: "Artist_Films",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Films_Films_FilmId",
                table: "Artist_Films",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
