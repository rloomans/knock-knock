using System;
using Xunit;
using FluentAssertions;
using KnockKnockApi.Library;

namespace KnockKnockApiTests
{
    public class TriangleTypeTests
    {
        [Theory]
        [InlineData(4, 4, 4, "Equilateral")]
        [InlineData(4, 4, 5, "Isosceles")]
        [InlineData(3, 4, 5, "Scalene")]
        public void CheckTriangleType(int a, int b, int c, string expected_result)
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
