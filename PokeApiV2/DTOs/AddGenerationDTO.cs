using PokeApiV2.Entities;
using PokeApiV2.Validations;
using System.ComponentModel.DataAnnotations;

namespace PokeApiV2.DTOs
{
    public class AddGenerationDTO
    {
        [Required]
        [FirstUpperCaseValidation]
        public required string Name { get; set; }

        [Required]
        public int Number { get; set; }

        public List<Pokemon> Pokemons { get; set; } = [];
    }
}
