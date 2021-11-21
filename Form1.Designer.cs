namespace AdvancedGraphics
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEditor = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btnShowAxis = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textShiftZ = new System.Windows.Forms.TextBox();
            this.textShiftY = new System.Windows.Forms.TextBox();
            this.textShiftX = new System.Windows.Forms.TextBox();
            this.buttonShift = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonScale = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textScaleZ = new System.Windows.Forms.TextBox();
            this.textScaleY = new System.Windows.Forms.TextBox();
            this.textScaleX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonRotate = new System.Windows.Forms.Button();
            this.selectAxis = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textAngle = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbPerspective = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.z_buffer = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonLoadTexture = new System.Windows.Forms.Button();
            this.buttonTexturing = new System.Windows.Forms.Button();
            this.buttonLighting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditor
            // 
            this.btnEditor.Location = new System.Drawing.Point(34, 7);
            this.btnEditor.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditor.Name = "btnEditor";
            this.btnEditor.Size = new System.Drawing.Size(163, 33);
            this.btnEditor.TabIndex = 0;
            this.btnEditor.TabStop = false;
            this.btnEditor.Text = "Плавающий горизонт";
            this.btnEditor.UseVisualStyleBackColor = true;
            this.btnEditor.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(15, 18);
            this.listBox.Margin = new System.Windows.Forms.Padding(2);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(191, 154);
            this.listBox.TabIndex = 1;
            this.listBox.TabStop = false;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // btnShowAxis
            // 
            this.btnShowAxis.Location = new System.Drawing.Point(35, 463);
            this.btnShowAxis.Margin = new System.Windows.Forms.Padding(1);
            this.btnShowAxis.Name = "btnShowAxis";
            this.btnShowAxis.Size = new System.Drawing.Size(163, 26);
            this.btnShowAxis.TabIndex = 27;
            this.btnShowAxis.TabStop = false;
            this.btnShowAxis.Text = "Показать оси";
            this.btnShowAxis.UseVisualStyleBackColor = true;
            this.btnShowAxis.Click += new System.EventHandler(this.btnShowAxis_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 202);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 202);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 202);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "Х:";
            // 
            // textShiftZ
            // 
            this.textShiftZ.Enabled = false;
            this.textShiftZ.Location = new System.Drawing.Point(169, 200);
            this.textShiftZ.Margin = new System.Windows.Forms.Padding(1);
            this.textShiftZ.MaxLength = 5;
            this.textShiftZ.Name = "textShiftZ";
            this.textShiftZ.Size = new System.Drawing.Size(36, 23);
            this.textShiftZ.TabIndex = 21;
            this.textShiftZ.TabStop = false;
            this.textShiftZ.Text = "0";
            // 
            // textShiftY
            // 
            this.textShiftY.Enabled = false;
            this.textShiftY.Location = new System.Drawing.Point(102, 200);
            this.textShiftY.Margin = new System.Windows.Forms.Padding(1);
            this.textShiftY.MaxLength = 5;
            this.textShiftY.Name = "textShiftY";
            this.textShiftY.Size = new System.Drawing.Size(36, 23);
            this.textShiftY.TabIndex = 22;
            this.textShiftY.TabStop = false;
            this.textShiftY.Text = "0";
            // 
            // textShiftX
            // 
            this.textShiftX.Enabled = false;
            this.textShiftX.Location = new System.Drawing.Point(35, 200);
            this.textShiftX.Margin = new System.Windows.Forms.Padding(1);
            this.textShiftX.MaxLength = 5;
            this.textShiftX.Name = "textShiftX";
            this.textShiftX.Size = new System.Drawing.Size(36, 23);
            this.textShiftX.TabIndex = 23;
            this.textShiftX.TabStop = false;
            this.textShiftX.Text = "0";
            // 
            // buttonShift
            // 
            this.buttonShift.Enabled = false;
            this.buttonShift.Location = new System.Drawing.Point(40, 221);
            this.buttonShift.Margin = new System.Windows.Forms.Padding(1);
            this.buttonShift.Name = "buttonShift";
            this.buttonShift.Size = new System.Drawing.Size(141, 26);
            this.buttonShift.TabIndex = 20;
            this.buttonShift.TabStop = false;
            this.buttonShift.Text = "Сместить";
            this.buttonShift.UseVisualStyleBackColor = true;
            this.buttonShift.Click += new System.EventHandler(this.buttonShift_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Right;
            this.canvas.Location = new System.Drawing.Point(231, 0);
            this.canvas.Margin = new System.Windows.Forms.Padding(1);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(944, 630);
            this.canvas.TabIndex = 19;
            this.canvas.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonScale);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.listBox);
            this.groupBox1.Controls.Add(this.textScaleZ);
            this.groupBox1.Controls.Add(this.textScaleY);
            this.groupBox1.Controls.Add(this.buttonShift);
            this.groupBox1.Controls.Add(this.textScaleX);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textShiftX);
            this.groupBox1.Controls.Add(this.buttonRotate);
            this.groupBox1.Controls.Add(this.selectAxis);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textAngle);
            this.groupBox1.Controls.Add(this.textShiftY);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textShiftZ);
            this.groupBox1.Location = new System.Drawing.Point(6, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(222, 365);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сцена";
            // 
            // buttonScale
            // 
            this.buttonScale.Enabled = false;
            this.buttonScale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonScale.Location = new System.Drawing.Point(40, 331);
            this.buttonScale.Margin = new System.Windows.Forms.Padding(1);
            this.buttonScale.Name = "buttonScale";
            this.buttonScale.Size = new System.Drawing.Size(141, 25);
            this.buttonScale.TabIndex = 32;
            this.buttonScale.Text = "Отмасштабировать";
            this.buttonScale.UseVisualStyleBackColor = true;
            this.buttonScale.Click += new System.EventHandler(this.buttonScale_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 312);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 15);
            this.label4.TabIndex = 40;
            this.label4.Text = "cZ:";
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::AdvancedGraphics.Properties.Resources.delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(80, 174);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(35, 23);
            this.btnDelete.TabIndex = 28;
            this.btnDelete.TabStop = false;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 310);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 41;
            this.label5.Text = "cY:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(119, 174);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 23);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Загрузить...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 312);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 15);
            this.label7.TabIndex = 42;
            this.label7.Text = "cХ:";
            // 
            // textScaleZ
            // 
            this.textScaleZ.Enabled = false;
            this.textScaleZ.Location = new System.Drawing.Point(172, 310);
            this.textScaleZ.Margin = new System.Windows.Forms.Padding(1);
            this.textScaleZ.MaxLength = 5;
            this.textScaleZ.Name = "textScaleZ";
            this.textScaleZ.Size = new System.Drawing.Size(33, 23);
            this.textScaleZ.TabIndex = 37;
            this.textScaleZ.Text = "1";
            // 
            // textScaleY
            // 
            this.textScaleY.Enabled = false;
            this.textScaleY.Location = new System.Drawing.Point(105, 310);
            this.textScaleY.Margin = new System.Windows.Forms.Padding(1);
            this.textScaleY.MaxLength = 5;
            this.textScaleY.Name = "textScaleY";
            this.textScaleY.Size = new System.Drawing.Size(36, 23);
            this.textScaleY.TabIndex = 38;
            this.textScaleY.Text = "1";
            // 
            // textScaleX
            // 
            this.textScaleX.Enabled = false;
            this.textScaleX.Location = new System.Drawing.Point(39, 310);
            this.textScaleX.Margin = new System.Windows.Forms.Padding(1);
            this.textScaleX.MaxLength = 5;
            this.textScaleX.Name = "textScaleX";
            this.textScaleX.Size = new System.Drawing.Size(36, 23);
            this.textScaleX.TabIndex = 39;
            this.textScaleX.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 254);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "Ось:";
            // 
            // buttonRotate
            // 
            this.buttonRotate.Enabled = false;
            this.buttonRotate.Location = new System.Drawing.Point(40, 274);
            this.buttonRotate.Margin = new System.Windows.Forms.Padding(1);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(141, 25);
            this.buttonRotate.TabIndex = 33;
            this.buttonRotate.Text = "Повернуть";
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotate_Click);
            // 
            // selectAxis
            // 
            this.selectAxis.Enabled = false;
            this.selectAxis.FormattingEnabled = true;
            this.selectAxis.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.selectAxis.Location = new System.Drawing.Point(172, 252);
            this.selectAxis.Margin = new System.Windows.Forms.Padding(1);
            this.selectAxis.Name = "selectAxis";
            this.selectAxis.Size = new System.Drawing.Size(33, 23);
            this.selectAxis.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 254);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "Угол:";
            // 
            // textAngle
            // 
            this.textAngle.Enabled = false;
            this.textAngle.Location = new System.Drawing.Point(55, 253);
            this.textAngle.Margin = new System.Windows.Forms.Padding(1);
            this.textAngle.MaxLength = 5;
            this.textAngle.Name = "textAngle";
            this.textAngle.Size = new System.Drawing.Size(41, 23);
            this.textAngle.TabIndex = 35;
            this.textAngle.Text = "0";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "3D модели|*.obj";
            this.openFileDialog1.InitialDirectory = "C:\\Code\\AdvancedGraphics\\shapes";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Текстуры|*.png";
            this.openFileDialog2.InitialDirectory = "C:\\Code\\AdvancedGraphics\\textures";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AdvancedGraphics.Properties.Resources._cc3333_0008e6_01bc0d_1920_1080;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(33, 461);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 30);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // rbPerspective
            // 
            this.rbPerspective.AutoSize = true;
            this.rbPerspective.BackColor = System.Drawing.SystemColors.Control;
            this.rbPerspective.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbPerspective.Checked = true;
            this.rbPerspective.Location = new System.Drawing.Point(34, 419);
            this.rbPerspective.Margin = new System.Windows.Forms.Padding(1);
            this.rbPerspective.Name = "rbPerspective";
            this.rbPerspective.Size = new System.Drawing.Size(165, 19);
            this.rbPerspective.TabIndex = 30;
            this.rbPerspective.TabStop = true;
            this.rbPerspective.Text = "Перспективная проекция";
            this.rbPerspective.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radioButton1.Location = new System.Drawing.Point(34, 439);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(1);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(128, 19);
            this.radioButton1.TabIndex = 30;
            this.radioButton1.Text = "Взгляд со стороны";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.rbParallel_CheckedChanged);
            // 
            // z_buffer
            // 
            this.z_buffer.Location = new System.Drawing.Point(35, 495);
            this.z_buffer.Margin = new System.Windows.Forms.Padding(2);
            this.z_buffer.Name = "z_buffer";
            this.z_buffer.Size = new System.Drawing.Size(164, 29);
            this.z_buffer.TabIndex = 31;
            this.z_buffer.Text = "Удалить невидимые";
            this.z_buffer.UseVisualStyleBackColor = true;
            this.z_buffer.Click += new System.EventHandler(this.z_buffer_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(238, 5);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(220, 45);
            this.label9.TabIndex = 32;
            this.label9.Text = "WASDQE - положение камеры\r\nIJKL - наклон камеры\r\nGVBNFH - положение источника све" +
    "та";
            // 
            // buttonLoadTexture
            // 
            this.buttonLoadTexture.Location = new System.Drawing.Point(35, 534);
            this.buttonLoadTexture.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadTexture.Name = "buttonLoadTexture";
            this.buttonLoadTexture.Size = new System.Drawing.Size(164, 25);
            this.buttonLoadTexture.TabIndex = 34;
            this.buttonLoadTexture.Text = "Загрузить текстуру";
            this.buttonLoadTexture.UseVisualStyleBackColor = true;
            this.buttonLoadTexture.Click += new System.EventHandler(this.buttonLoadTexture_Click);
            // 
            // buttonTexturing
            // 
            this.buttonTexturing.Location = new System.Drawing.Point(35, 562);
            this.buttonTexturing.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTexturing.Name = "buttonTexturing";
            this.buttonTexturing.Size = new System.Drawing.Size(164, 25);
            this.buttonTexturing.TabIndex = 35;
            this.buttonTexturing.Text = "Текстурировать";
            this.buttonTexturing.UseVisualStyleBackColor = true;
            // 
            // buttonLighting
            // 
            this.buttonLighting.Location = new System.Drawing.Point(35, 597);
            this.buttonLighting.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLighting.Name = "buttonLighting";
            this.buttonLighting.Size = new System.Drawing.Size(164, 25);
            this.buttonLighting.TabIndex = 38;
            this.buttonLighting.Text = "Добавить освещение";
            this.buttonLighting.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 630);
            this.Controls.Add(this.buttonLighting);
            this.Controls.Add(this.buttonTexturing);
            this.Controls.Add(this.buttonLoadTexture);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.z_buffer);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rbPerspective);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnShowAxis);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.btnEditor);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Просмотр сцены";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditor;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button btnShowAxis;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textShiftZ;
        private System.Windows.Forms.TextBox textShiftY;
        private System.Windows.Forms.TextBox textShiftX;
        private System.Windows.Forms.Button buttonShift;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbPerspective;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button z_buffer;
        private System.Windows.Forms.Button buttonScale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textScaleZ;
        private System.Windows.Forms.TextBox textScaleY;
        private System.Windows.Forms.TextBox textScaleX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonRotate;
        private System.Windows.Forms.ComboBox selectAxis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textAngle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonLoadTexture;
        private System.Windows.Forms.Button buttonTexturing;
        private System.Windows.Forms.Button buttonLighting;
    }
}