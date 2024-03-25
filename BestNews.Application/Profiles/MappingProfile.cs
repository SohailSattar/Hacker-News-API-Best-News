using AutoMapper;
using BestNews.Application.DTO.Item;
using BestNews.Domain;

namespace BestNews.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Story, StoryDto>()
                .ForMember(dest => dest.Uri, opt => opt.MapFrom(src => src.Url))
                .ForMember(dest => dest.PostedBy, opt => opt.MapFrom(src => src.By))
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.Descendants))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time).LocalDateTime.ToString("yyyy-MM-ddTHH:mm:ssK")))
                .ReverseMap();
        }
    }
}
