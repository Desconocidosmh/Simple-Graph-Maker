using System;
using System.Collections.Generic;
using Graph.Window;
using Graph.MathUtils;
using SFML.System;
using SFML.Graphics;

namespace Graph.Drawables
{
    public class SquareFunction : IElement, Drawable
    {
        #region Properties

        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }

        public float Delta => (float)Math.Pow(B, 2) - 4 * A * C;

        public Color Color { get; private set; }
        public GraphWindow ParentWindow
        {
            get => parentWindow;
            set
            {
                if (parentWindow != null)
                    parentWindow.CoordinateSystem.OnChange -= (s, e) => DeriveFromCoordinateSystem();

                parentWindow = value;

                if (parentWindow != null)
                {
                    DeriveFromCoordinateSystem();
                    parentWindow.CoordinateSystem.OnChange += (s, e) => DeriveFromCoordinateSystem();
                }
            }
        }
        private GraphWindow parentWindow;

        #endregion

        #region Constructors

        public SquareFunction(float a, float b, float c)
        {
            A = a;
            B = b;
            C = c;
            Color = Color.Black;
        }

        #endregion

        #region Methods

        public void Draw(RenderTarget target, RenderStates states)
        {
            var vertexes = new List<Vertex>();

            uint xPixels = ParentWindow.Resolution.X;

            for (uint i = 0; i < xPixels; i++)
            {
                float xPos = Interpolation.Map(
                    i, 0, xPixels, -ParentWindow.CoordinateSystem.Scale, ParentWindow.CoordinateSystem.Scale);

                vertexes.Add(new Vertex(
                    ParentWindow.ToWindowCoords(
                        new Vector2f(xPos, Calculate(xPos))), Color));
            }

            target.Draw(vertexes.ToArray(), PrimitiveType.LinesStrip);
        }

        public void DeriveFromCoordinateSystem()
        {
            if (ParentWindow != null)
                Color = ParentWindow.CoordinateSystem.Color;
        }

        public float Calculate(float x) =>
                -(A * (float)Math.Pow(x, 2) + B * x + C); // We put '-' here, beacuse Y axis is flipped in SFML liblary

        #endregion
    }
}
