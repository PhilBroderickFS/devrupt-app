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

}