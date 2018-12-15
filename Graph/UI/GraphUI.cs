using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Graph.Window;
using Graph.Elements;
using Graph.System;
using SFML.Graphics;

namespace GraphUI
{
    public partial class GraphManagerWindow : Form
    {
        public static GraphWindow graphWindow = new GraphWindow(800, 800, "Graph", Color.White, Color.Black, 10);

        public GraphManagerWindow()
        {
            InitializeComponent();

            InitializeElementsDropdown();
        }

        private void InitializeElementsDropdown()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where((type) => type.IsSubclassOf(typeof(Element)));

            var elements = new List<MenuElementTemplate>();

            foreach (var type in types)
            {
                var attribute =
                    (MenuClassAttribute)type.GetCustomAttribute(typeof(MenuClassAttribute));

                if (attribute != null)
                    elements.Add(new MenuElementTemplate(type, attribute.Name));
            }

            foreach (var element in elements)
            {
                templatesDropdown.Items.Add(element);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var currentItem = (MenuElementTemplate)templatesDropdown.SelectedItem;
            var element = new MenuElement(currentItem);
            graphWindow.AddElement(element.Element);
            elementsList.Items.Add(element);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            MenuElement[] selectionCopy = new MenuElement[elementsList.SelectedItems.Count];
            elementsList.SelectedItems.CopyTo(selectionCopy, 0);

            foreach (var item in selectionCopy)
            {
                graphWindow.RemoveElement(item.Element);
                elementsList.Items.Remove(item);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e) =>
            graphWindow.Refresh();

        private void ElementsList_SelectedValueChanged(object sender, EventArgs e)
        {
            elementPropertiesBox.Controls.Clear();

            if (elementsList.SelectedItem == null)
                return;

            var propertiesControls = 
                UiHelper.GetControlsForElement(((MenuElement)elementsList.SelectedItem).Element);

            foreach (var propertyControl in propertiesControls)
            {
                elementPropertiesBox.Controls.Add(propertyControl);
            }
        }
    }
}