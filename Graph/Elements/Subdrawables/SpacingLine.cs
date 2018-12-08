using SFML.Graphics;
using SFML.System;
using Graph.Window;

namespace Graph.Elements.Subdrawables
{
    public enum Orientation { Horizontal, Vertical }

    public class SpacingLine : Drawable
    {
        private const uint DEFAULT_FONT_SIZE = 20;

        /// <summary>
        /// The window where this spacing line will be displayed
        /// </summary>
        public GraphWindow ParentWindow { get; }

        /// <summary>
        /// Position of this spacing line in space
        /// </summary>
        public Vector2f Position { get; }

        /// <summary>
        /// Size of this spacing line
        /// </summary>
        public float Size { get; set; }

        /// <summary>
        /// Size of the number's font
        /// </summary>
        public uint FontSize { get; set; }

        /// <summary>
        /// Font of the numbers
        /// </summary>
        public Font Font { get; set; }

        /// <summary>
        /// Color of this SpacingLine
        /// </summary>
        public Color Color
        {
            get => ParentWindow.CoordinateSystem.Color;
            set => ParentWindow.CoordinateSystem.Color = value;
        }

        private Orientation Orientation { get; }

        public SpacingLine(GraphWindow parentWindow, Vector2f position, float size, Orientation orientation, Font font)
        {
            ParentWindow = parentWindow;
            Position = position;
            Size = size;
            Orientation = orientation;
            FontSize = DEFAULT_FONT_SIZE;
            Font = font;
        }

        // TODO: Make this function independedt from ToWindowCoords method, so it doesn't have to be public
        public void Draw(RenderTarget target, RenderStates states)
        {
            Vector2f start;
            Vector2f end;
            Text text;

            if (Orientation == Orientation.Vertical)
            {
                start = ParentWindow.ToWindowCoords(Position) - new Vector2f(0, Size);
                end = ParentWindow.ToWindowCoords(Position) + new Vector2f(0, Size);
                text = new Text(Position.X.ToString("0.0"), Font, DEFAULT_FONT_SIZE)
                {
                    Position = ParentWindow.ToWindowCoords(Position) + new Vector2f(-1.5f, 1.5f)
                };
            }
            else
            {
                start = ParentWindow.ToWindowCoords(Position) - new Vector2f(Size, 0);
                end = ParentWindow.ToWindowCoords(Position) + new Vector2f(Size, 0);
                text = new Text(Position.Y.ToString("0.0"), Font, DEFAULT_FONT_SIZE)
                {
                    Position = ParentWindow.ToWindowCoords(Position) + new Vector2f(-6f, 0)
                };
            }

            target.Draw(new Vertex[]
            {
                    new Vertex(start, Color),
                    new Vertex(end, Color)
            }, PrimitiveType.Lines);

            text.Origin = new Vector2f(text.GetLocalBounds().Left / 2, text.GetLocalBounds().Height / 2);
            text.Color = Color;
            text.Scale = new Vector2f(0.15f, 0.15f);

            target.Draw(text);
            text.Dispose();
        }
    }
}