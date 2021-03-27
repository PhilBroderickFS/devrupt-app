using System.Collections.Generic;

namespace DevRupt.Core.Models.Dtos
{
    public class RecommendedSetDto
    {
        public string Name { get; set; }
        public int Compatibility { get; set; }
        public List<DishDto> Dishes { get; set; }
    }
}