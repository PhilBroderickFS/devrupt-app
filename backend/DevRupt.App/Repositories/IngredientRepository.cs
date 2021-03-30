using DevRupt.App.Data;
using DevRupt.Core.Contracts;
using DevRupt.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevRupt.App.Repositories
{
    public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task CreateIngredientAsync(Ingredient ingredient)
        {
            var mealExists = (await FindByConditionAync(r => r.IngredientId.Equals(ingredient.IngredientId))).FirstOrDefault();

            if (mealExists != null)
            {
                return;
            }
            Create(ingredient);
            await SaveAsync();
        }

        public async Task DeleteIngredientAsync(Ingredient ingredient)
        {
            Delete(ingredient);
            await SaveAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            return await FindAllAsync();
        }

        public async Task<Ingredient> GetExistingIngredient(string ingredientId)
        {
            return (await FindByConditionAync(f => f.IngredientId.Equals(ingredientId))).FirstOrDefault();
        }
    }
}
