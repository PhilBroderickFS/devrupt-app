using System.Linq;
using System.Threading.Tasks;
using DevRupt.App.Data;
using DevRupt.Core.Models;
using DevRupt.Core.Repositories;

namespace DevRupt.App.Repositories
{
    public class FolioRepository : RepositoryBase<Folio>, IFolioRepository
    {
        public FolioRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }

        public async Task<Folio> GetExistingFolio(string folioId)
        {
            return (await FindByConditionAync(f => f.Id.Equals(folioId))).FirstOrDefault();
        }
    }
}