using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevRupt.Core.Models;
using DevRupt.Core.Repositories;

namespace DevRupt.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public Task<IEnumerable<Reservation>> GetReservationsBetweenDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}