using Blog.Core.Entities;

namespace Blog.Core.Services;

public interface IActivateBlogPostService
{
    Task<BlogPost?> Activate(int id);
}
