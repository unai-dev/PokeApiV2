using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeApiV2.Migrations
{
    /// <inheritdoc />
    public partial class AddGenerationCrud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenerationId",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Generations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_GenerationId",
                table: "Pokemons",
                column: "GenerationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Generations_GenerationId",
                table: "Pokemons",
                column: "GenerationId",
                principalTable: "Generations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Generations_GenerationId",
                table: "Pokemons");

            migrationBuilder.DropTable(
                name: "Generations");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_GenerationId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "GenerationId",
                table: "Pokemons");
        }
    }
}
