using Blog.Core.Repositories;
using Blog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBlogPostRepository, BlogPostRepository>();
           
            return services;
        }
    }
}
