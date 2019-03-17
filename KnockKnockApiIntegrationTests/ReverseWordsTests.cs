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
        [InlineData("/api/ReverseWords?sentence=")]
        [InlineData("/api/ReverseWords?sentence=foo+bar")]
        [InlineData("/api/ReverseWords?sentence=This%20is%20a%20snark:%20%E2%B8%AE")]
        [InlineData("/api/ReverseWords?sentence=cat")]
        [InlineData("/api/ReverseWords?sentence=two%20%20spaces")]
        [InlineData("/api/ReverseWords?sentence=%20leading%20space")]
        [InlineData("/api/ReverseWords?sentence=trailing%20space%20")]
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
