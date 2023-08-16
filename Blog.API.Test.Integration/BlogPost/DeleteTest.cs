using Blog.API.DTOs;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Api.Test.Integration.BlogPost
{
    public class DeleteTest : TestBase
    {
        [Fact]
        public async Task DeleteBlogPost_ShouldReturnError_WithInvalidId()
        {
            // Arrange
            const HttpStatusCode expectedCode = HttpStatusCode.NotFound;
            int idBlogPost = 100;

            // Act
            var response = await TestClient.DeleteAsync($"/blogpost/{idBlogPost}");

            // Assert
            response.StatusCode.Should().Be(expectedCode);
        }
    }
}
