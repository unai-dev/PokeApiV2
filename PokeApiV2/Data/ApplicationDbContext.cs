using Microsoft.EntityFrameworkCore;
using PokeApiV2.Entities;

namespace PokeApiV2.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Generation> Generations { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

    }
}
