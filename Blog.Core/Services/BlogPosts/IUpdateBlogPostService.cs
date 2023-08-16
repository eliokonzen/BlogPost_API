using Blog.Core.Entities;

namespace Blog.Core.Services;

public interface IUpdateBlogPostService
{
    Task<BlogPost?> Update(int id, BlogPost blogPost);
}
