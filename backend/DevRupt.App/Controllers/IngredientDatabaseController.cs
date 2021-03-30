using DevRupt.Core.Models;
using DevRupt.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevRupt.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientDatabaseController
    {
        private readonly IIngredientService _ingredientService;

        public IngredientDatabaseController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }


        [HttpPost]
        public Task<IEnumerable<Ingredient>> GetIngredientsFromExternalAPI()
        {
            return _ingredientService.GetIngredientsFromApi();
        }
    }
}
