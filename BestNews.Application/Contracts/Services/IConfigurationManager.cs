using Microsoft.Extensions.Configuration;

namespace BestNews.Application.Contracts.Services
{
    public interface IConfigurationManager
    {
        string HackerNewsBaseApi { get; }
        IConfigurationSection GetConfigurationSection(string Key);
    }
}
