using Blog.Core.Entities;

namespace Blog.Core.Services;

public interface IGetAllBlogPostService
{
    Task<IEnumerable<BlogPost>> GetAll();
}
