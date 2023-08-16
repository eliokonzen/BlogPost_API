
using Blog.Core.Entities;
using Blog.Core.Repositories;

namespace Blog.Service.Test.Unit;

public class GetBlogPostServiceTest
{
    private readonly Mock<IBlogPostRepository> _mockBlockPostRepository;
    private readonly GetBlogPostService _getBlogPostService;

    public GetBlogPostServiceTest()
    {
        _mockBlockPostRepository = new Mock<IBlogPostRepository>();
        _getBlogPostService = new GetBlogPostService(_mockBlockPostRepository.Object);
    }

    [Fact]
    public async Task ShouldReturnThePost_WhenIdIsValid()
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
            .Setup(x => x.GetByIdAsync(It.Is<int>(x => x == id)))
            .ReturnsAsync(blogPost);

        // Act 
        var result = await _getBlogPostService.GetById(id);

        // Assert
        result.Should().NotBeNull();
        result?.Title.Should().Be("Test");
    }

    [Fact]
    public async Task ShouldReturnNull_WhenIdIsNotValid()
    {
        // Arrange
        var id = 999;
        var blogPost = new BlogPost
        {
            Id = id,
            Title = "Test",
            Content = "Test",
        };

       _mockBlockPostRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(null as BlogPost);

        // Act 
        var result = await _getBlogPostService.GetById(id);

        // Assert
        result.Should().BeNull();
    }
}