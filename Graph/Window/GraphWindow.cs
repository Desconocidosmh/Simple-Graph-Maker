using SFML.Graphics;
using SFML.System;
using Graph.MathUtils;
using Graph.Drawables;
using System.Collections.Generic;

namespace Graph.Window
{
    public class GraphWindow : BaseWindow
    {
        #region Properties

        /// <summary>
        /// Elements drawn on top of background
        /// </summary>
        private readonly Dictionary<string, IElement> Elements;

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
            Elements = new Dictionary<string, IElement>();
            CoordinateSystem = new CoordinateSystem(this, initialScale, coordinateSystemColor);
        }

        #endregion

        #region Methods

        protected override void DrawBackground(RenderTarget target) =>
            target.Draw(CoordinateSystem);

        protected override void DrawElements(RenderTarget target)
        {
            foreach (var element in Elements)
            {
                target.Draw(element.Value);
            }
        }

        /// <summary>
        /// Adds element to the dictionary of elements
        /// </summary>
        /// <param name="name">Name which can be later used to access this element</param>
        /// <param name="element">Element which will be added</param>
        public void AddElement(string name, IElement element)
        {
            element.ParentWindow = this;

            Elements.Add(name, element);
        }

        /// <summary>
        /// Gets element from the dictionary of elements
        /// </summary>
        /// <param name="name">Name of the element which will be returned</param>
        /// <returns>Element with specified name. Null if not found</returns>
        public IElement GetElement(string name)
        {
            try
            {
                return Elements[name];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Removes element from the dictionary of elements
        /// </summary>
        /// <param name="name">Name of the element which will be removed</param>
        /// <returns>True if successful; False if failed</returns>
        public bool RemoveElement(string name)
        {
            try
            {
                var element = Elements[name];
                element.ParentWindow = null;
                Elements.Remove(name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get name of every element
        /// </summary>
        /// <returns>Name of every element as one dimensional array</returns>
        public string[] GetAllElementsNames()
        {
            string[] result = new string[Elements.Count];
            Elements.Keys.CopyTo(result, 0);
            return result;
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