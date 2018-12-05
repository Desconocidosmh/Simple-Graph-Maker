using System;
using System.Collections.Generic;
using Graph.MathUtils;
using Graph.System;
using SFML.Graphics;
using SFML.System;

namespace Graph.Drawables
{
    public class SineWave : Element, ICalculate
    {
        #region Properties

        public float Amplitude { get; set; }

        public float Density { get; set; }

        #endregion

        #region Constructors

        public SineWave(float amplitude, float density)
        {
            Amplitude = amplitude;
            Density = density;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculate Y from X
        /// </summary>
        /// <param name="x">X parameter to calculate Y</param>
        /// <returns>Value of Y</returns>
        public float Calculate(float x) =>
            (float)Math.Sin(x * Density) * Amplitude;

        public override void Draw(RenderTarget target, RenderStates states)
        {
            var vertexes = new List<Vertex>();

            uint xPixels = GetParentWindow().Resolution.X;

            for (uint i = 0; i < xPixels; i++)
            {
                float xPos = Interpolation.Map(
                    i, 0, xPixels, -GetParentWindow().CoordinateSystem.Scale, GetParentWindow().CoordinateSystem.Scale);

                vertexes.Add(new Vertex(
                    GetParentWindow().ToWindowCoords(
                        new Vector2f(xPos, Calculate(xPos))), Color));
            }

            target.Draw(vertexes.ToArray(), PrimitiveType.LinesStrip);
        }

        #endregion
    }
}
