using BestNews.Domain;
using Refit;

namespace BestNews.Application.Contracts.Services
{
    public interface IHackerNewsAPIService
    {
        [Get("/v0/beststories.json")]
        Task<int[]> GetBestStories();


        [Get("/v0/item/{id}.json")]
        Task<Story> GetStoryById(int id);
    }
}
