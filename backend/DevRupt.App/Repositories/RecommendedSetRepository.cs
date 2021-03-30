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
        public async Task<IEnumerable<Set>> GetRecommendedSetsForGuests(int numberOfSets, IEnumerable<string> guestIds)
        {            
            // TODO retrieve from database - not sure how this is going to be filtered - by guest??
            var sets = new List<Set>();
            
            // randomise ingredients for the sake of MVP
            var randomisedIngredientsList = _applicationDbContext.Ingredients.ToList();
            
            for (int i = 0; i < numberOfSets; i++)
            {
                var dishes = GetStubDishes(randomisedIngredientsList);
                sets.Add(new Set
                {
                    Name = $"Set {i + 1}",
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
        private IEnumerable<Dish> GetStubDishes(List<Ingredient> ingredients)
        {
            const int maxDishes = 5;
            var dishes = new List<Dish>();
            
            for (int i = 0; i < maxDishes; i++)
            {
                dishes.Add(new Dish
                {
                    Name = $"Dish {i + 1}",
                    Ingredients = GetStubIngredients(ingredients.OrderBy(_ => Guid.NewGuid()).ToList()).ToList()
                });
            }

            return dishes;
        }

        /// <summary>
        /// Stub method to return ingredients for dish until data available in database
        /// </summary>
        private IEnumerable<Ingredient> GetStubIngredients(List<Ingredient> randomisedIngredientsList)
        {
            // just a placeholder
            var measurements = new Dictionary<int, string>
            {
                {0, "g"},
                {1, "ml"},
                {2, "oz"}
            };
            
            var numOfIngredients = _rng.Next(1, 10);
            var ingredients = new List<Ingredient>();

            for (int i = 0; i < numOfIngredients; i++)
            {
                var measurement = measurements[_rng.Next(0, 3)];
                
                ingredients.Add(new Ingredient
                {
                    Name = randomisedIngredientsList[i].Name,
                    Amount = GetAmountBasedOnMeasurement(measurement),
                    Measurement = measurement
                });
            }

            return ingredients;
        }

        private int GetAmountBasedOnMeasurement(string measurement)
        {
            return measurement switch
            {
                "g" or "ml" => _rng.Next(1, 1001),
                "oz" => _rng.Next(1, 5),
                _ => _rng.Next(1, 10)
            };
        }

    }
}