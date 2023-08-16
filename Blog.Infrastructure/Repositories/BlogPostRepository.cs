using Blog.Core.Entities;
using Blog.Core.Repositories;

namespace Blog.Infrastructure.Repositories;

public class BlogPostRepository : RepositoryBase<BlogPost>, IBlogPostRepository
{
    public BlogPostRepository(BlogDbContext dbContext) : base(dbContext)
    {
    }
}
