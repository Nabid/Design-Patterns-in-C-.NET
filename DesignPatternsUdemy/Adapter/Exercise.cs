using System;
using NUnit.Framework;

namespace DesignPatternsUdemy.Adapter
{
    public class Exercise
    {
        public Exercise()
        {
        }
    }

    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private int _w;
        private int _h;
        public SquareToRectangleAdapter(Square square)
        {
            _w = square.Side;
            _h = square.Side;
        }

        public int Width => _w;
        public int Height => _h;
    }

    [TestFixture]
    public class TestAdapter
    {
        [Test]
        public void Test()
        {
            var square = new Square{ Side = 7};
            var adapter = new SquareToRectangleAdapter(square);
            Assert.That(adapter.Area(), Is.EqualTo(square.Side * square.Side));
        }
    }
}
