using SFML.Window;

namespace Graph.MathUtils
{
    public static class Interpolation
    {
        /// <summary>
        /// Linear interpolation between two values depending on the lerp value
        /// </summary>
        /// <param name="start">Bottom value</param>
        /// <param name="end">Top value</param>
        /// <param name="lerp">Should be between 0-1</param>
        /// <returns>Result of linear interpolation between two values</returns>
        public static float Lerp(float start, float end, float lerp) => start + (end - start) * lerp;
        /// <summary>
        /// Linear interpolation between two values depending on the lerp value
        /// </summary>
        /// <param name="start">Bottom vector</param>
        /// <param name="end">Top vector</param>
        /// <param name="lerp">Should be between 0-1</param>
        /// <returns>Result of linear interpolation between two vectors</returns>
        public static Vector2f Lerp(Vector2f start, Vector2f end, float lerp) => start + (end - start) * lerp;

        /// <summary>
        /// Reverse lineral interpolation between two values
        /// </summary>
        /// <param name="value">Result of linear interpolation</param>
        /// <param name="start">Bottom value</param>
        /// <param name="end">Top value</param>
        /// <returns>Lerp value</returns>
        public static float Rlerp(float value, float start, float end) => (value - start) / (end - start);
        // It stopped working for some reason, God knows why, I swear it was 
        // passing every test and then stoppen without any good reason. Fuck.
        ///// <summary>
        ///// Reverse lineral interpolation between two vectors
        ///// </summary>
        ///// <param name="value">Result of linear interpolation</param>
        ///// <param name="start">Bottom value</param>
        ///// <param name="end">Top value</param>
        ///// <returns>Lerp value as vector with X Rlerp as its X property and Y Rlerp as its Y property</returns>
        ///// <remarks>If <paramref name="value"/> is a result of Lerp function, X and Y of returned Vector should be the same</remarks>
        //public static Vector2f Rlerp(Vector2f value, Vector2f start, Vector2f end)
        //{
        //    float resultX = Rlerp(value.X, start.X, end.X);
        //    float resultY = Rlerp(value.X, start.X, end.X);

        //    return new Vector2f(resultX, resultY);
        //}

        /// <summary>
        /// Maps value to another value set
        /// </summary>
        /// <param name="value">Value to map</param>
        /// <param name="firstStart">Bottom value of the original set</param>
        /// <param name="firstEnd">Top value of the original set</param>
        /// <param name="secondStart">Bottom value of the target set</param>
        /// <param name="secondEnd">Top value of the target set</param>
        /// <returns>Value mapped to different value set</returns>
        public static float Map(float value, float firstStart, float firstEnd, float secondStart, float secondEnd)
        {
            float lerp = Rlerp(value, firstStart, firstEnd);
            float result = Lerp(secondStart, secondEnd, lerp);
            return result;
        }
        /// <summary>
        /// Maps vector to another vector
        /// </summary>
        /// <param name="value">Vector to map</param>
        /// <param name="firstStart">Bottom vector of the original</param>
        /// <param name="firstEnd">Top vector of the original</param>
        /// <param name="secondStart">Bottom vector of the target</param>
        /// <param name="secondEnd">Top vector of the target</param>
        /// <returns>Vector mapped to different vector</returns>
        public static Vector2f Map(Vector2f value, Vector2f firstStart, Vector2f firstEnd, Vector2f secondStart, Vector2f secondEnd)
        {
            float lerpX = Rlerp(value.X, firstStart.X, firstEnd.X);
            float resultX = Lerp(secondStart.X, secondEnd.X, lerpX);

            float lerpY = Rlerp(value.Y, firstStart.Y, firstEnd.Y);
            float resultY = Lerp(secondStart.Y, secondEnd.Y, lerpY);

            return new Vector2f(resultX, resultY);
        }
        ///// <summary>
        ///// Maps vector to another coordinates based on original coordinates
        ///// </summary>
        ///// <param name="value">Vector to map</param>
        ///// <param name="original">Original coordinates</param>
        ///// <param name="target">Target coordinates</param>
        ///// <returns>Value mapped to different value set</returns>
        //public static Vector2f Map(Vector2f value, Vector2f firstStart, Vector2f firstEnd, Vector2f secondStart, Vector2f secondEnd)
        //{
        //    Vector2f rlerp = Rlerp(value, firstStart, firstEnd);
        //    float lerpX = rlerp.X;
        //    float lerpY = rlerp.Y;

        //    float resultX = Lerp(secondStart.X, secondEnd.X, lerpX);
        //    float resultY = Lerp(secondStart.Y, secondEnd.Y, lerpY);

        //    return new Vector2f(resultX, resultY);
        //}
    }
}
