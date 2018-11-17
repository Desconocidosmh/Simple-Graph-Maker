using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Graph.MathUtils;
using Graph.Drawables;

namespace Graph.Window
{
    public abstract class GraphWindow
    {
        #region Properties

        protected readonly RenderWindow Window;

        /// <summary>
        /// This color will be drawn as background
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// Coordinate system will be drawn in this color
        /// </summary>
        public Color CoordinateSystemColor
        {
            get => coordinateSystem.Color;
            set => coordinateSystem.Color = value;
        }

        /// <summary>
        /// Scale of the coordinate system
        /// </summary>
        public int Scale
        {
            get => coordinateSystem.Scale;
            set
            {
                Window.SetView(new View(
                    new Vector2f(0, 0),
                    new Vector2f(value * 2, value * 2))); //Update window's fov

                coordinateSystem.Scale = value;
            }
        }

        private CoordinateSystem coordinateSystem;

        private Sprite BackgroundSprite;

        #endregion

        #region Constructors

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
            coordinateSystem = new CoordinateSystem(Window ,initialScale, coordinateSystemColor);
            BackgroundColor = backgroundColor;
        }

        #endregion

        #region Methods

        private void GenerateBackgroundSprite()
        {
            using (var render = new RenderTexture(Window.Size.X, Window.Size.Y))
            {
                render.Clear(BackgroundColor);

                render.SetView(new View(
                    new Vector2f(0, 0),
                    new Vector2f(Scale * 2, Scale * 2)
                    ));

                render.Draw(coordinateSystem);

                render.Display();

                Sprite result = new Sprite(new Texture(render.Texture))
                {
                    Origin = (Vector2f)render.Size / 2,
                    Scale = new Vector2f(
                        Transformation.KeepSize(Window.Size.X, Scale),
                        Transformation.KeepSize(Window.Size.Y, Scale)) // Apparently this is the only way I can render background sprite without messing the thickness of the coordinate system
                };

                BackgroundSprite = result;
            }
        }

        private void DrawBackground()
        {
            if (coordinateSystem.RequiresRedraw)
                GenerateBackgroundSprite();

            Window.Draw(BackgroundSprite);
        }

        protected abstract void DrawElements();

        public void Refresh()
        {
            Window.Clear(BackgroundColor);

            DrawBackground();
            DrawElements();

            Window.Display();
        }

        #endregion
    }
}