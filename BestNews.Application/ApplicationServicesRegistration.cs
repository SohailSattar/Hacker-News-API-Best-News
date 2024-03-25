using BestNews.Application.Contracts.Services;
using BestNews.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Reflection;

namespace BestNews.Application
{

    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var hackerNewsBaseApi = configuration["HackerNewsApiBaseUrl"];
            if (string.IsNullOrEmpty(hackerNewsBaseApi))
            {
                throw new ArgumentNullException(nameof(hackerNewsBaseApi), "HackerNewsBaseApi is not configured.");
            }

            // Register Refit client with base URL configured from appsettings
            services.AddRefitClient<IHackerNewsAPIService>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(hackerNewsBaseApi));

            services.AddScoped(typeof(IHackerNewsService), typeof(HackerNewsService));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}