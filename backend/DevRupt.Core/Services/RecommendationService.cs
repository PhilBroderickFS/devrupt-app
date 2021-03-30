using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using DevRupt.Core.Contracts;
using DevRupt.Core.Models;
using DevRupt.Core.Models.Dtos;
using Newtonsoft.Json;

namespace DevRupt.Core.Services
{
    public class RecommendationService: IRecommendationService
    {
        private readonly IRecommendedSetRepository _recommendedSetRepository;
        private readonly IMapper _mapper;
 

        public RecommendationService(IRecommendedSetRepository recommendedSetRepository, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _recommendedSetRepository = recommendedSetRepository;
            _mapper = mapper;
        }

        public async IAsyncEnumerable<RecommendedSetDto> GetRecommendedSets(int numberOfDishes, IEnumerable<string> guestIds)
        {
            // always going to return 3 sets - but with variable amounts of dishes - from 1 to 5
            const int numberOfSets = 3;

            var sets = await _recommendedSetRepository.GetRecommendedSetsForGuests(numberOfSets, guestIds);
            foreach (var set in sets.OrderByDescending(s => s.Compatibility))
            {
                set.Dishes = set.Dishes.Take(numberOfDishes).ToList();
                yield return _mapper.Map<RecommendedSetDto>(set);
            }
        }
        
    }
}