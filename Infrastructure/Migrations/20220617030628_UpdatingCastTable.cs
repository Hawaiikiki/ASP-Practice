using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatingCastTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Casts",
                table: "Casts");

            migrationBuilder.RenameTable(
                name: "Casts",
                newName: "Cast");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cast",
                table: "Cast",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cast",
                table: "Cast");

            migrationBuilder.RenameTable(
                name: "Cast",
                newName: "Casts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Casts",
                table: "Casts",
                column: "Id");
        }
    }
}
