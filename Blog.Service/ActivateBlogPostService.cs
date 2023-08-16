using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Core.Services;

namespace Blog.Service;

public class ActivateBlogPostService : IActivateBlogPostService
{
    private readonly IBlogPostRepository _blogPostRepository;

    public ActivateBlogPostService(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository ?? throw new ArgumentNullException(nameof(blogPostRepository));
    }

    public async Task<BlogPost?> Activate(int id)
    {
        var blogPost = await _blogPostRepository.GetByIdAsync(id);
        if (blogPost != null)
        {
            blogPost.SetActive(true);
            await _blogPostRepository.Update(blogPost);
        }

        return blogPost;
    }
}
