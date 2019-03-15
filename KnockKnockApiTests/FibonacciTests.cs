using System;
using Xunit;
using FluentAssertions;
using KnockKnockApi.Library;

namespace KnockKnockApiTests
{
    public class FibonacciTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(10, 55)]
        public void CheckFibonacci(long n, long expected_result)
        {
            // Act
            var result = Fibonacci.Calculate(n);

            // Assert
            result.Should().Be(expected_result);
        }
    }
}
