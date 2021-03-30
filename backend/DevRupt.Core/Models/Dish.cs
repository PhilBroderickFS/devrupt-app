using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevRupt.Core.Models
{
    public class Dish
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }

    }


    public class MealList
    {
        public List<Meal> Meals { get; set; }
    }

    public class Meal
    {
        [Key]
        [JsonProperty("idIngredient")]
        public string IngredientId { get; set; }

        [JsonProperty("strIngredient")]
        public string Ingredient { get; set; }

        [JsonProperty("strDescription")]
        public string Description { get; set; }

        [JsonProperty("strType")]
        public string Type { get; set; }
    }

}