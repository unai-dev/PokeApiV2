using PokeApiV2.Validations;
using System.ComponentModel.DataAnnotations;

namespace PokeApiV2.Entities
{
    public class Trainer
    {
        public int Id { get; set; }
        [Required]
        [FirstUpperCaseValidation]
        public required string Name { get; set; }
        [Required]
        [FirstUpperCaseValidation]
        public required string Team { get; set; }
        public List<Pokemon> Pokemons { get; set; } = [];

    }
}
