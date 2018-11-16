using System;
using SFML.System;

namespace Graph.MathUtils
{
    public static class SpaceMath
    {
        public const float RAD_TO_DEG = 57.29577951308232087679f;
        public const float DEG_TO_RAD = 0.017453292519943295769f;

        public static float DistanceBetween(Vector2f start, Vector2f end)
        {
            float XlengthSquared = (float)Math.Pow(Math.Abs(end.X - start.X), 2);
            float YlengthSquared = (float)Math.Pow(Math.Abs(end.Y - start.Y), 2);

            float result = (float)Math.Sqrt(XlengthSquared + YlengthSquared);

            return result;
        }

        public static float AngleBetween(Vector2f start, Vector2f end) =>
            (float)(Math.Atan2(end.Y, end.X) - Math.Atan2(start.Y, start.X)) * RAD_TO_DEG;
    }
}
