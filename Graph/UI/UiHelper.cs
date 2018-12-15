using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Graph.Elements;
using Graph.System;

namespace GraphUI
{
    public static class UiHelper
    {
        public static Control[] GetControlsForElement(Element element)
        {
            var properties =
                element.GetType()
                .GetProperties()
                .Where((info) => info.GetCustomAttribute(typeof(MenuPropertyAttribute)) != null);

            var result = new List<Control>();

            foreach (var property in properties)
            {
                var propertyAttribute =
                    (MenuPropertyAttribute)property.GetCustomAttribute(typeof(MenuPropertyAttribute));

                if (property.PropertyType == typeof(bool))
                {
                    var checkBox = new CheckBox { Text = propertyAttribute.Name };
                    checkBox.CheckedChanged += (s, e) => property.SetValue(element, checkBox.Checked);
                    result.Add(checkBox);
                }
                else
                {
                    var textBox = new TextBox { Text = property.GetValue(element).ToString() };
                    textBox.TextChanged += (s, e) =>
                    {
                        if (float.TryParse(textBox.Text, out float res))
                            property.SetValue(element, res);
                        else
                            property.SetValue(element, 0);
                    };
                    result.Add(textBox);
                }
            }

            return result.ToArray();
        }
    }
}