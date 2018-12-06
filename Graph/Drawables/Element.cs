using SFML.Graphics;
using Graph.System;

namespace Graph.Drawables
{
    public abstract class Element : ICalculate
    {
        #region Properies

        public virtual Color Color { get; set; } = Color.Black;

        #endregion

        #region Methods

        /// <summary>
        /// Calculate Y from X
        /// </summary>
        /// <param name="x">X parameter to calculate Y</param>
        /// <returns>Value of Y</returns>
        public abstract float Calculate(float x);

        #endregion
    }
}