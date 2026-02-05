using PokeApiV2.Validations;
using System.ComponentModel.DataAnnotations;

namespace PokeApiV2.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [FirstUpperCaseValidation]
        [StringLength(30, ErrorMessage = "The field {0} must contain {1} chars or less")]
        public required string Name { get; set; }

        public List<string> Skills { get; set; } = [];

        public int GenerationId { get; set; }
        public Generation? Generation { get; set; }

        public int TrainerId { get; set; }
        public Trainer? Trainer { get; set; }

    }
}
