using System;

namespace Graph.Drawables
{
    public class SineWave : Element
    {
        public float Amplitude { get; set; }

        public float Density { get; set; }

        public SineWave(float amplitude, float density)
        {
            Amplitude = amplitude;
            Density = density;
        }

        public override float Calculate(float x) =>
            (float)Math.Sin(x * Density) * Amplitude;
    }
}
