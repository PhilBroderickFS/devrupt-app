using DevRupt.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevRupt.Core.Services
{
    public interface IIngredientService
    {
        Task<IEnumerable<Ingredient>> GetIngredientsFromApi();
    }
}
