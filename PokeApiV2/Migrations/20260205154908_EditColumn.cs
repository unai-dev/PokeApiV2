using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeApiV2.Migrations
{
    /// <inheritdoc />
    public partial class EditColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PokemonIds",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PokemonIds",
                table: "Trainers");
        }
    }
}
