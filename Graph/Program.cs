using System;
using System.Threading;
using SFML.Graphics;
using Graph.Window;
using Graph.Elements;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            float y = 0;
            float x = 9 / y;

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
                Thread.Sleep(14);
                window.Refresh();
            }

           Console.ReadKey();
        }
    }
}