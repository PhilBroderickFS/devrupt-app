using System.Threading.Tasks;
using DevRupt.Core.Models;

namespace DevRupt.Core.Repositories
{
    public interface IRatePlanRepository
    {
        Task<RatePlan> GetExistingRatePlan(string id);
    }
}