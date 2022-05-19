using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearOfProduction",
                table: "Movies",
                newName: "RealseDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RealseDate",
                table: "Movies",
                newName: "YearOfProduction");
        }
    }
}
