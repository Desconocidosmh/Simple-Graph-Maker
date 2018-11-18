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
            var vectorWindow = new VectorWindow(800, 800, "Vector", Color.White, Color.Black, 30, new Vector2f(10, 10));

            vectorWindow.Refresh();

            while (true)
            {
                vectorWindow.Refresh();

                vectorWindow.CoordinateSystem.Color = Color.Red;

                vectorWindow.CoordinateSystem.Scale -= 1;

                System.Threading.Thread.Sleep(750);


            }
        }
    }
}