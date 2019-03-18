using Xunit;
using FluentAssertions;
using KnockKnockApi.Library;

namespace KnockKnockApiTests
{
    public class TriangleTypeTests
    {
        [Theory]
        [InlineData(4, 4, 4, Triangle.TriangleTypes.Equilateral)]
        [InlineData(4, 4, 5, Triangle.TriangleTypes.Isosceles)]
        [InlineData(3, 4, 5, Triangle.TriangleTypes.Scalene)]
        public void CheckTriangleType(int a, int b, int c, Triangle.TriangleTypes expected_result)
        {
            // Arrange
            var triangle = new Triangle(a, b, c);

            // Act
            var result = triangle.Characterise();

            // Assert
            result.Should().Be(expected_result);
        }
    }
}
