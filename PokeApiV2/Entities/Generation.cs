using PokeApiV2.Validations;
using System.ComponentModel.DataAnnotations;

namespace PokeApiV2.Entities
{
    public class Generation
    {

        public int Id { get; set; }

        [Required]
        [FirstUpperCaseValidation]
        public required string Name { get; set; }

        [Required]
        public required int Number { get; set; }

        public List<Pokemon> Pokemons { get; set; } = [];


    }
}
