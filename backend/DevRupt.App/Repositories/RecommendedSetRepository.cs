using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevRupt.App.Data;
using DevRupt.Core.Contracts;
using DevRupt.Core.Models;

namespace DevRupt.App.Repositories
{
    public class RecommendedSetRepository : RepositoryBase<Set>, IRecommendedSetRepository
    {
        private readonly Random _rng = new();
        
        public RecommendedSetRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }
        
        /// <summary>
        /// Will retrieve from database when ready
        /// </summary>
        public async Task<IEnumerable<Set>> GetRecommendedSetsForGuests(int numberOfSets, 
            IEnumerable<string> guestIds)
        {            
            // TODO retrieve from database - not sure how this is going to be filtered - by guest??
            var sets = new List<Set>();
            for (int i = 0; i < numberOfSets; i++)
            {
                var dishes = GetStubDishes();
                sets.Add(new Set
                {
                    Name = $"Set {i}",
                    Compatibility = GetRandomCompatibility(),
                    Dishes = dishes.ToList()
                });
            }

            return sets;
        }
        
        private int GetRandomCompatibility()
        {
            return _rng.Next(0, 101);
        }

        /// <summary>
        /// Just a stub method for now until data available in database
        /// </summary>
        private IEnumerable<Dish> GetStubDishes()
        {
            const int maxDishes = 5;
            var dishes = new List<Dish>();
            for (int i = 0; i < maxDishes; i++)
            {
                dishes.Add(new Dish
                {
                    Name = $"Dish {i}",
                    Ingredients = GetStubIngredients().ToList()
                });
            }

            return dishes;
        }

        /// <summary>
        /// Stub method to return ingredients for dish until data available in database
        /// </summary>
        private IEnumerable<Ingredient> GetStubIngredients()
        {
            // just a placeholder
            var measurements = new Dictionary<int, string>
            {
                {0, "kg"},
                {1, "ml"},
                {2, "oz"}
            };
            
            // we won't need to define this - this will come from database 
            var numOfIngredients = _rng.Next(0, 10);
            var ingredients = new List<Ingredient>();

            for (int i = 0; i < numOfIngredients; i++)
            {
                ingredients.Add(new Ingredient
                {
                    Name = $"Ingredient {i}",
                    Amount = _rng.Next(1, 1000),
                    Measurement = measurements[_rng.Next(0, 3)]
                });
            }

            return ingredients;
        }
    }
}