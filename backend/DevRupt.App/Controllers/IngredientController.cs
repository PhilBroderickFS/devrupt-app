using DevRupt.Core.Contracts;
using DevRupt.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevRupt.App.Controllers
{
    public class IngredientController: ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public IngredientController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
            var ingredients = await _repoWrapper.Ingredient.GetAllIngredientsAsync();

            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredient(string id)
        {
            var ingredient = await _repoWrapper.Ingredient.GetExistingIngredient(id);

            return Ok(ingredient);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(string id)
        {
            var ingredient = await _repoWrapper.Ingredient.GetExistingIngredient(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            await _repoWrapper.Ingredient.DeleteIngredientAsync(ingredient);
            _repoWrapper.Save();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                return BadRequest("Ingredient object is null");
            }

            await _repoWrapper.Ingredient.CreateIngredientAsync(ingredient);
            _repoWrapper.Save();

            return CreatedAtRoute("GetIngredient", new { id = ingredient.IngredientId}, ingredient);
        }

    }
}
