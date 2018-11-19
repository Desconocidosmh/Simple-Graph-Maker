using SFML.Graphics;
using SFML.System;
using Graph.Window;

namespace Graph.Drawables.Subdrawables
{
    public enum Orientation { Vertical, Horizontal }

    public class SpacingLine : Drawable
    {
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
        /// Color of this SpacingLine
        /// </summary>
        public Color Color { get; }

        #endregion

        #region Constructors

        public SpacingLine(GraphWindow parentWindow, Vector2f position, float size, Orientation orientation)
        {
            ParentWindow = parentWindow;
            Position = position;
            Size = size;
            Orientation = orientation;
            Color = ParentWindow.CoordinateSystem.Color;
        }

        #endregion

        #region Methods

        public void Draw(RenderTarget target, RenderStates states)
        {
            Vector2f start;
            Vector2f end;

            if (Orientation == Orientation.Horizontal)
            {
                start = new Vector2f(Position.X, Position.Y - Size / 2);
                end = new Vector2f(Position.X, Position.Y + Size / 2);
                
            }
            else
            {
                start = new Vector2f(Position.X - Size / 2, Position.Y);
                end = new Vector2f(Position.X + Size / 2, Position.Y);
            }

            target.Draw(new Vertex[]
            {
                    new Vertex(ParentWindow.ToWindowCoords(start), Color),
                    new Vertex(ParentWindow.ToWindowCoords(end), Color)
            }, PrimitiveType.Lines);

        }

        #endregion
    }
}
