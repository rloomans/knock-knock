using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using FluentAssertions.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;

namespace KnockKnockApiIntegrationTests
{
    public class TokenTests : IClassFixture<WebApplicationFactory<KnockKnockApi.Startup>>
    {
        private readonly WebApplicationFactory<KnockKnockApi.Startup> _factory;

        public TokenTests(WebApplicationFactory<KnockKnockApi.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/token")]
        public async Task GetToken(string url)
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
            new Guid(JToken.Parse(content).Value<string>()).Should().Be(KnockKnockApi.Controllers.TokenController.TOKEN);
        }
    }
}
