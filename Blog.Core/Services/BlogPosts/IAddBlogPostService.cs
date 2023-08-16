
namespace Blog.Core.Services;

public interface IAddBlogPostService
{
    Task<Entities.BlogPost> Add(Entities.BlogPost blogPost);
}
