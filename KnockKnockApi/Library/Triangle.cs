namespace KnockKnockApi.Library
{
    public class Triangle
    {
        public int a;
        public int b;
        public int c;

        public Triangle(int a1, int b1, int c1)
        {
            a = a1;
            b = b1;
            c = c1;
        }

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
