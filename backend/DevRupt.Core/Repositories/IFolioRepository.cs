using System.Threading.Tasks;
using DevRupt.Core.Models;

namespace DevRupt.Core.Repositories
{
    public interface IFolioRepository
    {
        Task<Folio> GetExistingFolio(string folioId);
    }
}