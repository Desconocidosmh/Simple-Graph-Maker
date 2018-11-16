using System;
using SFML.System;
using Graph.MathUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graph_Tests
{
    [TestClass]
    public class SpaceMathTests
    {
        [TestMethod]
        public void DistanceBetween_DistanceIsCorrect_True()
        {
            float distance;
            float correctAnswer;
            Vector2f start;
            Vector2f end;

            correctAnswer = 6.708f;
            start = new Vector2f(0, 0);
            end = new Vector2f(6, 3);
            distance = SpaceMath.DistanceBetween(start, end);

            Assert.AreEqual(distance, correctAnswer, 0.1f);

            correctAnswer = 12.041f;
            start = new Vector2f(-10, -5);
            end = new Vector2f(-1, 3);
            distance = SpaceMath.DistanceBetween(start, end);

            Assert.AreEqual(distance, correctAnswer, 0.1f);
        }

        [TestMethod]
        public void DistanceBetween_XandYOrderDoesntMatter_True()
        {
            Random random;
            float X;
            float Y;

            random = new Random();

            for (int i = 0; i < 10; i++)
            {
                X = random.Next(0, 101) - 50;
                Y = random.Next(0, 101) - 50;
                float validOrderDistance = SpaceMath.DistanceBetween(
                    new Vector2f(0, 0),
                    new Vector2f(X, Y));
                float invalidOrderDistance = SpaceMath.DistanceBetween(
                    new Vector2f(0, 0),
                    new Vector2f(Y, X));

                Assert.AreEqual(validOrderDistance, invalidOrderDistance);
            }
        }

        [TestMethod]
        public void AngleBetween_AngleIsCorrect_True()
        {
            Vector2f start;
            Vector2f end;
            float angle;
            float correctAngle;

            start = new Vector2f(-3, 5);
            end = new Vector2f(1, 7);
            angle = SpaceMath.AngleBetween(start, end);
            correctAngle = -0.68f;

            Assert.AreEqual(angle, correctAngle, 0.1);
        }
    }
}
