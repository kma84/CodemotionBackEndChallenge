using CodemotionBackEndChallenge.Core;
using CodemotionBackEndChallenge.Core.Interfaces;

namespace CodemotionBackEndChallenge.Problem1
{

    [Problem(ProblemName = "Do They Belong?", ProblemNumber = 1)]
    internal class Problem1 : IProblem
    {
        public string Solve(string input)
        {
            List<int> numbers = input.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToList();

            return PointsBelong(numbers[0], numbers[1], numbers[2], numbers[3], numbers[4], numbers[5], numbers[6], numbers[7], numbers[8], numbers[9]).ToString();
        }


        public static int PointsBelong(int x1, int y1, int x2, int y2, int x3, int y3, int xp, int yp, int xq, int yq)
        {
            Point pointA = new Point(x1, y1);
            Point pointB = new Point(x2, y2);
            Point pointC = new Point(x3, y3);
            Point pointP = new Point(xp, yp);
            Point pointQ = new Point(xq, yq);

            bool validTriangle = IsNonDegenerateTriangle(pointA, pointB, pointC);
            bool pBelongs = PointBelongsToTriangle(pointP, pointA, pointB, pointC);
            bool qBelongs = PointBelongsToTriangle(pointQ, pointA, pointB, pointC);

            return (validTriangle, pBelongs, qBelongs) switch
            {
                (false, _, _)       =>  0,
                (_, true, false)    =>  1,
                (_, false, true)    =>  2,
                (_, true, true)     =>  3,
                (_, false, false)   =>  4
            };
        }

        private static bool PointBelongsToTriangle(Point point, Point pointA, Point pointB, Point pointC)
        {
            //https://en.wikipedia.org/wiki/Barycentric_coordinate_system
            double denominador = ((pointB.y - pointC.y) * (pointA.x - pointC.x) + (pointC.x - pointB.x) * (pointA.y - pointC.y));
            double a = ((pointB.y - pointC.y) * (point.x - pointC.x) + (pointC.x - pointB.x) * (point.y - pointC.y)) / denominador;
            double b = ((pointC.y - pointA.y) * (point.x - pointC.x) + (pointA.x - pointC.x) * (point.y - pointC.y)) / denominador;
            double c = 1 - a - b;

            return 0 <= a && a <= 1 && 0 <= b && b <= 1 && 0 <= c && c <= 1;
        }

        private static bool IsNonDegenerateTriangle(Point pointA, Point pointB, Point pointC)
        {
            return GetDistance(pointA, pointB) + GetDistance(pointB, pointC) > GetDistance(pointA, pointC) &&
                   GetDistance(pointB, pointC) + GetDistance(pointA, pointC) > GetDistance(pointA, pointB) &&
                   GetDistance(pointA, pointB) + GetDistance(pointA, pointC) > GetDistance(pointB, pointC);
        }


        private static double GetDistance(Point pointA, Point pointB)
        {
            return Math.Sqrt(Math.Pow(pointB.x - pointA.x, 2) + Math.Pow(pointB.y - pointA.y, 2));
        }


        record Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

    }
}
