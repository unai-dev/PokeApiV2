using PokeApiV2.Entities;

namespace PokeApiV2.DTOs
{
    public class TrainerDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Team { get; set; }
        public List<Pokemon> Pokemons { get; set; } = [];


    }
}
