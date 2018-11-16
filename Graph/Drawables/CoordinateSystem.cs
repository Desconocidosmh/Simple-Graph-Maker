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
        private const int DEFAULT_SCALE = 10;
        private static readonly Color DEFAULT_COLOR = Color.Black;

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

        #region Constructors

        /// <param name="window">Window on which this CoordinateSystem will be displayed</param>
        /// <param name="scale">Initial scale</param>
        public CoordinateSystem(int scale) : this(scale, DEFAULT_COLOR) { }
        /// <param name="window">Window on which this CoordinateSystem will be displayed</param>
        /// <param name="scale">Initial scale</param>
        /// <param name="color">Initial color</param>
        public CoordinateSystem(int scale, Color color)
        {
            Scale = scale;
            Color = color;
        }

        #endregion

        public void Draw(RenderTarget target, RenderStates states)
        {
            // Draw horizontal line
            target.Draw(new Vertex[]
            {
                new Vertex(new Vector2f(-scale, 0), Color),
                new Vertex(new Vector2f(scale, 0), Color)
            }, PrimitiveType.Lines);

            // Draw vertical line
            target.Draw(new Vertex[]
            {
                new Vertex(new Vector2f(0, -scale), Color),
                new Vertex(new Vector2f(0, scale), Color)
            }, PrimitiveType.Lines);

            RequiresRedraw = false;
        }

        ///// <summary>
        ///// Translates position in coordinates into position in pixels
        ///// </summary>
        ///// <param name="coords">Position in coordinates</param>
        ///// <returns>Position in pixels</returns>
        //public Vector2f CoordsToPixels(Vector2f coords) =>
        //    Interpolation.Map(
        //        coords,
        //        new Vector2f(-Scale, -Scale),
        //        new Vector2f(Scale, Scale),
        //        new Vector2f(-windowScaleX / 2, -windowScaleY / 2),
        //        new Vector2f(windowScaleX / 2, windowScaleY / 2));
        ///// <summary>
        ///// Translates position in coordinates into position in pixels
        ///// </summary>
        ///// <param name="x">Position X in coordinates</param>
        ///// <param name="y">Position Y in coordinates</param>
        ///// <returns>Position in pixels</returns>
        //public Vector2f CoordsToPixels(int x, int y) => CoordsToPixels(new Vector2f(x, y));


        ///// <summary>
        ///// Translates position in pixels into position coordinates
        ///// </summary>
        ///// <param name="pixels">Position in pixels</param>
        ///// <returns>Position in coordinates</returns>
        //public Vector2f PixelsToCoords(Vector2f pixels) =>
        //    Interpolation.Map(
        //        pixels,
        //        new Vector2f(-windowScaleX / 2, -windowScaleY / 2),
        //        new Vector2f(windowScaleX / 2, windowScaleY / 2),
        //        new Vector2f(-Scale, -Scale),
        //        new Vector2f(Scale, Scale));
        ///// <summary>
        ///// Translates position in pixels into position coordinates
        ///// </summary>
        ///// <param name="x">Position X in pixels</param>
        ///// <param name="y">Position Y in pixels</param>
        ///// <returns>Position in coordinates</returns>
        //public Vector2f PixelToCoords(int x, int y) => PixelsToCoords(new Vector2f(x, y));
    }
}