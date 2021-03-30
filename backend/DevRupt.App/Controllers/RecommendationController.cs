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
        private readonly IIngredientService _ingredientService;

        public RecommendationController(IRecommendationService recommendationService, IIngredientService ingredientService)
        {
            _recommendationService = recommendationService;
            _ingredientService = ingredientService;
        }

        [HttpPost]
        public IAsyncEnumerable<RecommendedSetDto> GetRecommendedSets([FromBody] RecommendedSetRequest recommendedSetRequest)
        {
            return _recommendationService.GetRecommendedSets(recommendedSetRequest.NumberOfDishes, recommendedSetRequest.GuestIds);
        }

        [HttpGet]
        public Task <IEnumerable<Ingredient>> GetMealsFromExternalAPI()
        {
            return _ingredientService.GetIngredientsFromApi();
        }
    }

    public class RecommendedSetRequest
    {
        public int NumberOfDishes { get; set; }
        public List<string> GuestIds { get; set; }
    }
}