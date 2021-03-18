using System.Threading.Tasks;
using DevRupt.App.Data;
using DevRupt.App.Models;
using DevRupt.Core.Repositories;

namespace DevRupt.App.Repositories
{
    public class RatePlanRepository : RepositoryBase<RatePlan>, IRatePlanRepository
    {
        public RatePlanRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }

        public async Task<Core.Models.RatePlan> GetExistingRatePlan(string id)
        {
            return await _applicationDbContext.RatePlans.FindAsync(id);
        }
    }
}