using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Graph.Elements;
using Graph.System;
using SFML.Graphics;

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
                result.Add(CreateNameLabel(property));

                if (property.PropertyType == typeof(bool))
                    result.Add(CreateCheckbox(element, property));
                else if (property.PropertyType == typeof(Color))
                    result.Add(CreateColorTextbox(element, property));
                else if (property.PropertyType == typeof(float))
                    result.Add(CreateFloatTextbox(element, property));
                else if (property.PropertyType == typeof(int))
                    result.Add(CreateIntTextbox(element, property));
            }

            return result.ToArray();
        }

        private static Label CreateNameLabel(PropertyInfo property)
        {
            var propertyAttribute =
                    (MenuPropertyAttribute)property.GetCustomAttribute(typeof(MenuPropertyAttribute));

            return new Label { Text = propertyAttribute.Name, Padding = new Padding(0, 7, 0, 0) };
        }

        private static CheckBox CreateCheckbox(Element element, PropertyInfo property)
        {
            var propertyAttribute =
                    (MenuPropertyAttribute)property.GetCustomAttribute(typeof(MenuPropertyAttribute));

            var checkBox = new CheckBox { Text = propertyAttribute.Name };
            checkBox.CheckedChanged += (s, e) => property.SetValue(element, checkBox.Checked);
            return checkBox;
        }

        private static TextBox CreateColorTextbox(Element element, PropertyInfo property)
        {
            var color = (Color)property.GetValue(element);
            var textBox = new TextBox { Text = string.Format("{0},{1},{2}", color.R, color.G, color.B) };
            textBox.TextChanged += (s, e) =>
            {
                if (textBox.Text.Count((c) => c == ',') != 2)
                    return;

                string[] rgbStr = textBox.Text.Split(',');
                byte[] rgb = new byte[3];
                for (int i = 0; i < 3; i++)
                {
                    if (!byte.TryParse(rgbStr[i], out rgb[i]))
                        return;
                }
                property.SetValue(element, new Color(rgb[0], rgb[1], rgb[2]));
            };
            return textBox;
        }

        private static TextBox CreateIntTextbox(Element element, PropertyInfo property)
        {
            var textBox = new TextBox { Text = property.GetValue(element).ToString() };
            textBox.TextChanged += (s, e) =>
            {
                if (int.TryParse(textBox.Text, out int res))
                    property.SetValue(element, res);
                else
                    property.SetValue(element, 0);
            };
            return textBox;
        }

        private static TextBox CreateFloatTextbox(Element element, PropertyInfo property)
        {
            var textBox = new TextBox { Text = property.GetValue(element).ToString() };
            textBox.TextChanged += (s, e) =>
            {
                if (float.TryParse(textBox.Text, out float res))
                    property.SetValue(element, res);
                else
                    property.SetValue(element, 0);
            };
            return textBox;
        }
    }
}