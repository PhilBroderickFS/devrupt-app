using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevRupt.Core.Models;

namespace DevRupt.Core.Contracts
{
    public interface IReservationRepository : IRepositoryBase<Reservation>
    {
        Task<IEnumerable<Reservation>> GetReservationsBetweenDates(DateTime startDate, DateTime endDate);
        Task<DateTime> GetMostRecentReservationProcess();
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(string reservationId);
        Task CreateReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(Reservation reservation);
    }
}