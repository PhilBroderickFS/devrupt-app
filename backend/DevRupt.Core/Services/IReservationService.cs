using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevRupt.Core.Models;
using DevRupt.Core.Models.Dtos;

namespace DevRupt.Core.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetReservationsForDate(DateTime dateTime);
        Task<DateTime> GetMostRecentReservationProcess();
        Task AddReservations(IEnumerable<Reservation> reservations);
        IAsyncEnumerable<GuestBookingsDto> GetBookingsForNextDays(int numOfDays);
        Task<GuestBookingsDto> GetBookingsForDate(DateTime date);
    }
}