using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevRupt.Core.Models;
using DevRupt.Core.Repositories;

namespace DevRupt.Data.Repositories
{
    public class ReservationRepository : RepositoryBase<Reservation> , IReservationRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReservationRepository(ApplicationDbContext _applicationDbContext, IMapper mapper) : 
            base(_applicationDbContext)
        {
            _context = _applicationDbContext;
            _mapper = mapper;
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
            Create(reservation);
            await SaveAsync();
        }

        public async Task DeleteReservationAsync(Reservation reservation)
        {
            Delete(reservation);
            await SaveAsync();

        }

        public async Task<Reservation> GetReservationByIdAsync(int ReservationId)
        {
            var Reservation = await FindByConditionAync(o => o.Id.Equals(ReservationId));
            return Reservation.FirstOrDefault();
        }

    }
}