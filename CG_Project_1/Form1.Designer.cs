
namespace CG_Project_1
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.inversionButton = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gammaButton = new System.Windows.Forms.RadioButton();
            this.brightnessButton = new System.Windows.Forms.RadioButton();
            this.contrastButton = new System.Windows.Forms.RadioButton();
            this.convolutionFilterBox = new System.Windows.Forms.ComboBox();
            this.revertButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox1.Location = new System.Drawing.Point(34, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(530, 530);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox2.Location = new System.Drawing.Point(761, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(530, 530);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(222, 575);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(69, 36);
            this.openButton.TabIndex = 2;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(987, 575);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 36);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // inversionButton
            // 
            this.inversionButton.Location = new System.Drawing.Point(606, 58);
            this.inversionButton.Name = "inversionButton";
            this.inversionButton.Size = new System.Drawing.Size(102, 47);
            this.inversionButton.TabIndex = 4;
            this.inversionButton.Text = "Inversion";
            this.inversionButton.UseVisualStyleBackColor = true;
            this.inversionButton.Click += new System.EventHandler(this.inversionButton_Click);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(466, 634);
            this.trackBar.Maximum = 500;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(185, 56);
            this.trackBar.TabIndex = 6;
            this.trackBar.Visible = false;
            this.trackBar.Scroll += new System.EventHandler(this.brightnessTrackBar_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(682, 634);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 22);
            this.textBox1.TabIndex = 8;
            this.textBox1.Visible = false;
            // 
            // gammaButton
            // 
            this.gammaButton.AutoSize = true;
            this.gammaButton.Location = new System.Drawing.Point(584, 217);
            this.gammaButton.Name = "gammaButton";
            this.gammaButton.Size = new System.Drawing.Size(145, 21);
            this.gammaButton.TabIndex = 10;
            this.gammaButton.TabStop = true;
            this.gammaButton.Text = "Gamma correction";
            this.gammaButton.UseVisualStyleBackColor = true;
            this.gammaButton.CheckedChanged += new System.EventHandler(this.gammaButton_CheckedChanged);
            // 
            // brightnessButton
            // 
            this.brightnessButton.AutoSize = true;
            this.brightnessButton.Location = new System.Drawing.Point(584, 128);
            this.brightnessButton.Name = "brightnessButton";
            this.brightnessButton.Size = new System.Drawing.Size(163, 21);
            this.brightnessButton.TabIndex = 11;
            this.brightnessButton.TabStop = true;
            this.brightnessButton.Text = "Brightness correction";
            this.brightnessButton.UseVisualStyleBackColor = true;
            this.brightnessButton.CheckedChanged += new System.EventHandler(this.brightnessButton_CheckedChanged);
            // 
            // contrastButton
            // 
            this.contrastButton.AutoSize = true;
            this.contrastButton.Location = new System.Drawing.Point(584, 170);
            this.contrastButton.Name = "contrastButton";
            this.contrastButton.Size = new System.Drawing.Size(141, 21);
            this.contrastButton.TabIndex = 12;
            this.contrastButton.TabStop = true;
            this.contrastButton.Text = "Contrast enhance";
            this.contrastButton.UseVisualStyleBackColor = true;
            this.contrastButton.CheckedChanged += new System.EventHandler(this.contrastButton_CheckedChanged);
            // 
            // convolutionFilterBox
            // 
            this.convolutionFilterBox.AllowDrop = true;
            this.convolutionFilterBox.FormattingEnabled = true;
            this.convolutionFilterBox.Items.AddRange(new object[] {
            "Blur",
            "Gaussian Blur",
            "Sharpen",
            "Edge Detection",
            "Emboss"});
            this.convolutionFilterBox.Location = new System.Drawing.Point(588, 262);
            this.convolutionFilterBox.Name = "convolutionFilterBox";
            this.convolutionFilterBox.Size = new System.Drawing.Size(163, 24);
            this.convolutionFilterBox.TabIndex = 13;
            this.convolutionFilterBox.SelectedIndexChanged += new System.EventHandler(this.convolutionFilterBox_SelectedIndexChanged);
            // 
            // revertButton
            // 
            this.revertButton.Location = new System.Drawing.Point(606, 332);
            this.revertButton.Name = "revertButton";
            this.revertButton.Size = new System.Drawing.Size(102, 47);
            this.revertButton.TabIndex = 14;
            this.revertButton.Text = "Revert";
            this.revertButton.UseVisualStyleBackColor = true;
            this.revertButton.Click += new System.EventHandler(this.revertButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 773);
            this.Controls.Add(this.revertButton);
            this.Controls.Add(this.convolutionFilterBox);
            this.Controls.Add(this.contrastButton);
            this.Controls.Add(this.brightnessButton);
            this.Controls.Add(this.gammaButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.inversionButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button inversionButton;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton gammaButton;
        private System.Windows.Forms.RadioButton brightnessButton;
        private System.Windows.Forms.RadioButton contrastButton;
        private System.Windows.Forms.ComboBox convolutionFilterBox;
        private System.Windows.Forms.Button revertButton;
    }
}

