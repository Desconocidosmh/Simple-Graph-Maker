using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using Graph.MathUtils;
using Graph.System;

namespace Graph.Drawables
{
    public class Hyperbole : Element, ICalculate
    {
        #region Properties

        public float A { get; set; }

        #endregion

        #region Constructor

        public Hyperbole(float a) =>
            A = a;

        #endregion

        #region Methods

        /// <summary>
        /// Calculate Y from X
        /// </summary>
        /// <param name="x">X parameter to calculate Y</param>
        /// <returns>Value of Y</returns>
        public float Calculate(float x)
        {
            if (x == 0)
                throw new ArgumentException("Argument cannot be 0 - ", nameof(x));

            return A / x;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            var vertexes = new List<Vertex>();

            uint xPixels = GetParentWindow().Resolution.X;

            for (uint i = 0; i < xPixels; i++)
            {
                float xPos = Interpolation.Map(
                    i, 0, xPixels, -GetParentWindow().CoordinateSystem.Scale, GetParentWindow().CoordinateSystem.Scale);

                if (xPos == 0)
                {
                    target.Draw(vertexes.ToArray(), PrimitiveType.LinesStrip);
                    vertexes.Clear();
                    continue;
                }

                vertexes.Add(new Vertex(
                    GetParentWindow().ToWindowCoords(
                        new Vector2f(xPos, Calculate(xPos))), Color));
            }

            target.Draw(vertexes.ToArray(), PrimitiveType.LinesStrip);
        }

        #endregion
    }
}