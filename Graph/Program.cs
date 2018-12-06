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

            var func = new Hyperbole(1);

            window.AddElement(func);

            window.Refresh();

            System.Console.ReadKey();
        }
    }
}