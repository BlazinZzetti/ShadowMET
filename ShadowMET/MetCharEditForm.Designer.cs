using System.ComponentModel;

namespace ShadowMET
{
    partial class MetCharEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.MetPictureBox = new System.Windows.Forms.PictureBox();
            this.PosXUpDown = new System.Windows.Forms.NumericUpDown();
            this.PosYUpDown = new System.Windows.Forms.NumericUpDown();
            this.SizeXUpDown = new System.Windows.Forms.NumericUpDown();
            this.SizeYUpDown = new System.Windows.Forms.NumericUpDown();
            this.UnicodeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MetPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeYUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MetPictureBox
            // 
            this.MetPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MetPictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MetPictureBox.Location = new System.Drawing.Point(147, 12);
            this.MetPictureBox.Name = "MetPictureBox";
            this.MetPictureBox.Size = new System.Drawing.Size(240, 240);
            this.MetPictureBox.TabIndex = 2;
            this.MetPictureBox.TabStop = false;
            // 
            // PosXUpDown
            // 
            this.PosXUpDown.Location = new System.Drawing.Point(92, 38);
            this.PosXUpDown.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            this.PosXUpDown.Name = "PosXUpDown";
            this.PosXUpDown.Size = new System.Drawing.Size(44, 20);
            this.PosXUpDown.TabIndex = 1;
            this.PosXUpDown.ValueChanged += new System.EventHandler(this.MetValueUpDown_ValueChanged);
            // 
            // PosYUpDown
            // 
            this.PosYUpDown.Location = new System.Drawing.Point(92, 64);
            this.PosYUpDown.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            this.PosYUpDown.Name = "PosYUpDown";
            this.PosYUpDown.Size = new System.Drawing.Size(44, 20);
            this.PosYUpDown.TabIndex = 2;
            this.PosYUpDown.ValueChanged += new System.EventHandler(this.MetValueUpDown_ValueChanged);
            // 
            // SizeXUpDown
            // 
            this.SizeXUpDown.Location = new System.Drawing.Point(92, 90);
            this.SizeXUpDown.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.SizeXUpDown.Name = "SizeXUpDown";
            this.SizeXUpDown.Size = new System.Drawing.Size(44, 20);
            this.SizeXUpDown.TabIndex = 3;
            this.SizeXUpDown.ValueChanged += new System.EventHandler(this.MetValueUpDown_ValueChanged);
            // 
            // SizeYUpDown
            // 
            this.SizeYUpDown.Location = new System.Drawing.Point(92, 116);
            this.SizeYUpDown.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.SizeYUpDown.Name = "SizeYUpDown";
            this.SizeYUpDown.Size = new System.Drawing.Size(44, 20);
            this.SizeYUpDown.TabIndex = 4;
            this.SizeYUpDown.ValueChanged += new System.EventHandler(this.MetValueUpDown_ValueChanged);
            // 
            // UnicodeTextBox
            // 
            this.UnicodeTextBox.Location = new System.Drawing.Point(92, 12);
            this.UnicodeTextBox.MaxLength = 1;
            this.UnicodeTextBox.Name = "UnicodeTextBox";
            this.UnicodeTextBox.Size = new System.Drawing.Size(44, 20);
            this.UnicodeTextBox.TabIndex = 0;
            this.UnicodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Unicode Char";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Position X";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Position Y";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Size X";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Size Y";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(11, 200);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(124, 23);
            this.ConfirmButton.TabIndex = 5;
            this.ConfirmButton.Text = "Edit";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(11, 229);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(125, 23);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MetCharEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 266);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UnicodeTextBox);
            this.Controls.Add(this.SizeYUpDown);
            this.Controls.Add(this.SizeXUpDown);
            this.Controls.Add(this.PosYUpDown);
            this.Controls.Add(this.PosXUpDown);
            this.Controls.Add(this.MetPictureBox);
            this.Name = "MetCharEditForm";
            this.Text = "MetCharEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.MetPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeYUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button CloseButton;

        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.TextBox UnicodeTextBox;

        private System.Windows.Forms.NumericUpDown PosXUpDown;
        private System.Windows.Forms.NumericUpDown PosYUpDown;
        private System.Windows.Forms.NumericUpDown SizeXUpDown;
        private System.Windows.Forms.NumericUpDown SizeYUpDown;

        private System.Windows.Forms.PictureBox MetPictureBox;

        #endregion
    }
}