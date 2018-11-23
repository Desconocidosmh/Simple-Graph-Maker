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
            var window1 = new GraphWindow(1000, 1000, "One", Color.White, Color.Black, 10);
            var window2 = new GraphWindow(1000, 1000, "Two", Color.Blue, Color.Yellow, 15);

            var function1 = new SquareFunction(0.1f, 0, 0);
            var function2 = new SquareFunction(-0.2f, -0.5f, 3);
            var vector1 = new Vector(4, -3);

            window1.AddElement(function1);
            window1.AddElement(function2);
            window1.AddElement(vector1);

            window1.CoordinateSystem.Color = Color.Green;

            window2.AddElement(function1);
            window2.AddElement(function2);

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

                window1.Refresh();
                window2.Refresh();

                Thread.Sleep(50);
            }
        }
    }
}