using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeApiV2.Data;
using PokeApiV2.DTOs;
using PokeApiV2.Entities;

namespace PokeApiV2.Controllers
{
    [ApiController]
    [Route("v2/api/trainer")]
    public class TrainerController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TrainerController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TrainerDTO>> Get()
        {
            var trainers = await context.Trainers.Include(t => t.Pokemons).ToListAsync();
            var trainersDTO = mapper.Map<IEnumerable<TrainerDTO>>(trainers);
            return trainersDTO;
        }

        [HttpGet("{id:int}", Name = "GetTrainer")]
        public async Task<ActionResult<TrainerDTO>> Get(int id)
        {
            var trainer = await context.Trainers.Include(t => t.Pokemons).FirstOrDefaultAsync(x => x.Id == id);
            if (trainer is null) return NotFound();

            var trainerDTO = mapper.Map<TrainerDTO>(trainer);
            return trainerDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(AddTrainerDTO trainerDTO)
        {
            var pokemonsIds = await context.Pokemons.Where(x =>
                trainerDTO.PokemonIds.Contains(x.Id)).ToListAsync();

       
            if (pokemonsIds.Count != trainerDTO.PokemonIds.Count)
            {
                return BadRequest("Pokemons Not Found");
            }

            var pokemonsWithTrainer = pokemonsIds.Where(p => p.TrainerId != null).ToList();

            if (pokemonsWithTrainer.Any())
            {
                var pokemonsWithTrainerInDb = string.Join(", ", pokemonsIds.Select(p => p.Id));
                return BadRequest($"This pokemons have trainer: {pokemonsWithTrainerInDb}");
            }
                
            var trainer = mapper.Map<Trainer>(trainerDTO);
            trainer.Pokemons = pokemonsIds;

            context.Add(trainer);
            await context.SaveChangesAsync();

            var trainerCreated = mapper.Map<TrainerDTO>(trainer);
            return CreatedAtRoute("GetTrainer", new { id = trainer.Id }, trainerCreated);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var trainer = await context.Trainers.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (trainer == 0) return NotFound();

            return NoContent();
        }

    }
}
