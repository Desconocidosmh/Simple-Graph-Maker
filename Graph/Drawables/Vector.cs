using SFML.Graphics;
using SFML.System;

namespace Graph.Drawables
{
    /// <summary>
    /// Resebles Vector, which can be drawn and used for calculations
    /// </summary>
    public class Vector : Drawable
    {
        #region Properties

        private Vector2f Position;
        /// <summary>
        /// Position X of the Vector in space
        /// </summary>
        public float X { get => Position.X; }
        /// <summary>
        /// Position Y of the Vector in space
        /// </summary>
        public float Y { get => Position.Y; }

        /// <summary>
        /// Size of the vector's arrow 
        /// </summary>
        public float ArrowSize
        {
            get => Arrow.Size;
            set => Arrow.Size = value;
        }

        /// <summary>
        /// Color of the vector
        /// </summary>
        public Color Color { get; set; }

        private readonly Arrow Arrow;

        #endregion

        #region Constructors

        public Vector(Vector2f vector) : this(vector, Color.White) { }
        public Vector(Vector2f vector, Color color)
        {
            Position = vector;
            Color = color;
            Arrow = new Arrow
            {
                Position = Position,
                Size = 0.3f,
                Color = Color
            };
            Arrow.ApplyCorrectRotationForVector(this);
        }
        public Vector(float x, float y) : this(new Vector2f(x, y)) { }
        public Vector(float x, float y, Color color) : this(new Vector2f(x, y), color) { }

        #endregion

        public void Draw(RenderTarget target, RenderStates states)
        {
            // Draw a line from Vector 0 to this Vector
            DrawVector(target);

            target.Draw(Arrow);
        }

        private void DrawVector(RenderTarget target)
        {
            target.Draw(new Vertex[]
            {
                new Vertex(new Vector2f(), Color),
                new Vertex(Position, Color)
            }, PrimitiveType.LinesStrip);
        }

        public static implicit operator Vector2f(Vector v) =>
            new Vector2f(v.Position.X, v.Position.Y);
    }
}