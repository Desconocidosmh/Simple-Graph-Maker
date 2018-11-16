using System;
using SFML.System;
using Graph.MathUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graph_Tests
{
    [TestClass]
    public class InterpolationTests
    {
        [TestMethod]
        public void Rinterpolation_ReturnsLerpValueFloat_True()
        {
            Random random = new Random();
            float bottom;
            float top;
            float lerp;
            float lerpResult;
            float rlerpResult;

            for (int i = 0; i < 10; i++)
            {
                bottom = random.Next(1, 1000);
                top = random.Next(1, 1000);
                lerp = random.Next(0, 101) / 100f;

                lerpResult = Interpolation.Lerp(bottom, top, lerp);
                rlerpResult = Interpolation.Rlerp(lerpResult, bottom, top);

                Assert.AreEqual(lerp, rlerpResult, 0.01);
            }
        }

        //[TestMethod]
        //public void Rinterpolation_ReturnsLerpValueVector2f_True()
        //{
        //    Random random = new Random();
        //    Vector2f bottom;
        //    Vector2f top;
        //    float lerp;
        //    Vector2f lerpResult;
        //    Vector2f rlerpResult;

        //    for (int i = 0; i < 10; i++)
        //    {
        //        bottom = Generator.GetRandomVector();
        //        top = Generator.GetRandomVector();
        //        lerp = random.Next(0, 101) / 100f;

        //        lerpResult = Interpolation.Lerp(bottom, top, lerp);
        //        rlerpResult = Interpolation.Rlerp(lerpResult, bottom, top);

        //        Assert.AreEqual(lerp.ToString("0.00"), rlerpResult.X.ToString("0.00"));
        //        Assert.AreEqual(lerp.ToString("0.00"), rlerpResult.Y.ToString("0.00"));
        //    }
        //}

        //[TestMethod]
        //public void Rinterpolation_VectorHasTheSameXandYWhenParameterIsFromLerpResult_True()
        //{
        //    Random random = new Random();
        //    Vector2f vector1;
        //    Vector2f vector2;
        //    float lerp;
        //    Vector2f lerpResult;
        //    Vector2f rlerpResult;

        //    for (int i = 0; i < 10; i++)
        //    {
        //        vector1 = GetRandomVector();
        //        vector2 = GetRandomVector();
        //        lerp = random.Next(0, 101) / 100f;

        //        lerpResult = Interpolation.Lerp(vector1, vector2, lerp);
        //        rlerpResult = Interpolation.Rlerp(lerpResult, vector1, vector2);

        //        Assert.AreEqual(rlerpResult.X, rlerpResult.Y, 0.01);
        //    }

        //    Vector2f GetRandomVector()
        //    {
        //        float x = random.Next(1, 1000);
        //        float y = random.Next(1, 1000);
        //        return new Vector2f(x, y);
        //    }
        //}

        [TestMethod]
        public void Map_Calculate_ReturnsValidValues() => 
            Assert.AreEqual(Interpolation.Map(2, 0, 10, 50, 100), 60);
    }
}
