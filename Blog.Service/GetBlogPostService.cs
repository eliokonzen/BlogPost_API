using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Core.Services;

namespace Blog.Service
{
    public class GetBlogPostService : IGetBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;
        
        public GetBlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository ?? throw new ArgumentNullException(nameof(blogPostRepository));
        }
        
        public async Task<BlogPost?> GetById(int id)
        {
            return await _blogPostRepository.GetByIdAsync(id);
        }
    }
}
