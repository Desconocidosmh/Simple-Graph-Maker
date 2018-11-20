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
            var squareFunction = new SquareWindow(800, 800, "Square", Color.White, Color.Black, 10, 1f, 0, 0);

            squareFunction.Refresh();

            while (true)
            {
                squareFunction.Refresh();

                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("A:{0:0.00} B:{1:0.00} C:{2:0.00}",
                    squareFunction.Function.A, squareFunction.Function.B, squareFunction.Function.C);
                Console.WriteLine("Delta:{0:0.00}", squareFunction.Function.Delta);

                squareFunction.CoordinateSystem.Scale -= 1;
                squareFunction.CoordinateSystem.Spacing = 0.1f;

                System.Threading.Thread.Sleep(400);

            }
        }
    }
}