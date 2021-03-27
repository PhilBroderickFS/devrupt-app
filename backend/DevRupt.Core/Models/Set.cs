using System.Collections.Generic;

namespace DevRupt.Core.Models
{
    public class Set
    {
        public string Name { get; set; }
        public int Compatibility { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}