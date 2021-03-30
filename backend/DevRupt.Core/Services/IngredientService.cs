using DevRupt.Core.Contracts;
using DevRupt.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DevRupt.Core.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IRepositoryWrapper _repoWrapper;

        public IngredientService(IHttpClientFactory httpClientFactory, IRepositoryWrapper repoWrapper)
        {
            _httpClientFactory = httpClientFactory;
            _repoWrapper = repoWrapper;
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsFromApi()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://www.themealdb.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("api/json/v1/1/list.php?i=list");

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var ingredients = JsonConvert.DeserializeObject<IngredientList>(responseString);

                    foreach (var ingredient in ingredients.Ingredients)
                    {
                        await _repoWrapper.Ingredient.CreateIngredientAsync(ingredient);
                        _repoWrapper.Save();
                    }

                    return ingredients.Ingredients;
                }



            }
            catch (Exception ex)
            {

            }
            return new List<Ingredient>(); ;
        }
    }
}
