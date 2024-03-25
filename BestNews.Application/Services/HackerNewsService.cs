using AutoMapper;
using BestNews.Application.Contracts.Services;
using BestNews.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace BestNews.Application.Services
{
    public class HackerNewsService : IHackerNewsService
    {
        private IHackerNewsAPIService _hackerNewsApiService;
        private IMapper _mapper;
        private readonly IDistributedCache _cache;
        public HackerNewsService([FromServices] IHackerNewsAPIService hackerNewsApiService, IMapper mapper, IDistributedCache cache)
        {
            _hackerNewsApiService = hackerNewsApiService;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IEnumerable<Story>> GetBestOrderedStories(int number)
        {
            var outputStories = new List<Story>();

            var cacheKey = "bestStoriesCache";

            var cachedStoriesJson = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedStoriesJson))
            {
                outputStories = JsonConvert.DeserializeObject<List<Story>>(cachedStoriesJson);
            }
            else
            {
                outputStories = await FetchAndCacheBestStories(cacheKey);
            }

            return outputStories.OrderByDescending(s => s.Score).Take(number);
        }

        private async Task<List<Story>> FetchAndCacheBestStories(string cacheKey)
        {
            var bestStories = await _hackerNewsApiService.GetBestStories();
            var stories = new List<Story>();

            Array.Sort(bestStories);

            var tasks = bestStories.Select(async storyId =>
            {
                var story = await GetStoryFromCache(storyId);
                stories.Add(story);
            }).ToList();

            await Task.WhenAll(tasks);

            var outputStories = _mapper.Map<List<Story>>(stories);

            var cachedStoriesJson = JsonConvert.SerializeObject(outputStories);
            await _cache.SetStringAsync(cacheKey, cachedStoriesJson, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            });

            return outputStories;
        }

        private async Task<Story> GetStoryFromCache(int storyId)
        {
            var cachedStoryJson = await _cache.GetStringAsync($"story:{storyId}");

            if (!string.IsNullOrEmpty(cachedStoryJson))
            {
                return JsonConvert.DeserializeObject<Story>(cachedStoryJson);
            }

            var story = await _hackerNewsApiService.GetStoryById(storyId);

            // Store story in cache
            await _cache.SetStringAsync($"story:{storyId}", JsonConvert.SerializeObject(story), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            });

            return story;
        }
    }
}
