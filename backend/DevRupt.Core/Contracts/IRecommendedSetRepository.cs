using System.Collections.Generic;
using System.Threading.Tasks;
using DevRupt.Core.Models;
using DevRupt.Core.Models.Dtos;

namespace DevRupt.Core.Contracts
{
    public interface IRecommendedSetRepository
    {
        public Task<IEnumerable<Set>> GetRecommendedSetsForGuests(int numberOfSets, IEnumerable<string> guestIds);
    }
}