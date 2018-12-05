using System;
using SFML.Graphics;
using SFML.System;
using Graph.Drawables.Subdrawables;

namespace Graph.Drawables
{
    /// <summary>
    /// Resebles Vector, which can be drawn and used for calculations
    /// </summary>
    public class Vector : Element, Drawable
    {
        #region Properties

        public event EventHandler OnChange = delegate { };

        /// <summary>
        /// Position of the Vector in space
        /// </summary>
        public Vector2f Position
        {
            get => position;
            set
            {
                if (position != value)
                {
                    position = value;
                    OnChange(this, EventArgs.Empty);
                }
            }
        }
        private Vector2f position;

        /// <summary>
        /// Size of the vector's arrow 
        /// </summary>
        public float ArrowSize
        {
            get => arrowSize;
            set
            {
                if (arrowSize != value)
                {
                    arrowSize = value;
                    OnChange(this, EventArgs.Empty);
                }
            }
        }
        private float arrowSize;

        /// <summary>
        /// Color of the vector
        /// </summary>
        public override Color Color
        {
            get => color;
            protected set
            {
                if (color != value)
                {
                    color = value;
                    OnChange(this, EventArgs.Empty);
                }
            }
        }
        private Color color;

        private readonly Arrow Arrow;

        #endregion

        #region Constructors

        public Vector(Vector2f position) : this(position, Color.Black) { }
        public Vector(Vector2f position, Color color)
        {
            this.position = position;
            Color = color;
            ArrowSize = 1;
            Arrow = new Arrow(this);
            Color = color;
        }
        public Vector(float x, float y) : this(new Vector2f(x, y)) { }
        public Vector(float x, float y, Color color) : this(new Vector2f(x, y), color) { }

        #endregion

        #region Methods

        private void DrawVectorsLine(RenderTarget target)
        {
            target.Draw(new Vertex[]
            {
                new Vertex(new Vector2f(), Color),
                new Vertex(GetParentWindow().ToWindowCoords(new Vector2f(Position.X, Position.Y)), Color)
            }, PrimitiveType.LinesStrip);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            // Draw a line from Vector 0 to this Vector
            DrawVectorsLine(target);

            target.Draw(Arrow);
        }

        public static implicit operator Vector2f(Vector v) => v.Position;

        #endregion
    }
}