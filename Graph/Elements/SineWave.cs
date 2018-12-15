using System;
using Graph.System;
using SFML.System;

namespace Graph.Elements
{
    [MenuClass("Sine Wave")]
    public class SineWave : Element, IShiftable
    {
        [MenuProperty("Amplitude")]
        public float Amplitude { get; set; }

        [MenuProperty("Density")]
        public float Density { get; set; }

        public Vector2f Shift { get; set; }

        public SineWave()
        {
            Amplitude = 0;
            Density = 0;
        }

        public SineWave(float amplitude, float density)
        {
            Amplitude = amplitude;
            Density = density;
        }

        public override float Calculate(float x) =>
            (float)Math.Sin(x * Density + Shift.X) * Amplitude + Shift.Y;
    }
}
