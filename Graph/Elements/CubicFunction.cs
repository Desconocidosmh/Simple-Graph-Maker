using System;
using Graph.System;

namespace Graph.Elements
{
    [MenuClass("Cubic Function")]
    public class CubicFunction : Element
    {
        [MenuProperty("A")]
        public float A { get; set; }
        [MenuProperty("B")]
        public float B { get; set; }
        [MenuProperty("C")]
        public float C { get; set; }
        [MenuProperty("D")]
        public float D { get; set; }

        public override float Calculate(float x) =>
            (float)(A * Math.Pow(x, 3) + B * Math.Pow(x, 2) + C * x + D);   
    }
}
