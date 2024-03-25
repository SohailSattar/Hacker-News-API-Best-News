using BestNews.Application.DTO.Item;
using MediatR;

namespace BestNews.Application.Features.Stories.Requests.Queries
{
    public class GetStoriesListByCountRequest : IRequest<IReadOnlyList<StoryDto>>
    {
        public int Count { get; set; }
    }
}
