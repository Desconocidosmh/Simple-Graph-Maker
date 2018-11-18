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
            var cubicWindow = new CubicWindow(800, 800, "Cubic", Color.White, Color.Black, 30, 0.5f, -2, 6);

            cubicWindow.Refresh();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("A:{0:0.00} B:{1:0.00} C:{2:0.00}",
                    cubicWindow.Function.A, cubicWindow.Function.B, cubicWindow.Function.C);
                Console.WriteLine("Delta:{0:0.00}", cubicWindow.Function.Delta);

                Console.WriteLine(cubicWindow.Function.Calculate(1));

                Console.WriteLine(cubicWindow.Function.Calculate(1));

                cubicWindow.Function.B += 0.01f;

                cubicWindow.Refresh();
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}