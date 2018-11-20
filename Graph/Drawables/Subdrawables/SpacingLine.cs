using SFML.Graphics;
using SFML.System;
using Graph.Window;

namespace Graph.Drawables.Subdrawables
{
    public enum Orientation { Vertical, Horizontal }

    public class SpacingLine : Drawable
    {
        private const uint DEFAULT_FONT_SIZE = 20;

        #region Properties

        /// <summary>
        /// The window where this spacing line will be displayed
        /// </summary>
        public GraphWindow ParentWindow { get; }

        /// <summary>
        /// Position of this spacing line in space
        /// </summary>
        public Vector2f Position { get; }

        /// <summary>
        /// Rotation of this spacing line in degrees
        /// </summary>
        public Orientation Orientation { get; }

        /// <summary>
        /// Size of this spacing line
        /// </summary>
        public float Size { get; }

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
        public Color Color { get; }

        #endregion

        #region Constructors

        public SpacingLine(GraphWindow parentWindow, Vector2f position, float size, Orientation orientation, Font font)
        {
            ParentWindow = parentWindow;
            Position = position;
            Size = size;
            Orientation = orientation;
            FontSize = DEFAULT_FONT_SIZE;
            Font = font;
            Color = ParentWindow.CoordinateSystem.Color;
        }

        #endregion

        #region Methods

        public void Draw(RenderTarget target, RenderStates states)
        {
            Vector2f start;
            Vector2f end;
            Vector2f textPosition;
            Text text;

            if (Orientation == Orientation.Horizontal)
            {
                start = new Vector2f(Position.X, Position.Y - Size / 2);
                end = new Vector2f(Position.X, Position.Y + Size / 2);
                textPosition = new Vector2f(Position.X, Position.Y + 0.25f);
                text = new Text(Position.X.ToString("0.0"), Font, DEFAULT_FONT_SIZE);
            }
            else
            {
                start = new Vector2f(Position.X - Size / 2, Position.Y);
                end = new Vector2f(Position.X + Size / 2, Position.Y);
                textPosition = new Vector2f(Position.X + 0.25f, Position.Y);
                text = new Text((-Position.Y).ToString("0.0"), Font, DEFAULT_FONT_SIZE);
            }

            float scale = (ParentWindow.CoordinateSystem.Spacing / ParentWindow.CoordinateSystem.Scale) * 1.5f; // It's temporary solution until I find a better one 

            text.Position = ParentWindow.ToWindowCoords(textPosition);
            text.Color = Color;
            text.Scale = new Vector2f(scale, scale);

            target.Draw(new Vertex[]
            {
                    new Vertex(ParentWindow.ToWindowCoords(start), Color),
                    new Vertex(ParentWindow.ToWindowCoords(end), Color)
            }, PrimitiveType.Lines);

            target.Draw(text);
        }

        #endregion
    }
}
