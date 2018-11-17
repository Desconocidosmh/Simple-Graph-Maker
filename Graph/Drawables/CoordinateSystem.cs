using SFML.Graphics;
using SFML.System;

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

        private readonly RenderWindow Window;

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
                scale = value;
                RequiresRedraw = true;
            }
        }
        private int scale;

        public float SpacingLinesSize { get; set; }

        /// <summary>
        /// Spacing of this CoordinateSystem
        /// </summary>
        public uint Spacing
        {
            get => spacing;
            set
            {
                spacing = value;
                RequiresRedraw = true;
            }
        }
        private uint spacing;

        /// <summary>
        /// Color of this CoordinateSystem
        /// </summary>
        public Color Color
        {
            get => color;
            set
            {
                color = value;
                RequiresRedraw = true;
            }
        }
        private Color color;

        public bool RequiresRedraw { get; private set; }


        #endregion

        #region Constructors

        /// <param name="window">
        /// Window on which this coordinate system will be displayed
        /// </param>
        public CoordinateSystem(RenderWindow window) : this(window, DEFAULT_SCALE, DEFAULT_SPACING, DEFAULT_COLOR) { }
        /// <param name="window">Window on which this coordinate system will be displayed</param>
        /// <param name="scale">Initial scale</param>
        public CoordinateSystem(RenderWindow window, int scale) : this(window, scale, DEFAULT_SPACING, DEFAULT_COLOR) { }
        /// <param name="window">Window on which this coordinate system will be displayed</param>
        /// <param name="color">Initial color</param>
        public CoordinateSystem(RenderWindow window, Color color) : this(window, DEFAULT_SCALE, DEFAULT_SPACING, color) { }
        /// <param name="window">Window on which this coordinate system will be displayed</param>
        /// <param name="scale">Initial scale</param>
        /// <param name="spacing">Initial spacing</param>
        public CoordinateSystem(RenderWindow window, int scale, uint spacing) : this(window, scale, spacing, DEFAULT_COLOR) { }
        /// <param name="window">Window on which this coordinate system will be displayed</param>
        /// <param name="scale">Initial scale</param>
        /// <param name="color">Initial color</param>
        public CoordinateSystem(RenderWindow window, int scale, Color color) : this(window, scale, DEFAULT_SPACING, color) { }
        /// <param name="window">Window on which this CoordinateSystem will be displayed</param>
        /// <param name="scale">Initial scale</param>
        /// <param name="spacing">Initial spacing</param>
        /// <param name="color">Initial color</param>
        public CoordinateSystem(RenderWindow window, int scale, uint spacing, Color color)
        {
            Window = window;
            Scale = scale;
            Spacing = spacing;
            Color = color;
        }

        #endregion

        #region Methods

        public void Draw(RenderTarget target, RenderStates states)
        {
            DrawMainLines(target);
            DrawSpacingLines(target, 0.25f);

            RequiresRedraw = false;
        }

        private void DrawMainLines(RenderTarget target)
        {
            // Draw horizontal line
            target.Draw(new Vertex[]
            {
                new Vertex(new Vector2f(-Scale, 0), Color),
                new Vertex(new Vector2f(Scale, 0), Color)
            }, PrimitiveType.Lines);

            // Draw vertical line
            target.Draw(new Vertex[]
            {
                new Vertex(new Vector2f(0, -Scale), Color),
                new Vertex(new Vector2f(0, Scale), Color)
            }, PrimitiveType.Lines);
        }

        private void DrawSpacingLines(RenderTarget target, float lineSize)
        {
            for (uint i = Spacing; i < Scale; i += Spacing)
            {
                // Draw spacing lines on horizontal line for both sides
                DrawLineOnPoint(new Vector2f(i, 0), lineSize, false);
                DrawLineOnPoint(new Vector2f(-i, 0), lineSize, false);

                // Draw spacing lines on vertical line for both sides
                DrawLineOnPoint(new Vector2f(0, i), lineSize, true);
                DrawLineOnPoint(new Vector2f(0, -i), lineSize, true);
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