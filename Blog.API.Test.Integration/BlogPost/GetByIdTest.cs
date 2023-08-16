using System.Net;
using FluentAssertions;

namespace Blog.Api.Test.Integration.BlogPost
{
    public class GetByIdTest : TestBase
    {
        [Fact]
        public async Task GetByIdBlogPost_ShouldReturnError_WithInvalidId()
        {
            // Arrange
            const HttpStatusCode expectedCode = HttpStatusCode.NotFound;

            // Act
            var response = await TestClient.GetAsync("/blogpost/100");

            // Assert
            response.StatusCode.Should().Be(expectedCode);
        }
    }
}
