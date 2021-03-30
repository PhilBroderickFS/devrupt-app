using System.Collections.Generic;
using System.Threading.Tasks;
using DevRupt.Core.Models;
using DevRupt.Core.Models.Dtos;

namespace DevRupt.Core.Services
{
    public interface IRecommendationService
    {
        IAsyncEnumerable<RecommendedSetDto> GetRecommendedSets(int numberOfDishes, IEnumerable<string> guestIds);

        

    }
}