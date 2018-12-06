
namespace Graph.Drawables
{
    public class Hyperbole : Element
    {
        public float A { get; set; }

        public Hyperbole(float a) =>
            A = a;

        public override float Calculate(float x)
        {
            return A / x;
        }
    }
}