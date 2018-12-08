using Graph.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graph_Tests.Elements
{
    [TestClass]
    public class HyperboleTests
    {
        [TestMethod]
        public void Calculate_GetValueForZero_Infinity()
        {
            var hyperbole = new Hyperbole(1);
            float result;

            result = hyperbole.Calculate(0);

            Assert.IsTrue(float.IsInfinity(result));

        }
    }
}
