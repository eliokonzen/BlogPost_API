using Blog.Core.Entities;

namespace Blog.Core.Services;

public interface IGetBlogPostService
{
    Task<BlogPost?> GetById(int id);
}
