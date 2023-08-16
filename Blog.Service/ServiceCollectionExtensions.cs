using Blog.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Service;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAddBlogPostService, AddBlogPostService>();
        services.AddTransient<IGetAllBlogPostService, GetAllBlogPostService>();
        services.AddTransient<IGetBlogPostService, GetBlogPostService>();
        services.AddTransient<IUpdateBlogPostService, UpdateBlogPostService>();
        services.AddTransient<IRemoveBlogPostService, RemoveBlogPostService>();
        
        return services;
    }
}
