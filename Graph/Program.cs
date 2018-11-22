using System;
using System.Threading;
using SFML.System;
using SFML.Graphics;
using Graph.Window;
using Graph.Drawables;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var squareFunction = new GraphWindow(1000, 1000, "Square", Color.White, Color.Black, 10);

            var function1 = new SquareFunction(0.1f, 0, 0);
            var function2 = new SquareFunction(-0.2f, -0.5f, 3);
            var vector1 = new Vector(4, -3);

            squareFunction.AddElement("oneFunc", function1);
            squareFunction.AddElement("twoFunc", function2);
            squareFunction.AddElement("oneVector", vector1);

            squareFunction.CoordinateSystem.Color = Color.Black;

            Console.WriteLine(function1.Color);

            float radiants = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("A:{0:0.00} B:{1:0.00} C:{2:0.00}",
                    function1.A, function1.B, function1.C);
                Console.WriteLine("Delta:{0:0.00}", function1.Delta);

                radiants += 0.01f;

                float X = (float)Math.Cos(radiants) * 5;
                float Y = (float)Math.Sin(radiants) * 5;

                vector1.Position = new Vector2f(X, Y);

                squareFunction.Refresh();

                Thread.Sleep(50);
            }
        }
    }
}