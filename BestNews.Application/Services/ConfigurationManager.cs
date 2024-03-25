using BestNews.Application.Contracts.Services;
using Microsoft.Extensions.Configuration;
using IConfigurationManager = BestNews.Application.Contracts.Services.IConfigurationManager;

namespace BestNews.Application.Services
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IConfiguration _configuration;
        public ConfigurationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string HackerNewsBaseApi
        {
            get => _configuration["HackerNewsApiBaseUrl"]!;
        }

        public IConfigurationSection GetConfigurationSection(string Key) => _configuration.GetSection(Key);
    }
}
