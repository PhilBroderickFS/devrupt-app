using AutoMapper;
using DevRupt.Core.Models;
using DevRupt.Core.Models.Dtos;

namespace DevRupt.App.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Set, RecommendedSetDto>();
            CreateMap<Dish, DishDto>();
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}
