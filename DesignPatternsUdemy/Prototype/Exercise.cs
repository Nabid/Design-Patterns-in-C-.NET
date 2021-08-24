using System;
namespace DesignPatternsUdemy.Prototype
{
    public class Exercise
    {
        interface IDeepCopyable<T>
        {
            T DeepCopy();
        }

        public class Point : IDeepCopyable<Point>
        {
            public int X, Y;

            public Point()
            {

            }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Point DeepCopy()
            {
                return (Point)MemberwiseClone();
            }
        }

        public class Line : IDeepCopyable<Line>
        {
            public Point Start, End;

            public Line()
            {

            }

            public Line(Point start, Point end)
            {
                this.Start = start;
                this.End = end;
            }

            public Line DeepCopy()
            {
                return new Line(Start.DeepCopy(), End.DeepCopy());
            }
        }

        public static void Demo()
        {
            var line = new Line
            {
                Start = new Point(2, 3),
                End = new Point(5, 7)
            };

            var line2 = line.DeepCopy();
        }
    }
}
