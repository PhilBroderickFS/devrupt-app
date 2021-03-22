using System.Collections.Generic;
using System.Threading.Tasks;
using DevRupt.Core.Models;

namespace DevRupt.Core.Contracts
{
    public interface IRatePlanRepository : IRepositoryBase<RatePlan>
    {
        Task<RatePlan> GetExistingRatePlan(string rateplanId);

        Task<IEnumerable<RatePlan>> GetAllRatePlansAsync();
        Task CreateRatePlanAsync(RatePlan rateplan);
        Task DeleteRatePlanAsync(RatePlan rateplan);
    }
}