﻿using System;

namespace KnockKnockApi.Library
{
    public class Triangle
    {
        public enum TriangleTypes {
            Error=0, Scalene, Isosceles, Equilateral
        }

        public int A;
        public int B;
        public int C;

        public Triangle(int a, int b, int c)
        {
            if (a < 1) throw new ArgumentOutOfRangeException(nameof(a), "Invalid length");
            if (b < 1) throw new ArgumentOutOfRangeException(nameof(b), "Invalid length");
            if (c < 1) throw new ArgumentOutOfRangeException(nameof(c), "Invalid length");

            A = a;
            B = b;
            C = c;
        }

        public TriangleTypes Characterise()
        {
            if (A == B && B == C)
            {
                return TriangleTypes.Equilateral;
            }
            else if (A == B || B == C || C == A)
            {
                return TriangleTypes.Isosceles;
            }

            return TriangleTypes.Scalene;
        }
    }
}
