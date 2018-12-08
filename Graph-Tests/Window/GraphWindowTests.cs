using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFML.Graphics;
using Graph.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Elements;

namespace Graph.Window.Tests
{
    [TestClass]
    public class GraphWindowTests
    {
        [TestMethod]
        public void AddElement_IsParent_Test_AddsElement_True()
        {
            var window = new GraphWindow(1000, 1000, "Test", Color.White, Color.Black, 10);
            var sine = new SineWave(1, 1);

            window.AddElement(sine);

            Assert.IsTrue(window.IsParentOf(sine));
        }

        [TestMethod]
        public void AddAndRemoveElement_IsParent_Test_AddsAndRemovesElement_False()
        {
            var window = new GraphWindow(1000, 1000, "Test", Color.White, Color.Black, 10);
            var sine = new SineWave(1, 1);

            window.AddElement(sine);
            window.RemoveElement(sine);

            Assert.IsFalse(window.IsParentOf(sine));
        }

        [TestMethod]
        public void GetElements_ValidElements_True()
        {
            var window = new GraphWindow(1000, 1000, "Test", Color.White, Color.Black, 10);
            var sine = new SineWave(1, 1);

            window.AddElement(sine);
            var elements = window.GetElements();

            Assert.IsTrue(elements.Length == 1);
            Assert.IsTrue(elements[0] == sine);
        }

        [TestMethod]
        public void RemoveElement_RemoveNotExistingElement_False()
        {
            var window = new GraphWindow(1000, 1000, "Test", Color.White, Color.Black, 10);
            var sine = new SineWave(1, 1);
            var action = new Func<bool>(() => window.RemoveElement(sine));

            Assert.IsFalse(action.Invoke());
        }
    }
}