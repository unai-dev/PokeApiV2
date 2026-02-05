using PokeApiV2.Entities;
using PokeApiV2.Validations;
using System.ComponentModel.DataAnnotations;

namespace PokeApiV2.DTOs
{
    public class PokemonCreationDTO
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [FirstUpperCaseValidation]
        [StringLength(30, ErrorMessage = "The field {0} must contain {1} chars or less")]
        public required string Name { get; set; }
        public List<string> Skills { get; set; } = [];
        public int? GenerationId { get; set; }

    }
}
