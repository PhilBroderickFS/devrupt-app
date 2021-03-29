using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DevRupt.Core.Contracts;
using DevRupt.Core.Models;
using DevRupt.Core.Models.Dtos;
using DevRupt.Core.Services;

namespace DevRupt.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {

        private IRepositoryWrapper _repoWrapper;
        private readonly IReservationService _reservationService;

        public ReservationController(IRepositoryWrapper repoWrapper, IReservationService reservationService)
        {
            _repoWrapper = repoWrapper;
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var reservation = await _repoWrapper.Reservation.GetAllReservationsAsync();

            return Ok(reservation);
        }

        [HttpGet("{numOfDays:int}")]
        public IAsyncEnumerable<GuestBookingsDto> GetBookingsForNextDays(int numOfDays)
        {
            return _reservationService.GetBookingsForNextDays(numOfDays);
        }
        
        [HttpGet("date")]
        public Task<GuestBookingsDto> GetBookingsForDate([FromQuery] string dateStr)
        {
            var date = DateTime.ParseExact(dateStr, "dd-MM-yyyy", null);
            return _reservationService.GetBookingsForDate(date);
        }
    

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetReservation(string id)
        // {
        //     var reservation = await _repoWrapper.Reservation.GetReservationByIdAsync(id);
        //
        //     return Ok(reservation);
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(string id)
        {
            var reservation = await _repoWrapper.Reservation.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            await _repoWrapper.Reservation.DeleteReservationAsync(reservation);
            _repoWrapper.Save();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                return BadRequest("Folio object is null");
            }

            await _repoWrapper.Reservation.CreateReservationAsync(reservation);
            _repoWrapper.Save();

            return CreatedAtRoute("GetReservation", new { id = reservation.Id }, reservation);
        }
    }
}
