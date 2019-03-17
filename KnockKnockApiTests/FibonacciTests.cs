using Xunit;
using FluentAssertions;
using KnockKnockApi.Library;
using System;

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
        [InlineData(46, 1836311903)]
        [InlineData(47, 2971215073)]
        [InlineData(80, 23416728348467685)]
        [InlineData(92, 7540113804746346429)]
        [InlineData(-1, -1)]
        [InlineData(-2, -1)]
        [InlineData(-3, -2)]
        [InlineData(-10, -55)]
        [InlineData(-46, -1836311903)]
        [InlineData(-47, -2971215073)]
        [InlineData(-92, -7540113804746346429)]
        public void CheckFibonacci(long n, long expected_result)
        {
            // Act
            var result = Fibonacci.Calculate(n);

            // Assert
            result.Should().Be(expected_result);
        }

        [Theory]
        [InlineData(-9223372036854775808)]
        [InlineData(9223372036854775807)]
        public void CheckFibonacciThrows(long n)
        {
            // Act
            Action action = () => Fibonacci.Calculate(n);

            // Assert
            action.Should().Throw<ArgumentException>();
        }
    }
}
