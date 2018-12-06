using SFML.Graphics;
using Graph.Window;

namespace Graph.System
{
    public interface IDrawable
    {
        Vertex[] GetVertices(GraphWindow window);
    }
}
