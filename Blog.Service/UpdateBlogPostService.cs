using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Core.Services;

namespace Blog.Service
{
    public class UpdateBlogPostService : IUpdateBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public UpdateBlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository ?? throw new ArgumentNullException(nameof(blogPostRepository));
        }

        public async Task<BlogPost?> Update(int id, BlogPost blogPost)
        {
            var blogPostEntity = await _blogPostRepository.GetByIdAsync(id);
            if (blogPostEntity != null)
            {
                blogPostEntity.SetTitle(blogPost.Title);
                blogPostEntity.SetContent(blogPost.Content);
                blogPostEntity.SetUpdatedAt(DateTime.Now);
                blogPostEntity = await _blogPostRepository.Update(blogPostEntity);
            }

            return blogPostEntity;
        }
    }
}
