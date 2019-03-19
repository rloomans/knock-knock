namespace KnockKnockApi.Library
{
    /// <summary>
    ///     Class for representing triangles.
    /// </summary>
    public class Triangle
    {
        /// <summary>
        ///     The different types of triangles
        /// </summary>
#pragma warning disable CS1591
        public enum TriangleTypes
        {
            Error = 0,
            Scalene,
            Isosceles,
            Equilateral
        }
#pragma warning restore CS1591

        /// <summary>
        ///     Length of side a.
        /// </summary>
        public int A;

        /// <summary>
        ///     Length of side b.
        /// </summary>
        public int B;

        /// <summary>
        ///     Length of side c.
        /// </summary>
        public int C;

        /// <summary>
        ///     Determines the type of triangle.
        /// </summary>
        /// <returns>TriangleTypes</returns>
        public TriangleTypes Characterise()
        {
            // Can't have negative length
            if (A <= 0 || B <= 0 || C <= 0)
                return TriangleTypes.Error;

            // If sum of two sides is equal to the third, then you really have a line
            // if the sum is less than the third, you can't even theoretically join up the polygon
            if ((long)A + B <= C || (long)B + C <= A || (long)C + A <= B)
                return TriangleTypes.Error;

            if (A == B && B == C)
                return TriangleTypes.Equilateral;

            if (A == B || B == C || C == A)
                return TriangleTypes.Isosceles;

            return TriangleTypes.Scalene;
        }
    }
}