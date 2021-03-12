using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevRupt.Core.Models;

namespace DevRupt.Core.Repositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservationsBetweenDates(DateTime startDate, DateTime endDate);
    }
}