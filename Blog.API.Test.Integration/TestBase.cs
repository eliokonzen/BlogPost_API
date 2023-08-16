using Microsoft.AspNetCore.Mvc.Testing;

namespace Blog.Api.Test.Integration
{
    public abstract class TestBase
    {
        protected HttpClient TestClient { get; }

        public TestBase()
        {
            var wepAppFactory = new WebApplicationFactory<Program>();
            TestClient = wepAppFactory.CreateClient();
        }
    }
}
