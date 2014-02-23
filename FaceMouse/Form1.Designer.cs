namespace FaceMouse
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
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.buttonCameraProperties = new System.Windows.Forms.Button();
            this.comboBoxCameras = new System.Windows.Forms.ComboBox();
            this.buttonMarkerAdd = new System.Windows.Forms.Button();
            this.checkBoxMarkerHighlight = new System.Windows.Forms.CheckBox();
            this.checkBoxMarkerSmoothing = new System.Windows.Forms.CheckBox();
            this.labelMarkerThresh = new System.Windows.Forms.Label();
            this.labelMarkerData = new System.Windows.Forms.RichTextBox();
            this.btMouse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMarkerThresh = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkAmini = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarkerThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBoxDisplay.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(640, 480);
            this.pictureBoxDisplay.TabIndex = 0;
            this.pictureBoxDisplay.TabStop = false;
            this.pictureBoxDisplay.Click += new System.EventHandler(this.pictureBoxDisplay_Click);
            // 
            // buttonCameraProperties
            // 
            this.buttonCameraProperties.Location = new System.Drawing.Point(661, 12);
            this.buttonCameraProperties.Name = "buttonCameraProperties";
            this.buttonCameraProperties.Size = new System.Drawing.Size(139, 49);
            this.buttonCameraProperties.TabIndex = 1;
            this.buttonCameraProperties.Text = "Ustawienia Kamery";
            this.buttonCameraProperties.UseVisualStyleBackColor = true;
            this.buttonCameraProperties.Click += new System.EventHandler(this.buttonCameraProperties_Click);
            // 
            // comboBoxCameras
            // 
            this.comboBoxCameras.FormattingEnabled = true;
            this.comboBoxCameras.Location = new System.Drawing.Point(826, 27);
            this.comboBoxCameras.Name = "comboBoxCameras";
            this.comboBoxCameras.Size = new System.Drawing.Size(139, 21);
            this.comboBoxCameras.TabIndex = 2;
            this.comboBoxCameras.Text = "Wybierz Kamere";
            this.comboBoxCameras.SelectedIndexChanged += new System.EventHandler(this.comboBoxCameras_SelectedIndexChanged);
            // 
            // buttonMarkerAdd
            // 
            this.buttonMarkerAdd.Location = new System.Drawing.Point(661, 67);
            this.buttonMarkerAdd.Name = "buttonMarkerAdd";
            this.buttonMarkerAdd.Size = new System.Drawing.Size(139, 49);
            this.buttonMarkerAdd.TabIndex = 3;
            this.buttonMarkerAdd.Text = "Dodaj Marker";
            this.buttonMarkerAdd.UseVisualStyleBackColor = true;
            this.buttonMarkerAdd.Click += new System.EventHandler(this.buttonMarkerAdd_Click);
            // 
            // checkBoxMarkerHighlight
            // 
            this.checkBoxMarkerHighlight.AutoSize = true;
            this.checkBoxMarkerHighlight.Checked = true;
            this.checkBoxMarkerHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMarkerHighlight.Enabled = false;
            this.checkBoxMarkerHighlight.Location = new System.Drawing.Point(826, 67);
            this.checkBoxMarkerHighlight.Name = "checkBoxMarkerHighlight";
            this.checkBoxMarkerHighlight.Size = new System.Drawing.Size(103, 17);
            this.checkBoxMarkerHighlight.TabIndex = 4;
            this.checkBoxMarkerHighlight.Text = "Zaznacz Marker";
            this.checkBoxMarkerHighlight.UseVisualStyleBackColor = true;
            this.checkBoxMarkerHighlight.CheckedChanged += new System.EventHandler(this.checkBoxMarkerHighlight_CheckedChanged);
            // 
            // checkBoxMarkerSmoothing
            // 
            this.checkBoxMarkerSmoothing.AutoSize = true;
            this.checkBoxMarkerSmoothing.Checked = true;
            this.checkBoxMarkerSmoothing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMarkerSmoothing.Enabled = false;
            this.checkBoxMarkerSmoothing.Location = new System.Drawing.Point(826, 99);
            this.checkBoxMarkerSmoothing.Name = "checkBoxMarkerSmoothing";
            this.checkBoxMarkerSmoothing.Size = new System.Drawing.Size(148, 17);
            this.checkBoxMarkerSmoothing.TabIndex = 5;
            this.checkBoxMarkerSmoothing.Text = "Wygładzić Dane Markera";
            this.checkBoxMarkerSmoothing.UseVisualStyleBackColor = true;
            this.checkBoxMarkerSmoothing.CheckedChanged += new System.EventHandler(this.checkBoxMarkerSmoothing_CheckedChanged);
            // 
            // labelMarkerThresh
            // 
            this.labelMarkerThresh.AutoSize = true;
            this.labelMarkerThresh.Location = new System.Drawing.Point(829, 148);
            this.labelMarkerThresh.Name = "labelMarkerThresh";
            this.labelMarkerThresh.Size = new System.Drawing.Size(87, 13);
            this.labelMarkerThresh.TabIndex = 7;
            this.labelMarkerThresh.Text = "Kolorów Markera";
            // 
            // labelMarkerData
            // 
            this.labelMarkerData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelMarkerData.Location = new System.Drawing.Point(670, 310);
            this.labelMarkerData.Name = "labelMarkerData";
            this.labelMarkerData.Size = new System.Drawing.Size(295, 182);
            this.labelMarkerData.TabIndex = 8;
            this.labelMarkerData.Text = "";
            // 
            // btMouse
            // 
            this.btMouse.Location = new System.Drawing.Point(661, 123);
            this.btMouse.Name = "btMouse";
            this.btMouse.Size = new System.Drawing.Size(139, 49);
            this.btMouse.TabIndex = 9;
            this.btMouse.Text = "Przechwytywanie Myszy";
            this.btMouse.UseVisualStyleBackColor = true;
            this.btMouse.Click += new System.EventHandler(this.btMouse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(829, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Waga X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(829, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Martwa Strefa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(829, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Waga Y";
            // 
            // numericUpDownMarkerThresh
            // 
            this.numericUpDownMarkerThresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDownMarkerThresh.Location = new System.Drawing.Point(916, 129);
            this.numericUpDownMarkerThresh.Name = "numericUpDownMarkerThresh";
            this.numericUpDownMarkerThresh.Size = new System.Drawing.Size(49, 32);
            this.numericUpDownMarkerThresh.TabIndex = 16;
            this.numericUpDownMarkerThresh.ValueChanged += new System.EventHandler(this.numericUpDownMarkerThresh_ValueChanged_1);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDown2.Location = new System.Drawing.Point(916, 175);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(49, 32);
            this.numericUpDown2.TabIndex = 17;
            this.numericUpDown2.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDown3.Location = new System.Drawing.Point(916, 222);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(49, 32);
            this.numericUpDown3.TabIndex = 18;
            this.numericUpDown3.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDown4.Location = new System.Drawing.Point(916, 272);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(49, 32);
            this.numericUpDown4.TabIndex = 19;
            this.numericUpDown4.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDown1.Location = new System.Drawing.Point(751, 187);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(49, 32);
            this.numericUpDown1.TabIndex = 20;
            this.numericUpDown1.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(667, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "przycisków (s)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(847, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Rozpiętość ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(670, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Czas reakcji ";
            // 
            // checkAmini
            // 
            this.checkAmini.AutoSize = true;
            this.checkAmini.Checked = true;
            this.checkAmini.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAmini.Location = new System.Drawing.Point(670, 237);
            this.checkAmini.Name = "checkAmini";
            this.checkAmini.Size = new System.Drawing.Size(113, 17);
            this.checkAmini.TabIndex = 24;
            this.checkAmini.Text = "Auto Minimalizacja";
            this.checkAmini.UseVisualStyleBackColor = true;
            this.checkAmini.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 504);
            this.Controls.Add(this.checkAmini);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDownMarkerThresh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btMouse);
            this.Controls.Add(this.labelMarkerData);
            this.Controls.Add(this.labelMarkerThresh);
            this.Controls.Add(this.checkBoxMarkerSmoothing);
            this.Controls.Add(this.checkBoxMarkerHighlight);
            this.Controls.Add(this.buttonMarkerAdd);
            this.Controls.Add(this.comboBoxCameras);
            this.Controls.Add(this.buttonCameraProperties);
            this.Controls.Add(this.pictureBoxDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FaceMouse";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMarkerThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDisplay;
        private System.Windows.Forms.Button buttonCameraProperties;
        private System.Windows.Forms.ComboBox comboBoxCameras;
        private System.Windows.Forms.Button buttonMarkerAdd;
        private System.Windows.Forms.CheckBox checkBoxMarkerHighlight;
        private System.Windows.Forms.CheckBox checkBoxMarkerSmoothing;
        private System.Windows.Forms.Label labelMarkerThresh;
        private System.Windows.Forms.RichTextBox labelMarkerData;
        private System.Windows.Forms.Button btMouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMarkerThresh;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkAmini;
    }
}

