using System;

namespace Graph.System
{
    /// <summary>
    /// Attribute used to display property as a
    /// text box, which can be used to manipulate
    /// value of the property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MenuItemAttribute : Attribute
    {
        private const int DEFAULT_MIN = 0;
        private const int DEFAULT_MAX = 100;

        public int Min { get; }
        public int Max { get; }

        public MenuItemAttribute() : this(DEFAULT_MIN, DEFAULT_MAX) { }

        /// <param name="min">Bottom value cap</param>
        /// <param name="max">Top value cap</param>
        public MenuItemAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}
