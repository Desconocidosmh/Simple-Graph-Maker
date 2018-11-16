using SFML.Graphics;
using SFML.System;
using Graph.Drawables;

namespace Graph.Window
{
    public class VectorWindow : GraphWindow
    {
        public Vector MainVector { get; set; }

        /// <param name="width">Width of the window in pixels</param>
        /// <param name="heigth">Heigth of the window in pixels</param>
        /// <param name="name">Name of the window</param>
        /// <param name="backgroundColor">This color will be displayed in the background</param>
        /// <param name="initialScale">The coordinate system will have this as it's max value</param>
        /// <param name="coordinateSystemColor">The coordinate system will be drawn in this color</param>
        /// <param name="mainVectorInitialPos">Start position of a main vector</param>
        public VectorWindow(uint width, uint heigth, string name, Color backgroundColor,
            int initialScale, Color coordinateSystemColor, Vector2f mainVectorInitialPos)
            : base(width, heigth, name, backgroundColor, coordinateSystemColor, initialScale)
        {
            MainVector = new Vector(mainVectorInitialPos, coordinateSystemColor);
        }

        protected override void DrawElements()
        {
            Window.Draw(MainVector);
        }
    }
}