using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevRupt.App.Data;
using DevRupt.Core.Clients;
using DevRupt.Core.Contracts;
using DevRupt.Core.Models;

namespace DevRupt.App.Repositories
{
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {
        private readonly IApaleoClient _apaleoClient;

        public ReservationRepository(ApplicationDbContext applicationDbContext, IApaleoClient apaleoClient) :
            base(applicationDbContext)
        {
            _apaleoClient = apaleoClient;
        }

        //public Task<IEnumerable<Reservation>> GetReservationsBetweenDates(DateTime startDate, DateTime endDate)
        //{
        //    var client = _apaleoClient.AuthenticateClient();
        //    var reservations = _apaleoClient.GetReservationsFromDate(client, DateTime.Now.);

            

        //}

        //public Task<DateTime> GetMostRecentReservationProcess()
        //{
            
        //}

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
            //var Reservation = await FindByConditionAync(o => o.Id.Equals(ReservationId));
            //return Reservation.FirstOrDefault();
            return (await FindByConditionAync(f => f.Id.Equals(ReservationId))).FirstOrDefault();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await FindAllAsync();
        }
    }
}