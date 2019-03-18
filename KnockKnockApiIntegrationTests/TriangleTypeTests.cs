using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Threading.Tasks;
using KnockKnockApi.Library;
using Newtonsoft.Json.Linq;

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
        [InlineData("/api/TriangleType?a=1&b=2&c=3", "Scalene")]
        [InlineData("/api/TriangleType?a=4&b=4&c=2", "Isosceles")]
        [InlineData("/api/TriangleType?a=2147483647&b=2147483647&c=2147483647", "Equilateral")]
        public async Task GetTriangeType(string url, string expected_result)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            response.Content.Headers.ContentType.MediaType.Should().Be("application/json");
            response.Content.Headers.ContentType.CharSet.Should().Be("utf-8");
            JToken.Parse(content).Value<string>().Should().Be(expected_result);
        }
    }
}
