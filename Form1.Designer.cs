namespace GraphDrawer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DrawGraph = new Button();
            FunctionFill = new TextBox();
            pictureBox1 = new PictureBox();
            UpLimX = new NumericUpDown();
            DownLimX = new NumericUpDown();
            FuncText = new Label();
            LaTEXconv = new Button();
            Xtext = new Label();
            Ytext = new Label();
            DownLimY = new NumericUpDown();
            UpLimY = new NumericUpDown();
            PNGexport = new Button();
            JPEGexport = new Button();
            BMPexport = new Button();
            Instruction = new Button();
            label1 = new Label();
            numericUpDown2 = new NumericUpDown();
            label2 = new Label();
            checkBox1 = new CheckBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpLimX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DownLimX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DownLimY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpLimY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // DrawGraph
            // 
            DrawGraph.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DrawGraph.Location = new Point(672, 427);
            DrawGraph.Name = "DrawGraph";
            DrawGraph.Size = new Size(150, 25);
            DrawGraph.TabIndex = 1;
            DrawGraph.Text = "Нарисовать";
            DrawGraph.UseVisualStyleBackColor = true;
            DrawGraph.Click += DrawGraph_Click;
            // 
            // FunctionFill
            // 
            FunctionFill.Location = new Point(105, 427);
            FunctionFill.Name = "FunctionFill";
            FunctionFill.Size = new Size(400, 23);
            FunctionFill.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(650, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // UpLimX
            // 
            UpLimX.DecimalPlaces = 2;
            UpLimX.Location = new Point(672, 148);
            UpLimX.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            UpLimX.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            UpLimX.Name = "UpLimX";
            UpLimX.Size = new Size(150, 23);
            UpLimX.TabIndex = 8;
            UpLimX.TextAlign = HorizontalAlignment.Center;
            UpLimX.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // DownLimX
            // 
            DownLimX.DecimalPlaces = 2;
            DownLimX.Location = new Point(672, 177);
            DownLimX.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            DownLimX.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            DownLimX.Name = "DownLimX";
            DownLimX.Size = new Size(150, 23);
            DownLimX.TabIndex = 9;
            DownLimX.TextAlign = HorizontalAlignment.Center;
            DownLimX.Value = new decimal(new int[] { 10, 0, 0, int.MinValue });
            // 
            // FuncText
            // 
            FuncText.AutoSize = true;
            FuncText.Font = new Font("Segoe UI", 13F, FontStyle.Italic, GraphicsUnit.Point);
            FuncText.Location = new Point(12, 425);
            FuncText.Name = "FuncText";
            FuncText.Size = new Size(87, 25);
            FuncText.TabIndex = 12;
            FuncText.Text = "Функция:";
            // 
            // LaTEXconv
            // 
            LaTEXconv.BackColor = SystemColors.InactiveCaption;
            LaTEXconv.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LaTEXconv.Location = new Point(537, 427);
            LaTEXconv.Name = "LaTEXconv";
            LaTEXconv.Size = new Size(125, 25);
            LaTEXconv.TabIndex = 13;
            LaTEXconv.Text = "LaTEX конвертер";
            LaTEXconv.UseVisualStyleBackColor = false;
            LaTEXconv.Click += LaTEXconv_Click;
            // 
            // Xtext
            // 
            Xtext.AutoSize = true;
            Xtext.Location = new Point(693, 130);
            Xtext.Name = "Xtext";
            Xtext.Size = new Size(116, 15);
            Xtext.TabIndex = 14;
            Xtext.Text = "Пределы абцисс (х)";
            // 
            // Ytext
            // 
            Ytext.AutoSize = true;
            Ytext.Location = new Point(691, 9);
            Ytext.Name = "Ytext";
            Ytext.Size = new Size(122, 15);
            Ytext.TabIndex = 17;
            Ytext.Text = "Пределы ординат (у)";
            // 
            // DownLimY
            // 
            DownLimY.DecimalPlaces = 2;
            DownLimY.Location = new Point(676, 56);
            DownLimY.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            DownLimY.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            DownLimY.Name = "DownLimY";
            DownLimY.Size = new Size(150, 23);
            DownLimY.TabIndex = 16;
            DownLimY.TextAlign = HorizontalAlignment.Center;
            DownLimY.Value = new decimal(new int[] { 10, 0, 0, int.MinValue });
            // 
            // UpLimY
            // 
            UpLimY.DecimalPlaces = 2;
            UpLimY.Location = new Point(676, 27);
            UpLimY.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            UpLimY.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            UpLimY.Name = "UpLimY";
            UpLimY.Size = new Size(150, 23);
            UpLimY.TabIndex = 15;
            UpLimY.TextAlign = HorizontalAlignment.Center;
            UpLimY.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // PNGexport
            // 
            PNGexport.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PNGexport.Location = new Point(672, 335);
            PNGexport.Name = "PNGexport";
            PNGexport.Size = new Size(49, 25);
            PNGexport.TabIndex = 18;
            PNGexport.Text = "PNG";
            PNGexport.UseVisualStyleBackColor = true;
            PNGexport.Click += PNGexport_Click;
            // 
            // JPEGexport
            // 
            JPEGexport.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            JPEGexport.Location = new Point(727, 335);
            JPEGexport.Name = "JPEGexport";
            JPEGexport.Size = new Size(40, 25);
            JPEGexport.TabIndex = 19;
            JPEGexport.Text = "JPEG";
            JPEGexport.UseVisualStyleBackColor = true;
            JPEGexport.Click += JPEGexport_Click;
            // 
            // BMPexport
            // 
            BMPexport.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BMPexport.Location = new Point(773, 335);
            BMPexport.Name = "BMPexport";
            BMPexport.Size = new Size(49, 25);
            BMPexport.TabIndex = 20;
            BMPexport.Text = "BMP";
            BMPexport.UseVisualStyleBackColor = true;
            BMPexport.Click += BMPexport_Click;
            // 
            // Instruction
            // 
            Instruction.FlatStyle = FlatStyle.System;
            Instruction.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Instruction.Location = new Point(672, 381);
            Instruction.Name = "Instruction";
            Instruction.Size = new Size(150, 25);
            Instruction.TabIndex = 21;
            Instruction.Text = "Инструкция";
            Instruction.UseVisualStyleBackColor = true;
            Instruction.Click += Instruction_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(693, 213);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 24;
            label1.Text = "Шаг изменения (х)";
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 4;
            numericUpDown2.Location = new Point(672, 231);
            numericUpDown2.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1024, 0, 0, int.MinValue });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(150, 23);
            numericUpDown2.TabIndex = 22;
            numericUpDown2.TextAlign = HorizontalAlignment.Center;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 262144 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(685, 257);
            label2.Name = "label2";
            label2.Size = new Size(124, 36);
            label2.TabIndex = 25;
            label2.Text = "Не ставьте слишком\r\nмаленькое значение \r\nдля быстрой компиляции";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(685, 85);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(134, 19);
            checkBox1.TabIndex = 26;
            checkBox1.Text = "Автоопределение Y";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(711, 307);
            label3.Name = "label3";
            label3.Size = new Size(69, 21);
            label3.TabIndex = 27;
            label3.Text = "Экспорт";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(834, 461);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown2);
            Controls.Add(Instruction);
            Controls.Add(BMPexport);
            Controls.Add(JPEGexport);
            Controls.Add(PNGexport);
            Controls.Add(Ytext);
            Controls.Add(DownLimY);
            Controls.Add(UpLimY);
            Controls.Add(Xtext);
            Controls.Add(LaTEXconv);
            Controls.Add(FuncText);
            Controls.Add(DownLimX);
            Controls.Add(UpLimX);
            Controls.Add(pictureBox1);
            Controls.Add(FunctionFill);
            Controls.Add(DrawGraph);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Построение графика функций GraphDraw v1.0 beta";
            Load += Form1_Load;
            Move += Form1_Move;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpLimX).EndInit();
            ((System.ComponentModel.ISupportInitialize)DownLimX).EndInit();
            ((System.ComponentModel.ISupportInitialize)DownLimY).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpLimY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button DrawGraph;
        private TextBox FunctionFill;
        private PictureBox pictureBox1;
        private NumericUpDown UpLimX;
        private NumericUpDown DownLimX;
        private Label FuncText;
        private Button LaTEXconv;
        private Label Xtext;
        private Label Ytext;
        private NumericUpDown DownLimY;
        private NumericUpDown UpLimY;
        private Button PNGexport;
        private Button JPEGexport;
        private Button BMPexport;
        private Button Instruction;
        private Label label1;
        private NumericUpDown numericUpDown2;
        private Label label2;
        private CheckBox checkBox1;
        private Label label3;
    }
}