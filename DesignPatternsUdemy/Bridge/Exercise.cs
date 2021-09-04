using System;
namespace DesignPatternsUdemy.Bridge
{
    public static class Exercise
    {
        public static void Demo()
        {
            var triangle = new Triangle(new VectorRenderer());
            Console.WriteLine(triangle);
        }
    }

    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs => "lines";
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs => "pixels";
    }

    public abstract class Shape
    {
        public IRenderer Renderer { get; set; }
        
        protected Shape(IRenderer renderer)
        {
            Renderer = renderer;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Drawing {Name} as {Renderer.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
        }
    }    
}
