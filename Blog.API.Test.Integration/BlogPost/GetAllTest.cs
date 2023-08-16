using System.Net.Http.Json;
using System.Net;
using Blog.API.DTOs;
using FluentAssertions;

namespace Blog.Api.Test.Integration.BlogPost
{
    public class GetAllTest : TestBase
    {
        [Fact]
        public async Task GetBlogPost_ShouldReturnOk()
        {
            // Arrange
            const HttpStatusCode expectedCode = HttpStatusCode.OK;

            // Act
            var response = await TestClient.GetAsync("/blogpost");
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<BlogPostDto>>();

            // Assert
            response.StatusCode.Should().Be(expectedCode);
            result.Should().NotBeNull();
        }
    }
}
