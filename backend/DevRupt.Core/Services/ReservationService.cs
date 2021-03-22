using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevRupt.Core.Contracts;
using DevRupt.Core.Models;

namespace DevRupt.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IFolioRepository _folioRepository;
        private readonly IRatePlanRepository _ratePlanRepository;

        public ReservationService(IReservationRepository reservationRepository, IFolioRepository folioRepository
            , IRatePlanRepository ratePlanRepository)
        {
            _reservationRepository = reservationRepository;
            _folioRepository = folioRepository;
            _ratePlanRepository = ratePlanRepository;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsForDate(DateTime dateTime)
        {
            var startOfDay = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
            var endOfDay = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);

            return await _reservationRepository.GetReservationsBetweenDates(startOfDay, endOfDay);
        }

        public async Task<DateTime> GetMostRecentReservationProcess()
        {
            // TODO talk to DB to get last run time
            return DateTime.Now.AddDays(-10);
        }

        public async Task AddReservations(IEnumerable<Reservation> reservations)
        {
            foreach (var reservation in reservations)
            {
                foreach (var folio in reservation.Folios)
                {
                    var existingFolio = await _folioRepository.GetExistingFolio(folio.Id);

                    if (existingFolio != null)
                    {
                        reservation.Folios = reservation.Folios.Where(f => !f.Id.Equals(existingFolio.Id)).ToList();
                    }
                }

                var existingRatePlan = await _ratePlanRepository.GetExistingRatePlan(reservation.RatePlan.Id);
                if (existingRatePlan != null)
                {
                    reservation.RatePlan = existingRatePlan;
                }
                await _reservationRepository.CreateReservationAsync(reservation);
            }
        }
    }
}