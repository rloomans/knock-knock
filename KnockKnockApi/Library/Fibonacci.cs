using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockKnockApi.Library
{
    public class Fibonacci
    {
        public static long Calculate(long n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return Calculate(n - 1) + Calculate(n - 2);
        }
    }
}
