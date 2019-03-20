using System.Threading.Tasks;
using FluentAssertions;
using KnockKnockApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Xunit;

namespace KnockKnockApiIntegrationTests
{
    public class FibonacciTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public FibonacciTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Fibonacci?n=0", 0)]
        [InlineData("/api/Fibonacci?n=1", 1)]
        [InlineData("/api/Fibonacci?n=2", 1)]
        [InlineData("/api/Fibonacci?n=3", 2)]
        [InlineData("/api/Fibonacci?n=4", 3)]
        [InlineData("/api/Fibonacci?n=5", 5)]
        [InlineData("/api/Fibonacci?n=6", 8)]
        [InlineData("/api/Fibonacci?n=7", 13)]
        [InlineData("/api/Fibonacci?n=46", 1836311903)]
        [InlineData("/api/Fibonacci?n=47", 2971215073)]
        [InlineData("/api/Fibonacci?n=92", 7540113804746346429)]
        [InlineData("/api/Fibonacci?n=-1", 1)]
        [InlineData("/api/Fibonacci?n=-2", -1)]
        [InlineData("/api/Fibonacci?n=-3", 2)]
        [InlineData("/api/Fibonacci?n=-4", -3)]
        [InlineData("/api/Fibonacci?n=-5", 5)]
        [InlineData("/api/Fibonacci?n=-6", -8)]
        [InlineData("/api/Fibonacci?n=-7", 13)]
        [InlineData("/api/Fibonacci?n=-46", -1836311903)]
        [InlineData("/api/Fibonacci?n=-47", 2971215073)]
        [InlineData("/api/Fibonacci?n=-92", -7540113804746346429)]
        public async Task GetFibonacci(string url, long expectedResult)
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
            JToken.Parse(content).Value<long>().Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("/api/Fibonacci?n=2147483647")]
        [InlineData("/api/Fibonacci?n=9223372036854775807")]
        [InlineData("/api/Fibonacci?n=-93")]
        [InlineData("/api/Fibonacci?n=-2147483648")]
        [InlineData("/api/Fibonacci?n=-9223372036854775808")]
        public async Task GetFibonacci_BadRequest(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
            response.Content.Headers.ContentType.MediaType.Should().Be("application/json");
            response.Content.Headers.ContentType.CharSet.Should().Be("utf-8");
        }
    }
}