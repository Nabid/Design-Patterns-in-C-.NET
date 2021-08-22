using System;
namespace DesignPatternsUdemy.Factory
{
    /// <summary>
    /// Factory method
    /// </summary>
    public class Point
    {
        private double x, y;
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        // inner factory
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }

        // factory property
        public static Point Origin => new Point(0, 0);
    }

    public static class FactoryDemo
    {
        public static void FactoryMethod()
        {
            var point = Point.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);

            var point2 = Point.Factory.NewCartesianPoint(2.4, 5.2);
            Console.WriteLine(point2);

            var point3 = Point.Origin;
            Console.WriteLine(point3);

        }
    }
}
