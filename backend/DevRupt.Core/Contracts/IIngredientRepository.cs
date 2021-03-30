using DevRupt.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevRupt.Core.Contracts
{
    public interface IIngredientRepository : IRepositoryBase<Ingredient>
    {

        Task<Ingredient> GetExistingIngredient(string ingredientId);
        Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();
        Task CreateIngredientAsync(Ingredient ingredient);
        Task DeleteIngredientAsync(Ingredient ingredient);
    }
}
