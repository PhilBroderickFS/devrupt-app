using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevRupt.Core.Contracts;
using DevRupt.Core.Models;
using DevRupt.Core.Models.Dtos;

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

        public async IAsyncEnumerable<GuestBookingsDto> GetBookingsForNextDays(int numOfDays)
        {
            for (int i = 0; i < numOfDays; i++)
            {
                var date = DateTime.Today.AddDays(i);
                var reservationForDate = await _reservationRepository.GetReservationsForDate(date);
                var guestDtos = reservationForDate.Select(r => new GuestDto
                {
                    GuacId = r.PrimaryGuest.Id.ToString(),
                    GuestName = $"{r.PrimaryGuest.FirstName} {r.PrimaryGuest.LastName}"
                }).ToList();

                yield return new GuestBookingsDto
                {
                    Date = date,
                    Guests = guestDtos
                };
            }
        }

        public async Task<GuestBookingsDto> GetBookingsForDate(DateTime date)
        {
            var reservationForDate = await _reservationRepository.GetReservationsForDate(date);
            var guestDtos = reservationForDate.Select(r => new GuestDto
            {
                GuacId = r.PrimaryGuest.Id.ToString(),
                GuestName = $"{r.PrimaryGuest.FirstName} {r.PrimaryGuest.LastName}"
            }).ToList();

            return new GuestBookingsDto
            {
                Date = date,
                Guests = guestDtos
            };
        }
    }
}