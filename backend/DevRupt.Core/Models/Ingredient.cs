using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevRupt.Core.Models
{
    public class Ingredient
    {

        [JsonProperty("strIngredient")]
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Measurement { get; set; }

        [Key]
        [JsonProperty("idIngredient")]
        public string IngredientId { get; set; }


        [JsonProperty("strDescription")]
        public string Description { get; set; }

        [JsonProperty("strType")]
        public string Type { get; set; }
    }

    public class IngredientList
    {
        [JsonProperty("meals")]
        public List<Ingredient> Ingredients { get; set; }
    }
}