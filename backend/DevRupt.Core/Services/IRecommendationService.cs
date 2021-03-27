using System.Collections.Generic;
using DevRupt.Core.Models.Dtos;

namespace DevRupt.Core.Services
{
    public interface IRecommendationService
    {
        IAsyncEnumerable<RecommendedSetDto> GetRecommendedSets(int numberOfDishes, IEnumerable<string> guestIds);
    }
}