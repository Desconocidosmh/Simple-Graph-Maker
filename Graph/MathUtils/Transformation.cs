
namespace Graph.MathUtils
{
    public static class Transformation
    {
        public const float RAD_TO_DEG = 57.29577951308232087679f;
        public const float DEG_TO_RAD = 0.017453292519943295769f;

        public static float KeepSize(float actualSize, float sampleSize, float currentSize)=>
            actualSize / sampleSize * currentSize;
    }
}