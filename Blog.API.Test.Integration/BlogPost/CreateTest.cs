using Blog.API.DTOs;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace Blog.Api.Test.Integration.BlogPost;

public class CreateTest : TestBase
{
    [Fact]
    public async Task CreateBlogPost_ShouldReturnOkResult_WithValidInput()
    {
        // Arrange
        const HttpStatusCode expectedCode = HttpStatusCode.OK;
        var blogPostRequest = new
        {
            Title = "Test",
            Content = "The content"
        };
        
        // Act
        var response = await TestClient.PostAsync("/blogpost", JsonContent.Create(blogPostRequest));
        var result = await response.Content.ReadFromJsonAsync<BlogPostDto>();

        // Assert
        response.StatusCode.Should().Be(expectedCode);
        result.Should().NotBeNull();
        result?.Title.Should().Be("Test");
        result?.Content.Should().Be("The content");
        result?.CreatedAt.Should().NotBe(null);
    }

    [Fact]
    public async Task CreateBlogPost_ShouldReturnError_WithInvalidInput()
    {
        // Arrange
        const HttpStatusCode expectedCode = HttpStatusCode.BadRequest;
        var blogPostRequest = new
        {
            Title = "",
            Content = "The content"
        };

        // Act
        var response = await TestClient.PostAsync("/blogpost", JsonContent.Create(blogPostRequest));

        // Assert
        response.StatusCode.Should().Be(expectedCode);
    }
}
