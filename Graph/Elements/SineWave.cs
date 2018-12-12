using System;
using SFML.System;

namespace Graph.Elements
{
    public class SineWave : Element, System.IShiftable
    {
        public float Amplitude { get; set; }

        public float Density { get; set; }

        public Vector2f Shift { get; set; }

        public SineWave(float amplitude, float density)
        {
            Amplitude = amplitude;
            Density = density;
        }

        public override float Calculate(float x) =>
            (float)Math.Sin(x * Density + Shift.X) * Amplitude + Shift.Y;
    }
}
