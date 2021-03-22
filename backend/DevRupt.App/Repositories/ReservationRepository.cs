using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevRupt.App.Data;
using DevRupt.Core.Contracts;
using DevRupt.Core.Models;

namespace DevRupt.App.Repositories
{
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {

        public ReservationRepository(ApplicationDbContext applicationDbContext) :
            base(applicationDbContext)
        {
        }

        public Task<IEnumerable<Reservation>> GetReservationsBetweenDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<DateTime> GetMostRecentReservationProcess()
        {
            throw new NotImplementedException();
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            var reservationExists = (await FindByConditionAync(r => r.Id.Equals(reservation.Id))).FirstOrDefault();
            
            if (reservationExists != null)
            {
                return;
            }
            
            Create(reservation);
            await SaveAsync();
        }

        public async Task DeleteReservationAsync(Reservation reservation)
        {
            Delete(reservation);
            await SaveAsync();

        }

        public async Task<Reservation> GetReservationByIdAsync(string ReservationId)
        {
            var Reservation = await FindByConditionAync(o => o.Id.Equals(ReservationId));
            return Reservation.FirstOrDefault();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await FindAllAsync();
        }
    }
}