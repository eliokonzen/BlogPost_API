using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Core.Services;

namespace Blog.Service
{
    public class AddBlogPostService : IAddBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;
        
        public AddBlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository ?? throw new ArgumentNullException(nameof(blogPostRepository));
        }

        public async Task<BlogPost> Add(BlogPost blogPost)
        {
            blogPost.SetCreatedAt(DateTime.UtcNow);
            
            return await _blogPostRepository.AddAsync(blogPost);
        }
    }
}
