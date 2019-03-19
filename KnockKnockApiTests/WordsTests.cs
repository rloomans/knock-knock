using Xunit;
using FluentAssertions;
using KnockKnockApi.Library;

namespace KnockKnockApiTests
{
    public class WordsTests
    {
        [Theory]
        [InlineData("foo bar", "oof rab")]
        [InlineData("foo", "oof")]
        [InlineData("foo ", "oof ")]
        [InlineData(" bar", " rab")]
        [InlineData("foo!", "!oof")]
        [InlineData("Foo", "ooF")]
        public void ReverseWords(string sentence, string expectedResult)
        {
            // Arrange
            var words = new Words(sentence);

            // Act
            var result = words.ReverseWords().ToString();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
