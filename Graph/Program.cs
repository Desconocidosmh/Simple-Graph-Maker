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
            var vectorWindow = new VectorWindow(800, 800, "Vector", Color.White, Color.Black, 30, new Vector2f(0, 0));

            vectorWindow.Refresh();


            while (true)
            {
                vectorWindow.MainVector = new Vector(Generator.GetRandomVector(-10, 10), Color.Black);

                vectorWindow.Refresh();

                System.Threading.Thread.Sleep(750);

                vectorWindow.Scale -= 2;
            }
        }
    }
}