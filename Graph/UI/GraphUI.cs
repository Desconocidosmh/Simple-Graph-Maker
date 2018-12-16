using System;
using System.Threading.Tasks;
using System.Threading;
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

            graphWindow.Refresh();
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

            templatesDropdown.SelectedIndex = 0;
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

        private void ElementsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                RemoveButton_Click(sender, e);
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

        private void RenameButton_Click(object sender, EventArgs e)
        {
            var allItems = elementsList.Items;
            var selectedItems = elementsList.SelectedItems;

            if (selectedItems.Count < 1)
                return;

            if (renameTextBox.Text == "")
                return;

            if (selectedItems.Count == 1)
                ((MenuElement)selectedItems[0]).Name = renameTextBox.Text;
            else
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    ((MenuElement)selectedItems[i]).Name = renameTextBox.Text + (i + 1);
                }

            // Refresh elementsList's content
            for (int i = 0; i < allItems.Count; i++)
            {
                allItems[i] = allItems[i];
            }

            renameTextBox.Clear();
        }

        CancellationTokenSource tokenSource;
        private void RealtimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(realtimeCheckBox.Checked)
            {
                refreshButton.Enabled = false;

                tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;
                Task.Run(() => 
                {
                    while (!token.IsCancellationRequested)
                    {
                        realtimeCheckBox.Invoke(new Action(graphWindow.Refresh));
                        Task.Delay(50).Wait();
                    }
                });
            }
            else
            {
                tokenSource?.Cancel();
                refreshButton.Enabled = true;
            }
        }
    }
}