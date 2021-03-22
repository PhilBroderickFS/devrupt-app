using System.Collections.Generic;
using System.Threading.Tasks;
using DevRupt.Core.Models;

namespace DevRupt.Core.Contracts
{
    public interface IFolioRepository : IRepositoryBase<Folio>
    {
        Task<Folio> GetExistingFolio(string folioId);
        Task<IEnumerable<Folio>> GetAllFoliosAsync();
        Task CreateFolioAsync(Folio folio);
        Task DeleteFolioAsync(Folio folio);
    }
}