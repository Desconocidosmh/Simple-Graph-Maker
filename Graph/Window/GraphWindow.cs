using SFML.Graphics;
using SFML.System;
using Graph.MathUtils;
using Graph.Elements;
using Graph.Elements.Subdrawables;
using System.Collections.Generic;

namespace Graph.Window
{
    public class GraphWindow : BaseWindow
    {
        #region Properties

        /// <summary>
        /// Elements drawn on top of background
        /// </summary>
        private readonly List<Element> Elements;

        /// <summary>
        /// Coordinate system of this window
        /// </summary>
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
            Elements = new List<Element>();
            CoordinateSystem = new CoordinateSystem(this, initialScale, coordinateSystemColor);
        }

        #endregion

        #region Methods

        protected override void DrawBackground(RenderTarget target) =>
            target.Draw(CoordinateSystem);

        protected override void DrawForeground(RenderTarget target)
        {
            foreach (var element in Elements)
            {
                var vertices = new List<Vertex>();

                uint xPixels = this.Resolution.X;

                for (uint i = 0; i < xPixels; i++)
                {
                    float xPos = Interpolation.Map(
                        i, 0, xPixels, -this.CoordinateSystem.Scale, this.CoordinateSystem.Scale);

                    float yPos = element.Calculate(xPos);

                    // If calculated value is NaN, start drawing next line
                    if (float.IsNaN(yPos) || float.IsInfinity(yPos))
                    {
                        target.Draw(vertices.ToArray(), PrimitiveType.LinesStrip);
                        vertices.Clear();
                    }

                    vertices.Add(new Vertex(
                        this.ToWindowCoords(
                            new Vector2f(xPos, yPos)), element.Color));
                }

                target.Draw(vertices.ToArray(), PrimitiveType.LinesStrip);
            }
        }

        /// <summary>
        /// Adds element to the dictionary of elements
        /// </summary>
        /// <param name="name">Name which can be later used to access this element</param>
        /// <param name="element">Element which will be added</param>
        public void AddElement(Element element) =>
            Elements.Add(element);

        /// <summary>
        /// Gets all elements from the list of elements
        /// </summary>
        /// <returns>All elements of this window as one dimensional array</returns>
        public Element[] GetElements() =>
            Elements.ToArray();

        /// <summary>
        /// Determines whether element is child of this window
        /// </summary>
        /// <param name="element">Element to check</param>
        /// <returns>True if it's a child of this window. Otherwise false</returns>
        public bool IsParentOf(Element element) =>
            Elements.Contains(element);

        /// <summary>
        /// Finds and removes element specified as the argument from the list of elements
        /// </summary>
        /// <param name="element">Element which will be removed</param>
        /// <returns>True if successful; False if failed</returns>
        public bool RemoveElement(Element element)
        {
            if (Elements.Contains(element))
            {
                Elements.Remove(element);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Transform graph coords to window coords
        /// </summary>
        /// <param name="pos">Origin position</param>
        /// <returns>Graph coords transformed into window coords</returns>
        public Vector2f ToWindowCoords(Vector2f pos)
        {
            float X = Interpolation.Map(pos.X, -CoordinateSystem.Scale * 2, CoordinateSystem.Scale * 2, -Window.GetView().Size.X, Window.GetView().Size.X);
            float Y = -Interpolation.Map(pos.Y, -CoordinateSystem.Scale * 2, CoordinateSystem.Scale * 2, -Window.GetView().Size.Y, Window.GetView().Size.Y);

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
            float Y = -Interpolation.Map(pos.Y, -Window.GetView().Size.Y, Window.GetView().Size.Y, -CoordinateSystem.Scale * 2, CoordinateSystem.Scale * 2);

            return new Vector2f(X, Y);
        }

        #endregion
    }
}