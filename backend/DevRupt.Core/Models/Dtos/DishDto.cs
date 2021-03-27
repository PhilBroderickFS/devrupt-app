using System.Collections.Generic;

namespace DevRupt.Core.Models.Dtos
{
    public class DishDto
    {
        public string Name { get; set; }
        public List<IngredientDto> Ingredients { get; set; }
    }
}