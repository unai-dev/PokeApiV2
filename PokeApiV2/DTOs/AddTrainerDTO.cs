using PokeApiV2.Entities;
using PokeApiV2.Validations;
using System.ComponentModel.DataAnnotations;

namespace PokeApiV2.DTOs
{
    public class AddTrainerDTO
    {
        [Required]
        [FirstUpperCaseValidation]
        public required string Name { get; set; }
        public List<int> PokemonIds { get; set; } = [];

    }
}
