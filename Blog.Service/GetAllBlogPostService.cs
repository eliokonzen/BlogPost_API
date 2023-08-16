using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Core.Services;

namespace Blog.Service
{
    public class GetAllBlogPostService : IGetAllBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;
        
        public GetAllBlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository ?? throw new ArgumentNullException(nameof(blogPostRepository));
        }

        public async Task<IEnumerable<BlogPost>> GetAll()
        {
            return await _blogPostRepository.GetAllAsync();
        }
    }
}
