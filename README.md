# Simple Graph Maker [![CodeFactor](https://www.codefactor.io/repository/github/desconocidosmh/simple-graph-maker/badge)](https://www.codefactor.io/repository/github/desconocidosmh/simple-graph-maker)

*Simple Graph Maker* is a SFML Framework and a tool which lets you easily create your own visualization of mathematical functions. Its goal is
simple - help people who struggle with basic math to visualize and play with it so they can get better understanding of what's 
happening and why it's so cool and not that hard after all.

<a href="https://imgur.com/PDSch0q"><img src="https://i.imgur.com/PDSch0q.gif" title="source: imgur.com" /></a>

# Creating a simple program

```csharp
using System;
using SFML.Graphics;
using Graph.Window;
using Graph.Elements;

class Program
{
    static void Main(string[] args)
    {
        var window = new GraphWindow(1000, 1000, "Window", new Color(252, 251, 237), Color.Black, 10);
        var func = new SquareFunction(1, 0, -1);

        window.AddElement(func);
        window.Refresh();

        Console.ReadKey(); // Just so we won't exit program immediately
    }

}
```

Such a program is going to display square function with following parameters: A=1, B=0, C=(-1)

The routine is very simple:
1. Create a window
2. Create elements
3. Add elements to the window
4. Refresh window so it displays it's elements

You can always add, remove or modify elements, just remember that you need to ```.Refresh()``` your window in order to display changes.

# Contributing and Developing

All sorts of contribution are HIGHLY welcome! Whether you report an issue, commit your code or give good advice. Don't feel discouraged
to contribute even if you think your change is small. Every little character is a tone of help and huge courage boost for me!
