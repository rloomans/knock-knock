using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockKnockApi.Library
{
    public class Triangle
    {
        public int a;
        public int b;
        public int c;

        public string Characterise()
        {
            if (a == b && b == c)
            {
                return "Equilateral";
            }
            else if (a == b || b == c || c == a)
            {
                return "Isosceles";
            }

            return "Scalene";
        }
    }
}
