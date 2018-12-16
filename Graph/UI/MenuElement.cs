using System;
using Graph.Elements;

namespace GraphUI
{
    public class MenuElement
    {
        public string Name { get; set; }

        public Element Element { get; set; }

        public MenuElement(MenuElementTemplate template)
        {
            Name = template.Name;
            Element = (Element)template.Type.GetConstructor(new Type[0]).Invoke(null);
        }

        public override string ToString() =>
            Name;
    }
}