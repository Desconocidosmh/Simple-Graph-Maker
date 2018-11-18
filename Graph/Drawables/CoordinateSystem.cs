using System;
using SFML.Graphics;
using SFML.System;
using Graph.Window;

namespace Graph.Drawables
{
    /// <summary>
    /// Resembles coordinate system, which can be drawn
    /// and used for all sorts of calculations that
    /// may be useful while working with coordinates 
    /// </summary>
    public class CoordinateSystem : Drawable
    {
        #region Constants

        private const int DEFAULT_SCALE = 10;

        private const uint DEFAULT_SPACING = 1;

        private static readonly Color DEFAULT_COLOR = Color.Black;

        #endregion

        #region Properties

        private readonly GraphWindow Window;

        public event EventHandler OnChange = delegate { };

        /// <summary>
        /// Scale of this CoordinateSystem
        /// </summary>
        /// <example>
        /// Scale 10 will make coordinate system with values
        /// from (-10,-10) to (10,10)
        /// </example>
        public int Scale
        {
            get => scale;
            set
            {
                if (value != scale)
                {
                    scale = value;
                    OnChange.Invoke(this, EventArgs.Empty);
                }
            }
        }
        private int scale;

        /// <summary>
        /// Size of the small lines dividing coordinate system into smaller parts
        /// </summary>
        public float SpacingLinesSize
        {
            get => spacingLinesSize;
            set
            {
                if (value != scale)
                {
                    spacingLinesSize = value;
                    OnChange.Invoke(this, EventArgs.Empty);
                }
            }
        }
        private float spacingLinesSize;

        /// <summary>
        /// Spacing of this CoordinateSystem
        /// </summary>
        public float Spacing
        {
            get => spacing;
            set
            {
                if (value != spacing)
                {
                    spacing = value;
                    OnChange.Invoke(this, EventArgs.Empty);
                }
            }
        }
        private float spacing;

        /// <summary>
        /// Color of this CoordinateSystem
        /// </summary>
        public Color Color
        {
            get => color;
            set
            {
                if (value != color)
                {
                    color = value;
                    OnChange.Invoke(this, EventArgs.Empty);
                }
            }
        }
        private Color color;

        /// <summary>
        /// Has this coordinate system changed since last redraw
        /// </summary>
        public bool RequiresRedraw { get; private set; }

        #endregion

        #region Constructors

        /// <param name="window">
        /// Window on which this coordinate system will be displayed
        /// </param>
        public CoordinateSystem(GraphWindow window) : this(window, DEFAULT_SCALE, DEFAULT_SPACING, DEFAULT_COLOR) { }
        /// <param name="window">Window on which this coordinate system will be displayed</param>
        /// <param name="scale">Initial scale</param>
        public CoordinateSystem(GraphWindow window, int scale) : this(window, scale, DEFAULT_SPACING, DEFAULT_COLOR) { }
        /// <param name="window">Window on which this coordinate system will be displayed</param>
        /// <param name="color">Initial color</param>
        public CoordinateSystem(GraphWindow window, Color color) : this(window, DEFAULT_SCALE, DEFAULT_SPACING, color) { }
        /// <param name="window">Window on which this coordinate system will be displayed</param>
        /// <param name="scale">Initial scale</param>
        /// <param name="spacing">Initial spacing</param>
        public CoordinateSystem(GraphWindow window, int scale, uint spacing) : this(window, scale, spacing, DEFAULT_COLOR) { }
        /// <param name="window">Window on which this coordinate system will be displayed</param>
        /// <param name="scale">Initial scale</param>
        /// <param name="color">Initial color</param>
        public CoordinateSystem(GraphWindow window, int scale, Color color) : this(window, scale, DEFAULT_SPACING, color) { }
        /// <param name="window">Window on which this CoordinateSystem will be displayed</param>
        /// <param name="scale">Initial scale</param>
        /// <param name="spacing">Initial spacing</param>
        /// <param name="color">Initial color</param>
        public CoordinateSystem(GraphWindow window, int scale, uint spacing, Color color)
        {
            Window = window;
            Scale = scale;
            Spacing = spacing;
            Color = color;

            OnChange += (s, e) => RequiresRedraw = true;
        }

        #endregion

        #region Methods

        public void Draw(RenderTarget target, RenderStates states)
        {
            DrawMainLines(target);
            DrawSpacingLines(target, 0.5f);

            RequiresRedraw = false;
        }

        private void DrawMainLines(RenderTarget target)
        {
            // Draw horizontal line
            target.Draw(new Vertex[]
            {
                new Vertex(Window.ToWindowCoords(new Vector2f(-Scale, 0)), Color),
                new Vertex(Window.ToWindowCoords(new Vector2f(Scale, 0)), Color)
            }, PrimitiveType.Lines);

            // Draw vertical line
            target.Draw(new Vertex[]
            {
                new Vertex(Window.ToWindowCoords(new Vector2f(0, -Scale)), Color),
                new Vertex(Window.ToWindowCoords(new Vector2f(0, Scale)), Color)
            }, PrimitiveType.Lines);
        }

        private void DrawSpacingLines(RenderTarget target, float lineSize)
        {
            for (float i = Spacing; i < Scale; i += Spacing)
            {
                // Draw spacing lines on horizontal line for both sides
                DrawLineOnPoint(Window.ToWindowCoords(new Vector2f(i, 0)), lineSize, false);
                DrawLineOnPoint(Window.ToWindowCoords(new Vector2f(-i, 0)), lineSize, false);

                // Draw spacing lines on vertical line for both sides
                DrawLineOnPoint(Window.ToWindowCoords(new Vector2f(0, i)), lineSize, true);
                DrawLineOnPoint(Window.ToWindowCoords(new Vector2f(0, -i)), lineSize, true);
            }

            void DrawLineOnPoint(Vector2f point, float size, bool horizontal)
            {
                Vector2f start = horizontal ?
                    new Vector2f(point.X - size, point.Y) : new Vector2f(point.X, point.Y - size);
                Vector2f end = horizontal ?
                    new Vector2f(point.X + size, point.Y) : new Vector2f(point.X, point.Y + size);

                target.Draw(new Vertex[]
                {
                    new Vertex(start, Color),
                    new Vertex(end, Color)
                }, PrimitiveType.Lines);
            }
        }

        #endregion
    }
}