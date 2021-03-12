using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevRupt.Core.Models;

namespace DevRupt.Core.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetReservationsForDate(DateTime dateTime);
    }
}