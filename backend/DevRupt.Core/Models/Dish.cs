using System.Collections.Generic;

namespace DevRupt.Core.Models
{
    public class Dish
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}