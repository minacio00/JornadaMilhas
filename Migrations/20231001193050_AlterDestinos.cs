using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaMilhas.Migrations
{
    /// <inheritdoc />
    public partial class AlterDestinos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Destinos",
                newName: "TextoDescritivo");

            migrationBuilder.AddColumn<string>(
                name: "Foto1",
                table: "Destinos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Foto2",
                table: "Destinos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Destinos",
                type: "character varying(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto1",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "Foto2",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Destinos");

            migrationBuilder.RenameColumn(
                name: "TextoDescritivo",
                table: "Destinos",
                newName: "Foto");
        }
    }
}
