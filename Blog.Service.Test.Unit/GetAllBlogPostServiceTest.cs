using Blog.Core.Entities;
using Blog.Core.Repositories;

namespace Blog.Service.Test.Unit;

public class GetAllBlogPostServiceTest
{
    private readonly Mock<IBlogPostRepository> _mockBlockPostRepository;
    private readonly GetAllBlogPostService _getAllBlogPostService;

    public GetAllBlogPostServiceTest()
    {
        _mockBlockPostRepository = new Mock<IBlogPostRepository>();
        _getAllBlogPostService = new GetAllBlogPostService(_mockBlockPostRepository.Object);
    }

    [Fact]
    public async Task ShouldReturnAllBlogPost_WhenInvoked()
    {
        // Arrange
        var blogPostList = new List<BlogPost> 
        {
            new() 
            {
                Id = 1,
                Title = "Test",
                Content = "Test",
            }
        };

        _mockBlockPostRepository
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(blogPostList);

        // Act 
        var result = await _getAllBlogPostService.GetAll();

        // Assert
        result.Should().NotBeNull();
        result.Count().Should().Be(1);
    }
}
