using AutoMapper;
using DevRupt.Core.Models;
using DevRupt.Core.Models.Dtos;
using DevRupt.Data.Dtos;

namespace DevRupt.App.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reservation, ReservationDto>();
            CreateMap<Folio, FolioDto>();
            CreateMap<RatePlan, RatePlanDto>();

            CreateMap<Set, RecommendedSetDto>();
            CreateMap<Dish, DishDto>();
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}
