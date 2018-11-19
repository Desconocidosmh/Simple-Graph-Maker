using System;
using SFML.System;
using SFML.Graphics;
using Graph.MathUtils;
using Graph.Window;
using Graph.Drawables;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var squareFunction = new CubicWindow(800, 800, "Cubic", Color.White, Color.Black, 30, 0.5f, 0, 0);

            squareFunction.Refresh();

            while (true)
            {
                squareFunction.Refresh();

                Console.Clear();
                Console.WriteLine("A:{0:0.00} B:{1:0.00} C:{2:0.00}",
                    squareFunction.Function.A, squareFunction.Function.B, squareFunction.Function.C);
                Console.WriteLine("Delta:{0:0.00}", squareFunction.Function.Delta);

                System.Threading.Thread.Sleep(10);

            }
        }
    }
}