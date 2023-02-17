using AutoMapper;
using PokemonReviewsApp.Dto;
using PokemonReviewsApp.Models;

namespace PokemonReviewsApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
        }
    }
}
