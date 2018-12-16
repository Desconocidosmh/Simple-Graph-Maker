using Graph.System;
using SFML.Window;

namespace Graph.Elements
{
    [MenuClass("Hyperbole")]
    public class Hyperbole : Element, IShiftable
    {
        [MenuProperty("A")]
        public float A { get; set; }

        public Vector2f Shift { get; set; }

        public Hyperbole() =>
            A = 0;

        public Hyperbole(float a) =>
            A = a;

        public override float Calculate(float x) =>
            A / (x + Shift.X) + Shift.Y;
    }
}