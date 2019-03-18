﻿using System;
using System.Collections.Generic;

namespace KnockKnockApi.Library
{
    /// <summary>
    /// Class to calculate Fibonacci numbers.
    /// </summary>
    public class Fibonacci
    {
        private static Dictionary<long, long> _cache = new Dictionary<long, long>();

        /// <summary>
        /// Return the n'th number in the Fibonacci sequence.
        /// </summary>
        /// <param name="n">The index (n) of the fibonacci sequence.</param>
        /// <returns>long</returns>
        public static long Calculate(long n)
        {
            if (n <= -93 || n >= 93) {
                throw new System.ArgumentOutOfRangeException(nameof(n), "Index out of range");
            }

            if (n == 0) return 0;
            if (n == 1) return 1;

            if (n < 0) return (-1 * Calculate(-1 * n));

            long result;

            if (_cache.TryGetValue(n, out result))
                return result;

            result = Calculate(n - 1) + Calculate(n - 2);
            _cache.Add(n, result);
            return result;
        }
    }
}
