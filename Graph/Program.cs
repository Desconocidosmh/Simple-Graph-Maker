using System;
using System.Threading;
using SFML.Graphics;
using Graph.Window;
using Graph.Drawables;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var window = new GraphWindow(1000, 1000, "Window", new Color(252, 251, 237), Color.Black, 10);

            var hyper = new Hyperbole(1)
            {
                Color = Color.Red
            };

            var sine = new SineWave(3, 10)
            {
                Color = Color.Blue
            };

            window.AddElement(hyper);
            window.AddElement(sine);

            window.Refresh();

            while (true)
            {
                sine.Density -= 0.01f;
                Thread.Sleep(15);
                window.Refresh();
            }

           Console.ReadKey();
        }
    }
}