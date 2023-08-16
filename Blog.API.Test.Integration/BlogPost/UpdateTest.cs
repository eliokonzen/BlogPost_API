using Blog.API.DTOs;
using System.Net.Http.Json;
using System.Net;
using FluentAssertions;

namespace Blog.Api.Test.Integration.BlogPost;

public class UpdateTest : TestBase
{
    [Fact]
    public async Task CreateBlogPost_ShouldReturnError_WithInvalidId()
    {
        // Arrange
        const HttpStatusCode expectedCode = HttpStatusCode.NotFound;
        var blogPostRequest = new
        {
            Title = "Test",
            Content = "The content"
        };

        // Act
        var response = await TestClient.PutAsync("/blogpost/100", JsonContent.Create(blogPostRequest));

        // Assert
        response.StatusCode.Should().Be(expectedCode);
    }
}
