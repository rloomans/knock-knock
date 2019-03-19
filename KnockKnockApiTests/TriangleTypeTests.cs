using FluentAssertions;
using KnockKnockApi.Library;
using Xunit;

namespace KnockKnockApiTests
{
    public class TriangleTypeTests
    {
        [Theory]
        [InlineData(4, 4, 4, Triangle.TriangleTypes.Equilateral)]
        [InlineData(4, 4, 5, Triangle.TriangleTypes.Isosceles)]
        [InlineData(3, 4, 5, Triangle.TriangleTypes.Scalene)]
        [InlineData(2147483647, 2147483647, 2147483647, Triangle.TriangleTypes.Equilateral)]
        [InlineData(3, 0, 5, Triangle.TriangleTypes.Error)]
        [InlineData(3, 4, -1, Triangle.TriangleTypes.Error)]
        [InlineData(3, 1, 1, Triangle.TriangleTypes.Error)]
        [InlineData(1, 3, 1, Triangle.TriangleTypes.Error)]
        [InlineData(1, 1, 3, Triangle.TriangleTypes.Error)]
        public void CheckTriangleType(int a, int b, int c, Triangle.TriangleTypes expected_result)
        {
            // Arrange
            var triangle = new Triangle {A = a, B = b, C = c};

            // Act
            var result = triangle.Characterise();

            // Assert
            result.Should().Be(expected_result);
        }
    }
}