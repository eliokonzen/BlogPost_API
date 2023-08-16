using Blog.Core.Entities;
using Blog.Core.Repositories;

namespace Blog.Service.Test.Unit;

public class CreateBlogPostServiceTest
{
    private readonly Mock<IBlogPostRepository> _mockBlockPostRepository;
    private readonly AddBlogPostService _addBlogPostService;

    public CreateBlogPostServiceTest()
    {
        _mockBlockPostRepository = new Mock<IBlogPostRepository>();
        _addBlogPostService = new AddBlogPostService(_mockBlockPostRepository.Object);
    }

    [Fact]
    public async Task ShouldSaveBlogPost_WhenInvoke()
    {
        // Arrange
        var blogPost = new BlogPost
        {
            Id = 1,
            Title = "Test",
            Content = "Test",
        };

        _mockBlockPostRepository
            .Setup(x => x.AddAsync(It.IsAny<BlogPost>()))
            .ReturnsAsync(blogPost);

        // Act 
        var result = await _addBlogPostService.Add(blogPost);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(1);
    }

    [Fact]
    public async Task ShouldInvokeRepository_WhenCreate()
    {
        // Arrange
        var blogPost = new BlogPost
        {
            Id = 1,
            Title = "Test",
            Content = "Test",
        };

        _mockBlockPostRepository
            .Setup(x => x.AddAsync(It.IsAny<BlogPost>()))
            .ReturnsAsync(blogPost);

        // Act 
        var result = await _addBlogPostService.Add(blogPost);

        // Assert
        _mockBlockPostRepository.Verify(x => x.AddAsync(It.IsAny<BlogPost>()), Times.Once);
    }
}
