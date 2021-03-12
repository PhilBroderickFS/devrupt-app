using System;
using System.Threading.Tasks;
using DevRupt.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace net_core_API.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public RestaurantController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetRestaurantBookings(string date)
        {
            if (DateTime.TryParse(date, out var dateTime))
            {
                return Ok(await _reservationService.GetReservationsForDate(dateTime));
            }

            return BadRequest("Invalid date parameter");
        }
    }
}