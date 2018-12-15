using System;

namespace Graph.System
{
    /// <summary>
    /// Attribute used to display property as a
    /// text box, which can be used to manipulate
    /// value of the property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MenuPropertyAttribute : Attribute
    {
        public string Name { get; }

        public MenuPropertyAttribute(string name)
        {
            Name = name;
        }
    }
}