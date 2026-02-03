namespace PokeApiV2.DTOs
{
    public class PokemonDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<string> Skills { get; set; } = [];


    }
}
