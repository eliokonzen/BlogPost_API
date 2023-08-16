using Blog.Core.Repositories;
using Blog.Core.Services;

namespace Blog.Service
{
    public class RemoveBlogPostService : IRemoveBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public RemoveBlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository ?? throw new ArgumentNullException(nameof(blogPostRepository));
        }

        public async Task<bool> Remove(int id)
        {
            var blogPostEntity = await _blogPostRepository.GetByIdAsync(id);
            if (blogPostEntity == null)
                return false;

            await _blogPostRepository.Remove(blogPostEntity);
            return true;
        }
    }
}
