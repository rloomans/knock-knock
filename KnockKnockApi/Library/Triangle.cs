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

        /// <summary>
        /// Determines the type of triangle.
        /// </summary>
        /// <returns>TriangleTypes</returns>
        public TriangleTypes Characterise()
        {
            if (A <= 0 || B <= 0 || C <= 0)
                return TriangleTypes.Error;
            
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
