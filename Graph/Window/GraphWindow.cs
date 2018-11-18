using SFML.Graphics;
using SFML.System;
using Graph.MathUtils;
using Graph.Drawables;

namespace Graph.Window
{
    public abstract class GraphWindow : BaseWindow
    {
        #region Properties

        public CoordinateSystem CoordinateSystem { get; private set; }

        #endregion

        #region Constructors

        /// <param name="width">Width of the window in pixels</param>
        /// <param name="heigth">Heigth of the window in pixels</param>
        /// <param name="name">Name of the window</param>
        /// <param name="backgroundColor">This color will be displayed in the background</param>
        /// <param name="initialScale">The coordinate system will have this as it's max value</param>
        /// <param name="coordinateSystemColor">The coordinate system will be drawn in this color</param>
        public GraphWindow(uint width, uint heigth, string name, Color backgroundColor, Color coordinateSystemColor, int initialScale)
            : base(width, heigth, name, backgroundColor)
        {
            CoordinateSystem = new CoordinateSystem(this, initialScale, coordinateSystemColor);
        }

        #endregion
        
        #region Methods

        protected override void DrawBackground(RenderTarget target)
        {
            target.Draw(CoordinateSystem);
        }

        /// <summary>
        /// Transform graph coords to window coords
        /// </summary>
        /// <param name="pos">Origin position</param>
        /// <returns>Graph coords transformed into window coords</returns>
        public Vector2f ToWindowCoords(Vector2f pos)
        {
            float X = Interpolation.Map(pos.X, -CoordinateSystem.Scale * 2, CoordinateSystem.Scale * 2, -Window.GetView().Size.X, Window.GetView().Size.X);
            float Y = Interpolation.Map(pos.Y, -CoordinateSystem.Scale * 2, CoordinateSystem.Scale * 2, -Window.GetView().Size.Y, Window.GetView().Size.Y);

            return new Vector2f(X, Y);
        }

        /// <summary>
        /// Transform window coords to graph coords
        /// </summary>
        /// <param name="pos">Origin position</param>
        /// <returns>Window coords transformed into graph coords</returns>
        public Vector2f ToGraphCoords(Vector2f pos)
        {
            float X = Interpolation.Map(pos.X, -Window.GetView().Size.X, Window.GetView().Size.X, -CoordinateSystem.Scale * 2, CoordinateSystem.Scale * 2);
            float Y = Interpolation.Map(pos.Y, -Window.GetView().Size.Y, Window.GetView().Size.Y, -CoordinateSystem.Scale * 2, CoordinateSystem.Scale * 2);

            return new Vector2f(X, Y);
        }

        #endregion
    }
}