using System;
using SFML.System;
using System.Threading;
using SFML.Graphics;
using Graph.Window;
using Graph.Elements;

class Program
{
    static void Main(string[] args)
    {
        var window = new GraphWindow(1000, 1000, "Window", new Color(252, 251, 237), Color.Black, 10);
        var hyper = new SquareFunction(1, 0, 1);

        window.AddElement(hyper);

        while (true)
        {
            window.Refresh();
            Thread.Sleep(15);
        }
    }

}