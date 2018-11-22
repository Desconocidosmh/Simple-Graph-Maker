using SFML.Graphics;
using Graph.Window;

namespace Graph.Drawables
{
    public interface IElement : Drawable
    {
        GraphWindow ParentWindow { get; set; }
    }
}
