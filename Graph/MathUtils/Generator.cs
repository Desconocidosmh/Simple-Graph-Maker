using System;
using SFML.Window;

namespace Graph.MathUtils
{
    public static class Generator
    {
        /// <summary>
        /// Generates random vector of which XY values are in specified numerical interval
        /// </summary>
        /// <param name="min">Bottom possible value of X and Y</param>
        /// <param name="max">Top possible of X and Y</param>
        /// <returns>Random vector</returns>
        public static Vector2f GetRandomVector(int min, int max) =>
            GetRandomVector(min, max, DateTime.Now.ToUniversalTime().Millisecond);
        /// <summary>
        /// Generates random vector based on provided seed of which XY values are in specified numerical interval
        /// </summary>
        /// <param name="min">Bottom possible value of X and Y</param>
        /// <param name="max">Top possible of X and Y</param>
        /// <param name="seed">Seed which will be used to generate random vector</param>
        /// <returns>Random vector</returns>
        public static Vector2f GetRandomVector(int min, int max, int seed)
        {
            Random random = new Random(seed);
            float x = random.Next(min, max);
            float y = random.Next(min, max);
            return new Vector2f(x, y);
        }
    }
}
