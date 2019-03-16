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
        [InlineData(46, 1836311903)]
        [InlineData(47, 2971215073)]
//        [InlineData(80, 23416728348467684)]
//        [InlineData(92, 7540113804746346000)]
        [InlineData(-1, -1)]
        [InlineData(-2, -1)]
        [InlineData(-3, -2)]
        [InlineData(-10, -55)]
        [InlineData(-46, -1836311903)]
        [InlineData(-47, -2971215073)]
//        [InlineData(-92, -7540113804746346000)]
        public void CheckFibonacci(long n, long expected_result)
        {
            // Act
            var result = Fibonacci.Calculate(n);

            // Assert
            result.Should().Be(expected_result);
        }
    }
}
