using System;
using SFML.System;

namespace Graph.Elements
{
    public class SquareFunction : Element, System.IShiftable
    {
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }

        public float Delta => (float)Math.Pow(B, 2) - 4 * A * C;

        public Vector2f Shift { get; set; }

        public SquareFunction(float a, float b, float c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override float Calculate(float x) =>
                A * (float)Math.Pow(x + Shift.X, 2) + B * x + C + Shift.Y;
    }
}