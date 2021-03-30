using System.Collections.Generic;
using System.Threading.Tasks;
using DevRupt.Core.Models;
using DevRupt.Core.Models.Dtos;
using DevRupt.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevRupt.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpPost]
        public IAsyncEnumerable<RecommendedSetDto> GetRecommendedSets([FromBody] RecommendedSetRequest recommendedSetRequest)
        {
            return _recommendationService.GetRecommendedSets(recommendedSetRequest.NumberOfDishes, recommendedSetRequest.GuestIds);
        }

        [HttpGet]
        public Task <IEnumerable<Meal>> GetMealsFromExternalAPI()
        {
            return _recommendationService.GetMeals();
        }
    }

    public class RecommendedSetRequest
    {
        public int NumberOfDishes { get; set; }
        public List<string> GuestIds { get; set; }
    }
}