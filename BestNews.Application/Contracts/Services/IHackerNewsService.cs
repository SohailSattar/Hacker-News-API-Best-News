using BestNews.Domain;

namespace BestNews.Application.Contracts.Services
{
    public interface IHackerNewsService
    {
        Task<IEnumerable<Story>> GetBestOrderedStories(int number);
    }
}
