using AutoMapper;
using DevRupt.Core.Models;

namespace DevRupt.Data.Dtos
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Reservation, ReservationDto>();
        }

       
    }
}
