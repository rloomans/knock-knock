using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Http;
using FluentAssertions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace KnockKnockApiIntegrationTests
{
    public class FibonacciTests : IClassFixture<WebApplicationFactory<KnockKnockApi.Startup>>
    {
        private readonly WebApplicationFactory<KnockKnockApi.Startup> _factory;

        public FibonacciTests(WebApplicationFactory<KnockKnockApi.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Fibonacci?n=0", 0)]
        [InlineData("/api/Fibonacci?n=1", 1)]
        [InlineData("/api/Fibonacci?n=2", 1)]
        [InlineData("/api/Fibonacci?n=3", 2)]
        [InlineData("/api/Fibonacci?n=-1", -1)]
        [InlineData("/api/Fibonacci?n=-2", -1)]
        [InlineData("/api/Fibonacci?n=-3", -2)]
        public async Task GetFibonacci(string url, long expected_result)
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
            JToken.Parse(content).Value<long>().Should().Be(expected_result);
        }

        [Theory]
        [InlineData("/api/Fibonacci?n=93")]
        [InlineData("/api/Fibonacci?n=100")]
        [InlineData("/api/Fibonacci?n=-93")]
        public async Task GetFibonacci_BadRequest(string url)
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
