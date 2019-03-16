using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Threading.Tasks;

namespace KnockKnockApiIntegrationTests
{
    public class ReverseWordsTests : IClassFixture<WebApplicationFactory<KnockKnockApi.Startup>>
    {
        private readonly WebApplicationFactory<KnockKnockApi.Startup> _factory;

        public ReverseWordsTests(WebApplicationFactory<KnockKnockApi.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/ReverseWords?query=foo+bar")]
        public async Task GetToken(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }
    }
}
