using DevRupt.App.Data;
using DevRupt.Core.Contracts;

namespace DevRupt.App.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _applicationContext;
        private IReservationRepository _reservation;
        private IFolioRepository _folio;
        private IRatePlanRepository _rateplan;

        public RepositoryWrapper(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public IFolioRepository Folio
        {
            get
            {
                if(_folio == null)
                {
                    _folio = new FolioRepository(_applicationContext);
                }
                return _folio;
            }
        }

        public IReservationRepository Reservation
        {
            get
            {
                //if (_reservation == null)
                //{
                //    _reservation = new ReservationRepository(_applicationContext);
                //}
                return _reservation;
            }
        }


        public IRatePlanRepository RatePlan
        {
            get
            {
                if (_rateplan == null)
                {
                    _rateplan = new RatePlanRepository(_applicationContext);
                }
                return _rateplan;
            }
        }

        public void Save()
        {
            _applicationContext.SaveChanges();
        }
    }
}
