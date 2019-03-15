using System.Collections.Generic;

namespace KnockKnockApi.Library
{
    public class Fibonacci
    {
        private static Dictionary<long, long> _cache = new Dictionary<long, long>();

        public static long Calculate(long n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            if (n < 0) return (-1 * Calculate(-n));

            long result;

            if (_cache.TryGetValue(n, out result))
                return result;

            result = Calculate(n - 1) + Calculate(n - 2);
            _cache.Add(n, result);
            return result;
        }
    }
}
