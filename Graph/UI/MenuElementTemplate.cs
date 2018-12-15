using System;

namespace GraphUI
{
    public class MenuElementTemplate
    {
        public Type Type { get; set; }
        public string Name { get; set; }

        public MenuElementTemplate(Type type, string name)
        {
            Type = type;
            Name = name;
        }

        public override string ToString() => Name;
    }
}