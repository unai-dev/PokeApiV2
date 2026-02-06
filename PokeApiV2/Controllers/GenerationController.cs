using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeApiV2.Data;
using PokeApiV2.DTOs;
using PokeApiV2.Entities;

namespace PokeApiV2.Controllers
{
    [ApiController]
    [Route("v2/api/generation")]
    public class GenerationController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerationController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GenerationDTO>> Get()
        {
            var generations = await context.Generations.ToListAsync();
            var generationsDTO = mapper.Map<IEnumerable<GenerationDTO>>(generations);
            return generationsDTO;
        }

        [HttpGet("{id:int}", Name = "GetGeneration")]
        public async Task<ActionResult<GenerationDTO>> Get(int id)
        {
            var generation = await context.Generations.FirstOrDefaultAsync(x => x.Id == id);

            if (generation is null)
            {
                return NotFound();
            }

            return mapper.Map<GenerationDTO>(generation);
        }

        [HttpPost]
        public async Task<ActionResult> Post(AddGenerationDTO generationDTO)
        {
            var generationExists = await context.Generations.AnyAsync(x => x.Number == generationDTO.Number);

            if (generationExists)
            {
                return BadRequest("Generation already exists in DB");
            }

            var generation = mapper.Map<Generation>(generationDTO);

            context.Add(generation);
            await context.SaveChangesAsync();
            var generationCreated = mapper.Map<GenerationDTO>(generation);

            return CreatedAtRoute("GetGeneration", new { id = generation.Id }, generationCreated);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var generation = await context.Generations.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (generation == 0) return NotFound();

            return NoContent();
        }
    }
}
