using System;

namespace KnockKnockApi.Library
{
    /// <summary>
    /// Class for representing triangles.
    /// </summary>
    public class Triangle
    {
        /// <summary>
        /// The different type of triangles
        /// </summary>
        public enum TriangleTypes {
            Error=0, Scalene, Isosceles, Equilateral
        }

        /// <summary>
        /// Length of side a.
        /// </summary>
        public int A;
        /// <summary>
        /// Length of side b.
        /// </summary>
        public int B;
        /// <summary>
        /// Length of side c.
        /// </summary>
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

        /// <summary>
        /// Determines the type of triangle.
        /// </summary>
        /// <returns>TriangleTypes</returns>
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
