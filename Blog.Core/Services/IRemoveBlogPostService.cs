namespace Blog.Core.Services;

public interface IRemoveBlogPostService
{
    Task<bool> Remove(int id);
}
