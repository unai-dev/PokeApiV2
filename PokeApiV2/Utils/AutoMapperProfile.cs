using AutoMapper;
using PokeApiV2.DTOs;
using PokeApiV2.Entities;

namespace PokeApiV2.Utils
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pokemon, PokemonDTO>();
            CreateMap<PokemonCreationDTO, Pokemon>();

            CreateMap<Generation, GenerationDTO>();
            CreateMap<AddGenerationDTO, Generation>();

            CreateMap<Trainer, TrainerDTO>();
            CreateMap<AddTrainerDTO, Trainer>();
        }

    }
}
