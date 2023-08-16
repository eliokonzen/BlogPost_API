using Blog.Core.Entities;
using Blog.Core.Repositories;


namespace Blog.Service.Test.Unit
{
    public class UpdateBlogPostServiceTest
    {
        private readonly Mock<IBlogPostRepository> _mockBlockPostRepository;
        private readonly UpdateBlogPostService _updateBlogPostService;

        public UpdateBlogPostServiceTest()
        {
            _mockBlockPostRepository = new Mock<IBlogPostRepository>();
            _updateBlogPostService = new UpdateBlogPostService(_mockBlockPostRepository.Object);
        }

        [Fact]
        public async Task ShouldUpdateBlogPost_WhenInvoked()
        {
            // Arrange
            var id = 100;
            var blogPost = new BlogPost
            {
                Id = id,
                Title = "Test",
                Content = "Test",
            };

            _mockBlockPostRepository
               .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
               .ReturnsAsync(blogPost);

            _mockBlockPostRepository
                .Setup(x => x.Update(It.IsAny<BlogPost>()))
                .ReturnsAsync(blogPost);

            // Act 
            var result = await _updateBlogPostService.Update(id, blogPost);

            // Assert
            result.Should().NotBeNull();
            result?.Id.Should().Be(100);
        }

        [Fact]
        public async Task ShouldInvokeRepository_WhenUpdate()
        {
            // Arrange
            var id = 100;
            var blogPost = new BlogPost
            {
                Id = id,
                Title = "Test",
                Content = "Test",
            };

            _mockBlockPostRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(blogPost);

            _mockBlockPostRepository
                .Setup(x => x.Update(It.IsAny<BlogPost>()))
                .ReturnsAsync(blogPost);

            // Act 
            var result = await _updateBlogPostService.Update(id, blogPost);

            // Assert
            _mockBlockPostRepository.Verify(x => x.Update(It.IsAny<BlogPost>()), Times.Once);
        }
    }
}
