﻿namespace KnockKnockApi.Library
{
    public class Fibonacci
    {
        public static long Calculate(long n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            if (n < 0) return -Calculate(-n);

            return Calculate(n - 1) + Calculate(n - 2);
        }
    }
}
