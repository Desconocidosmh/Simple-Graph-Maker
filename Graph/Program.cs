using System;
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
            var vectorWindow = new VectorWindow(800, 800, "Vector", Color.White, 30, Color.Black, new SFML.System.Vector2f(0, 0));

            while (true)
            {
                vectorWindow.MainVector = new Vector(Generator.GetRandomVector(-30, 30), Color.Black);

                vectorWindow.Refresh();

                System.Threading.Thread.Sleep(750);
            }
        }
    }
}