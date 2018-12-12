using SFML.System;

namespace Graph.Elements
{
    public class Hyperbole : Element, System.IShiftable
    {
        public float A { get; set; }

        public Vector2f Shift { get; set; }

        public Hyperbole(float a) =>
            A = a;

        public override float Calculate(float x) =>
            A / (x + Shift.X) + Shift.Y;
    }
}