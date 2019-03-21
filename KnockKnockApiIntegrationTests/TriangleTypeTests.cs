using System.Threading.Tasks;
using FluentAssertions;
using KnockKnockApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Xunit;

namespace KnockKnockApiIntegrationTests
{
    public class TriangleTypeTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TriangleTypeTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/TriangleType?a=-1&b=-1&c=-1", "Error")]
        [InlineData("/api/TriangleType?a=-1&b=1&c=1", "Error")]
        [InlineData("/api/TriangleType?a=-2147483648&b=-2147483648&c=-2147483648", "Error")]
        [InlineData("/api/TriangleType?a=0&b=0&c=0", "Error")]
        [InlineData("/api/TriangleType?a=0&b=1&c=1", "Error")]
        [InlineData("/api/TriangleType?a=1&b=-1&c=1", "Error")]
        [InlineData("/api/TriangleType?a=1&b=0&c=1", "Error")]
        [InlineData("/api/TriangleType?a=1&b=1&c=-1", "Error")]
        [InlineData("/api/TriangleType?a=1&b=1&c=0", "Error")]
        [InlineData("/api/TriangleType?a=1&b=1&c=2", "Error")]
        [InlineData("/api/TriangleType?a=1&b=1&c=2147483647", "Error")]
        [InlineData("/api/TriangleType?a=1&b=2&c=1", "Error")]
        [InlineData("/api/TriangleType?a=2&b=1&c=1", "Error")]
        [InlineData("/api/TriangleType?a=1&b=2&c=3", "Error")]
        [InlineData("/api/TriangleType?a=1&b=1&c=1", "Equilateral")]
        [InlineData("/api/TriangleType?a=2&b=2&c=2", "Equilateral")]
        [InlineData("/api/TriangleType?a=2&b=2&c=3", "Isosceles")]
        [InlineData("/api/TriangleType?a=2&b=3&c=2", "Isosceles")]
        [InlineData("/api/TriangleType?a=2&b=3&c=4", "Scalene")]
        [InlineData("/api/TriangleType?a=2147483647&b=2147483647&c=2147483647", "Equilateral")]
        [InlineData("/api/TriangleType?a=3&b=2&c=2", "Isosceles")]
        [InlineData("/api/TriangleType?a=3&b=4&c=2", "Scalene")]
        [InlineData("/api/TriangleType?a=4&b=2&c=3", "Scalene")]
        [InlineData("/api/TriangleType?a=4&b=4&c=2", "Isosceles")]
        public async Task GetTriangleType(string url, string expectedResult)
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
            JToken.Parse(content).Value<string>().Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("/api/TriangleType?a=a")]
        [InlineData("/api/TriangleType?a=a&b=1&c=1")]
        [InlineData("/api/TriangleType?a=1&b=b&c=1")]
        [InlineData("/api/TriangleType?a=1&b=1&c=c")]
        [InlineData("/api/TriangleType?a=&b=1&c=1")]
        [InlineData("/api/TriangleType?a=1&b=&c=1")]
        [InlineData("/api/TriangleType?a=1&b=1&c=")]
        public async Task GetTriangleType_BadRequest(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
            response.Content.Headers.ContentType.MediaType.Should().Be("application/json");
            response.Content.Headers.ContentType.CharSet.Should().Be("utf-8");
        }
    }
}