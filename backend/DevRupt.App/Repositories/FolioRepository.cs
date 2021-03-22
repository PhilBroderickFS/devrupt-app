using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevRupt.App.Data;
using DevRupt.Core.Contracts;
using DevRupt.Core.Models;

namespace DevRupt.App.Repositories
{
    public class FolioRepository : RepositoryBase<Folio>, IFolioRepository
    {
        public FolioRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }

        public async Task CreateFolioAsync(Folio folio)
        {
            var folioExists = (await FindByConditionAync(r => r.Id.Equals(folio.Id))).FirstOrDefault();

            if (folioExists != null)
            {
                return;
            }
            Create(folio);
            await SaveAsync();
        }

        public async Task DeleteFolioAsync(Folio folio)
        {
            Delete(folio);
            await SaveAsync();
        }

        public async Task<IEnumerable<Folio>> GetAllFoliosAsync()
        {
            return await FindAllAsync();
        }

        public async Task<Folio> GetExistingFolio(string folioId)
        {

            return (await FindByConditionAync(f => f.Id.Equals(folioId))).FirstOrDefault();
        }
    }
}