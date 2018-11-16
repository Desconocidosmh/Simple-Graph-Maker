using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Graph.Drawables;

namespace Graph.Window
{
    public abstract class GraphWindow
    {
        #region Properties

        protected readonly RenderWindow Window;

        public Color BackgroundColor { get; set; }

        /// <summary>
        /// Scale of the coordinate system
        /// </summary>
        public int Scale
        {
            get => coordinateSystem.Scale;
            set
            {
                coordinateSystem.Scale = value;
                //Update window's fov
                Window.SetView(new View(
                    new Vector2f(0, 0),
                    new Vector2f(value, value)));
            }
        }

        private CoordinateSystem coordinateSystem;

        private Sprite BackgroundSprite;

        #endregion

        /// <param name="width">Width of the window in pixels</param>
        /// <param name="heigth">Heigth of the window in pixels</param>
        /// <param name="name">Name of the window</param>
        /// <param name="backgroundColor">This color will be displayed in the background</param>
        /// <param name="initialScale">The coordinate system will have this as it's max value</param>
        /// <param name="coordinateSystemColor">The coordinate system will be drawn in this color</param>
        public GraphWindow(uint width, uint heigth, string name, Color backgroundColor, Color coordinateSystemColor, int initialScale)
        {
            Window = new RenderWindow(
                new VideoMode(width, heigth),
                name);
            Window.SetView(new View(
                new Vector2f(0, 0),
                new Vector2f(initialScale * 2, initialScale * 2))); // Translate point (0, 0) to the middle of the screen and apply fov
            coordinateSystem = new CoordinateSystem(initialScale, coordinateSystemColor);
            BackgroundColor = backgroundColor;
        }

        private void GenerateBackgroundSprite()
        {
            using (var render = new RenderTexture(Window.Size.X, Window.Size.Y))
            {
                Window.SetView(new View(
                new Vector2f(0, 0),
                new Vector2f(coordinateSystem.Scale * 2, coordinateSystem.Scale * 2)));
                render.Draw(coordinateSystem);
                render.Display();

                Sprite result = new Sprite(new Texture(render.Texture));
                result.Origin = new Vector2f(coordinateSystem.Scale / 2, coordinateSystem.Scale / 2);
                BackgroundSprite = result;
            }
        }

        private void DrawBackground()
        {
            if (coordinateSystem.RequiresRedraw)
                GenerateBackgroundSprite();

            Window.Draw(coordinateSystem);
        }

        protected abstract void DrawElements();

        public void Refresh()
        {
            Window.Clear(BackgroundColor);

            DrawBackground();
            DrawElements();

            Window.Display();
        }
    }
}
