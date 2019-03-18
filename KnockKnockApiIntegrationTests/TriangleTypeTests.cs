using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Threading.Tasks;

namespace KnockKnockApiIntegrationTests
{
    public class TriangleTypeTests : IClassFixture<WebApplicationFactory<KnockKnockApi.Startup>>
    {
        private readonly WebApplicationFactory<KnockKnockApi.Startup> _factory;

        public TriangleTypeTests(WebApplicationFactory<KnockKnockApi.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/TriangleType?a=1&b=2&c=3")]
        [InlineData("/api/TriangleType?a=2147483647&b=2147483647&c=2147483647")]
        public async Task GetTriangeType(string url)
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
