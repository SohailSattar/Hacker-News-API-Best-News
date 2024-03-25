using AutoMapper;
using BestNews.Application.Contracts.Services;
using BestNews.Application.DTO.Item;
using BestNews.Application.Features.Stories.Requests.Queries;
using MediatR;

namespace BestNews.Application.Features.Stories.Handlers.Queries
{
    public class GetStoriesListByCountRequestHandler : IRequestHandler<GetStoriesListByCountRequest, IReadOnlyList<StoryDto>>
    {
        private readonly IHackerNewsService _hackerNewsService;
        private readonly IMapper _mapper;
        public GetStoriesListByCountRequestHandler(IHackerNewsService hackerNewsService, IMapper mapper)
        {
            _hackerNewsService = hackerNewsService;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<StoryDto>> Handle(GetStoriesListByCountRequest request, CancellationToken cancellationToken)
        {
            var stories = await _hackerNewsService.GetBestOrderedStories(request.Count);// (request.Count, cancellationToken);
            return _mapper.Map<IReadOnlyList<StoryDto>>(stories);
        }
    }
}