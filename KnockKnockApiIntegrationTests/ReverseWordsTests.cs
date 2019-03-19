using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
        [InlineData("/api/ReverseWords?sentence=", "")]                
        [InlineData("/api/ReverseWords?sentence=%20leading%20space", " gnidael ecaps")] 
        [InlineData("/api/ReverseWords?sentence=cat", "tac")]                                         
        [InlineData("/api/ReverseWords?sentence=trailing%20space%20", "gniliart ecaps ")] 
        [InlineData("/api/ReverseWords?sentence=two%20%20spaces", "owt  secaps")]              
        [InlineData("/api/ReverseWords?sentence=%20%20S%20%20P%20%20A%20%20C%20%20E%20%20Y%20%20", "  S  P  A  C  E  Y  ")]
        [InlineData("/api/ReverseWords?sentence=%21B%21A%21N%21G%21S%21", "!S!G!N!A!B!")]                         
        [InlineData("/api/ReverseWords?sentence=%C2%BFQu%C3%A9%3F", "?éuQ¿")]      
        [InlineData("/api/ReverseWords?sentence=Bang%21", "!gnaB")]           
        [InlineData("/api/ReverseWords?sentence=Capital", "latipaC")]                          
        [InlineData("/api/ReverseWords?sentence=P%21u%40n%23c%24t%25u%5Ea%26t%2Ai%28o%29n", "n)o(i*t&a^u%t$c#n@u!P")]
        [InlineData("/api/ReverseWords?sentence=This%20is%20a%20snark:%20%E2%B8%AE", "sihT si a :krans ⸮")]              
        [InlineData("/api/ReverseWords?sentence=cat%20and%20dog", "tac dna god")]
        [InlineData("/api/ReverseWords?sentence=detartrated%20kayak%20detartrated", "detartrated kayak detartrated")]
        public async Task GetReversedWords(string url, string expectedResult)
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
    }
}
