using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevRupt.Core.Models;
using DevRupt.Core.Repositories;

namespace DevRupt.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        
        public async Task<IEnumerable<Reservation>> GetReservationsForDate(DateTime dateTime)
        {
            var startOfDay = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
            var endOfDay = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);

            return await _reservationRepository.GetReservationsBetweenDates(startOfDay, endOfDay);
        }
    }
}