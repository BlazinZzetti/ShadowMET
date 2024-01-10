namespace ShadowMET
{
    partial class MainForm
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
            this.SetFolderButton = new System.Windows.Forms.Button();
            this.MetPictureBox = new System.Windows.Forms.PictureBox();
            this.AvailableMetsComboBox = new System.Windows.Forms.ComboBox();
            this.unicodeSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.EditCharButton = new System.Windows.Forms.Button();
            this.AddCharButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MetPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SetFolderButton
            // 
            this.SetFolderButton.Location = new System.Drawing.Point(12, 12);
            this.SetFolderButton.Name = "SetFolderButton";
            this.SetFolderButton.Size = new System.Drawing.Size(100, 23);
            this.SetFolderButton.TabIndex = 0;
            this.SetFolderButton.Text = "Set Fonts Folder";
            this.SetFolderButton.UseVisualStyleBackColor = true;
            this.SetFolderButton.Click += new System.EventHandler(this.SetFolderButton_Click);
            // 
            // MetPictureBox
            // 
            this.MetPictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MetPictureBox.Location = new System.Drawing.Point(12, 41);
            this.MetPictureBox.Name = "MetPictureBox";
            this.MetPictureBox.Size = new System.Drawing.Size(512, 512);
            this.MetPictureBox.TabIndex = 1;
            this.MetPictureBox.TabStop = false;
            // 
            // AvailableMetsComboBox
            // 
            this.AvailableMetsComboBox.FormattingEnabled = true;
            this.AvailableMetsComboBox.Location = new System.Drawing.Point(118, 14);
            this.AvailableMetsComboBox.Name = "AvailableMetsComboBox";
            this.AvailableMetsComboBox.Size = new System.Drawing.Size(135, 21);
            this.AvailableMetsComboBox.TabIndex = 2;
            this.AvailableMetsComboBox.SelectedIndexChanged += new System.EventHandler(this.AvailableMetsComboBox_SelectedIndexChanged);
            // 
            // unicodeSelectionComboBox
            // 
            this.unicodeSelectionComboBox.FormattingEnabled = true;
            this.unicodeSelectionComboBox.Location = new System.Drawing.Point(259, 14);
            this.unicodeSelectionComboBox.Name = "unicodeSelectionComboBox";
            this.unicodeSelectionComboBox.Size = new System.Drawing.Size(103, 21);
            this.unicodeSelectionComboBox.TabIndex = 3;
            this.unicodeSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.unicodeSelectionComboBox_SelectedIndexChanged);
            // 
            // EditCharButton
            // 
            this.EditCharButton.Location = new System.Drawing.Point(368, 12);
            this.EditCharButton.Name = "EditCharButton";
            this.EditCharButton.Size = new System.Drawing.Size(75, 23);
            this.EditCharButton.TabIndex = 4;
            this.EditCharButton.Text = "Edit";
            this.EditCharButton.UseVisualStyleBackColor = true;
            this.EditCharButton.Click += new System.EventHandler(this.EditCharButton_Click);
            // 
            // AddCharButton
            // 
            this.AddCharButton.Location = new System.Drawing.Point(449, 12);
            this.AddCharButton.Name = "AddCharButton";
            this.AddCharButton.Size = new System.Drawing.Size(75, 23);
            this.AddCharButton.TabIndex = 5;
            this.AddCharButton.Text = "Add";
            this.AddCharButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 564);
            this.Controls.Add(this.AddCharButton);
            this.Controls.Add(this.EditCharButton);
            this.Controls.Add(this.unicodeSelectionComboBox);
            this.Controls.Add(this.AvailableMetsComboBox);
            this.Controls.Add(this.MetPictureBox);
            this.Controls.Add(this.SetFolderButton);
            this.Name = "MainForm";
            this.Text = "ShadowMET";
            ((System.ComponentModel.ISupportInitialize)(this.MetPictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button EditCharButton;
        private System.Windows.Forms.Button AddCharButton;

        private System.Windows.Forms.ComboBox unicodeSelectionComboBox;

        private System.Windows.Forms.ComboBox AvailableMetsComboBox;

        private System.Windows.Forms.PictureBox MetPictureBox;

        private System.Windows.Forms.Button SetFolderButton;

        #endregion
    }
}