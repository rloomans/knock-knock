using System;
using System.Collections.Generic;

namespace KnockKnockApi.Library
{
    /// <summary>
    ///     Class to calculate Fibonacci numbers.
    /// </summary>
    public static class Fibonacci
    {
        private const long IndexLimit = 92;

        private static readonly Dictionary<long, long> Cache = new Dictionary<long, long>();

        /// <summary>
        ///     Return the nth number in the Fibonacci sequence.
        /// </summary>
        /// <param name="n">The index (n) of the fibonacci sequence.</param>
        /// <returns>long</returns>
        public static long Calculate(long n)
        {
            if (n < -IndexLimit || n > IndexLimit) throw new ArgumentOutOfRangeException(nameof(n), "Index out of range");

            if (n == 0)
                return 0;

            if (n == 1 || n == 2)
                return 1;

            if (n < 0) return (n % 2 == 0 ? -1 : 1) * Calculate(-1 * n);

            long result;

            if (Cache.TryGetValue(n, out result))
                return result;

            result = Calculate(n - 1) + Calculate(n - 2);
            Cache.Add(n, result);
            return result;
        }
    }
}