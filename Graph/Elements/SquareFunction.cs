using System;
using Graph.System;
using SFML.System;

namespace Graph.Elements
{
    [MenuClass("Square Function")]
    public class SquareFunction : Element, IShiftable
    {
        [MenuProperty("A")]
        public float A { get; set; }
        [MenuProperty("B")]
        public float B { get; set; }
        [MenuProperty("C")]
        public float C { get; set; }

        public float Delta => (float)Math.Pow(B, 2) - 4 * A * C;

        public Vector2f Shift { get; set; }

        public SquareFunction()
        {
            A = 0;
            B = 0;
            C = 0;
        }

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