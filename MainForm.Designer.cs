namespace Snarkorel.transnavi.enroute
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.requestButton = new System.Windows.Forms.Button();
            this.routesListBox = new System.Windows.Forms.ListBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.transportTypeComboBox = new System.Windows.Forms.ComboBox();
            this.vehiclesListBox = new System.Windows.Forms.ListBox();
            this.vehicleInfoTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // requestButton
            // 
            this.requestButton.Location = new System.Drawing.Point(12, 12);
            this.requestButton.Name = "requestButton";
            this.requestButton.Size = new System.Drawing.Size(89, 23);
            this.requestButton.TabIndex = 0;
            this.requestButton.Text = "Подключиться";
            this.requestButton.UseVisualStyleBackColor = true;
            this.requestButton.Click += new System.EventHandler(this.requestButton_Click);
            // 
            // routesListBox
            // 
            this.routesListBox.FormattingEnabled = true;
            this.routesListBox.Location = new System.Drawing.Point(12, 94);
            this.routesListBox.Name = "routesListBox";
            this.routesListBox.Size = new System.Drawing.Size(89, 199);
            this.routesListBox.TabIndex = 1;
            this.routesListBox.SelectedIndexChanged += new System.EventHandler(this.routesListBox_SelectedIndexChanged);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(12, 68);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(89, 20);
            this.searchTextBox.TabIndex = 3;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // transportTypeComboBox
            // 
            this.transportTypeComboBox.FormattingEnabled = true;
            this.transportTypeComboBox.Items.AddRange(new object[] {
            "Автобус",
            "Троллейбус",
            "Трамвай"});
            this.transportTypeComboBox.Location = new System.Drawing.Point(12, 41);
            this.transportTypeComboBox.Name = "transportTypeComboBox";
            this.transportTypeComboBox.Size = new System.Drawing.Size(89, 21);
            this.transportTypeComboBox.TabIndex = 4;
            this.transportTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.transportTypeComboBox_SelectedIndexChanged);
            // 
            // vehiclesListBox
            // 
            this.vehiclesListBox.FormattingEnabled = true;
            this.vehiclesListBox.Location = new System.Drawing.Point(107, 12);
            this.vehiclesListBox.Name = "vehiclesListBox";
            this.vehiclesListBox.Size = new System.Drawing.Size(81, 277);
            this.vehiclesListBox.TabIndex = 5;
            this.vehiclesListBox.SelectedIndexChanged += new System.EventHandler(this.vehiclesListBox_SelectedIndexChanged);
            // 
            // vehicleInfoTextBox
            // 
            this.vehicleInfoTextBox.Location = new System.Drawing.Point(194, 12);
            this.vehicleInfoTextBox.Name = "vehicleInfoTextBox";
            this.vehicleInfoTextBox.ReadOnly = true;
            this.vehicleInfoTextBox.Size = new System.Drawing.Size(318, 281);
            this.vehicleInfoTextBox.TabIndex = 6;
            this.vehicleInfoTextBox.Text = "";
            this.vehicleInfoTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.vehicleInfoTextBox_LinkClicked);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 304);
            this.Controls.Add(this.vehicleInfoTextBox);
            this.Controls.Add(this.vehiclesListBox);
            this.Controls.Add(this.transportTypeComboBox);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.routesListBox);
            this.Controls.Add(this.requestButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "Что на маршруте?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button requestButton;
        private System.Windows.Forms.ListBox routesListBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox transportTypeComboBox;
        private System.Windows.Forms.ListBox vehiclesListBox;
        private System.Windows.Forms.RichTextBox vehicleInfoTextBox;
    }
}

