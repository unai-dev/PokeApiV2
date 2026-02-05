using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeApiV2.Data;
using PokeApiV2.DTOs;
using PokeApiV2.Entities;

namespace PokeApiV2.Controllers
{
    [ApiController]
    [Route("v2/api/pokemon")]
    public class PokemonController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PokemonController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PokemonDTO>> Get()
        {
            var pokemons = await context.Pokemons.ToListAsync();
            var pokemonsDTO = mapper.Map<IEnumerable<PokemonDTO>>(pokemons);

            return pokemonsDTO;

        }

        [HttpGet("{id:int}", Name = "GetPokemon")]
        public async Task<ActionResult<PokemonDTO>> Get(int id)
        {
            var pokemon = await context.Pokemons.FirstOrDefaultAsync(x => x.Id == id);

            if (pokemon is null)
            {
                return NotFound();
            }

            var pokemonsDTO = mapper.Map<PokemonDTO>(pokemon);

            return pokemonsDTO;

        }

        [HttpPost]
        public async Task<ActionResult> Post(PokemonCreationDTO pokemonDTO)
        {
            var generation = await context.Generations.FirstOrDefaultAsync(x => x.Id == pokemonDTO.GenerationId);

            if (generation is null)
            {
                return NotFound($"Generation with id {pokemonDTO.GenerationId} not found");
            }

            var pokemon = mapper.Map<Pokemon>(pokemonDTO);

            context.Add(pokemon);
            await context.SaveChangesAsync();
            var pokemonCreated = mapper.Map<PokemonDTO>(pokemon);

            return CreatedAtRoute("GetPokemon", new { id = pokemon.Id }, pokemonCreated);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(PokemonCreationDTO pokemonDTO, int id)
        {

            var pokemon = mapper.Map<Pokemon>(pokemonDTO);
            pokemon.Id = id;

            context.Update(pokemon);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pokemonDB = await context.Pokemons.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (pokemonDB == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
