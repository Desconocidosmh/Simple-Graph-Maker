using System;

namespace Graph.System
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MenuClassAttribute : Attribute
    {
        public string Name { get; }

        public MenuClassAttribute(string name) =>
            Name = name;
    }
}