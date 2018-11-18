using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Graph.Window
{
    public abstract class BaseWindow
    {
        #region Constants

        protected const int DEFAULT_FOV = 100;

        #endregion

        #region Properties

        protected readonly RenderWindow Window;

        /// <summary>
        /// This color will be drawn as background
        /// </summary>
        public Color BackgroundColor { get; set; }

        #endregion

        #region Constructors

        /// <param name="width">Width of the window in pixels</param>
        /// <param name="heigth">Heigth of the window in pixels</param>
        /// <param name="name">Name of the window</param>
        /// <param name="backgroundColor">This color will be displayed in the background</param>
        public BaseWindow(uint width, uint heigth, string name, Color backgroundColor)
        {
            Window = new RenderWindow(
                new VideoMode(width, heigth),
                name);
            Window.SetView(new View(
                new Vector2f(0, 0),
                new Vector2f(DEFAULT_FOV * 2, DEFAULT_FOV * 2))); // Translate point (0, 0) to the middle of the screen and apply fov (times 2 because both sides)
            BackgroundColor = backgroundColor;
        }

        #endregion

        #region Methods

        protected virtual void DrawBackground(RenderTarget target) { }

        protected virtual void DrawElements(RenderTarget target) { }

        public void Refresh()
        {
            Window.Clear(BackgroundColor);

            DrawBackground(Window);
            DrawElements(Window);

            Window.Display();
        }

        #endregion
    }
}
