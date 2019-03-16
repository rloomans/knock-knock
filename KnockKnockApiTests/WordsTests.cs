using Xunit;
using FluentAssertions;
using KnockKnockApi.Library;

namespace KnockKnockApiTests
{
    public class WordsTests
    {
        [Theory]
        [InlineData("foo bar", "oof rab")]
        public void ReverseWords(string sentence, string expected_result)
        {
            // Arrange
            var words = new Words(sentence);

            // Act
            var result = words.ReverseWords().ToString();

            // Assert
            result.Should().Be(expected_result);
        }
    }
}
