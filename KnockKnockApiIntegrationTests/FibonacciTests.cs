using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Threading.Tasks;

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
        [InlineData("/api/Fibonacci?n=0")]
        [InlineData("/api/Fibonacci?n=1")]
        [InlineData("/api/Fibonacci?n=2")]
        [InlineData("/api/Fibonacci?n=100")]
        [InlineData("/api/Fibonacci?n=-1")]
        [InlineData("/api/Fibonacci?n=-2")]
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
