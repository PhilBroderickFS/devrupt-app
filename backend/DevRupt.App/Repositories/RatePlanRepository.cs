using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevRupt.App.Data;
using DevRupt.Core.Contracts;
using DevRupt.Core.Models;

namespace DevRupt.App.Repositories
{
    public class RatePlanRepository : RepositoryBase<RatePlan>, IRatePlanRepository
    {
        public RatePlanRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }

        public async Task CreateRatePlanAsync(RatePlan rateplan)
        {
            var rateplanExists = (await FindByConditionAync(r => r.Id.Equals(rateplan.Id))).FirstOrDefault();

            if (rateplanExists != null)
            {
                return;
            }
            Create(rateplan);
            await SaveAsync();
        }

        public async Task DeleteRatePlanAsync(RatePlan rateplan)
        {
            Delete(rateplan);
            await SaveAsync();
        }

        public async Task<IEnumerable<RatePlan>> GetAllRatePlansAsync()
        {
            return await FindAllAsync();
        }

        public async Task<RatePlan> GetExistingRatePlan(string rateplanId)
        {
            return (await FindByConditionAync(f => f.Id.Equals(rateplanId))).FirstOrDefault();
        }
    }
}