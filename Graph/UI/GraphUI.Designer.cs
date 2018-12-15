namespace GraphUI
{
    partial class GraphManagerWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.addButton = new System.Windows.Forms.Button();
            this.templatesDropdown = new System.Windows.Forms.ComboBox();
            this.createLabel = new System.Windows.Forms.Label();
            this.manageLabel = new System.Windows.Forms.Label();
            this.elementsList = new System.Windows.Forms.ListBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.elementPropertiesBox = new System.Windows.Forms.FlowLayoutPanel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Controls.Add(this.templatesDropdown);
            this.panel1.Controls.Add(this.createLabel);
            this.panel1.Location = new System.Drawing.Point(-5, -6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 461);
            this.panel1.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(171, 138);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 21);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // templatesDropdown
            // 
            this.templatesDropdown.FormattingEnabled = true;
            this.templatesDropdown.Location = new System.Drawing.Point(17, 138);
            this.templatesDropdown.Name = "templatesDropdown";
            this.templatesDropdown.Size = new System.Drawing.Size(133, 21);
            this.templatesDropdown.TabIndex = 1;
            // 
            // createLabel
            // 
            this.createLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.createLabel.AutoSize = true;
            this.createLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.createLabel.Location = new System.Drawing.Point(130, 27);
            this.createLabel.Name = "createLabel";
            this.createLabel.Size = new System.Drawing.Size(125, 31);
            this.createLabel.TabIndex = 0;
            this.createLabel.Text = "CREATE";
            // 
            // manageLabel
            // 
            this.manageLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.manageLabel.AutoSize = true;
            this.manageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.manageLabel.Location = new System.Drawing.Point(551, 21);
            this.manageLabel.Name = "manageLabel";
            this.manageLabel.Size = new System.Drawing.Size(131, 31);
            this.manageLabel.TabIndex = 1;
            this.manageLabel.Text = "MANAGE";
            // 
            // elementsList
            // 
            this.elementsList.FormattingEnabled = true;
            this.elementsList.HorizontalScrollbar = true;
            this.elementsList.Location = new System.Drawing.Point(411, 55);
            this.elementsList.Name = "elementsList";
            this.elementsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.elementsList.Size = new System.Drawing.Size(163, 95);
            this.elementsList.TabIndex = 2;
            this.elementsList.SelectedValueChanged += new System.EventHandler(this.ElementsList_SelectedValueChanged);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(580, 88);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // elementPropertiesBox
            // 
            this.elementPropertiesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementPropertiesBox.BackColor = System.Drawing.Color.White;
            this.elementPropertiesBox.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.elementPropertiesBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.elementPropertiesBox.Location = new System.Drawing.Point(411, 199);
            this.elementPropertiesBox.Name = "elementPropertiesBox";
            this.elementPropertiesBox.Size = new System.Drawing.Size(377, 239);
            this.elementPropertiesBox.TabIndex = 0;
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(713, 170);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // GraphManagerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.elementPropertiesBox);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.elementsList);
            this.Controls.Add(this.manageLabel);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "GraphManagerWindow";
            this.Text = "GraphUI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label createLabel;
        private System.Windows.Forms.Label manageLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ComboBox templatesDropdown;
        private System.Windows.Forms.ListBox elementsList;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.FlowLayoutPanel elementPropertiesBox;
        private System.Windows.Forms.Button refreshButton;
    }
}