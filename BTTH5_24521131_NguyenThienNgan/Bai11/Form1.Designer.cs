namespace Bai11
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbBrushes = new System.Windows.Forms.GroupBox();
            this.rbLinear = new System.Windows.Forms.RadioButton();
            this.rbTexture = new System.Windows.Forms.RadioButton();
            this.rbHash = new System.Windows.Forms.RadioButton();
            this.rbSolid = new System.Windows.Forms.RadioButton();
            this.gbPen = new System.Windows.Forms.GroupBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbShape = new System.Windows.Forms.GroupBox();
            this.rbEllipse = new System.Windows.Forms.RadioButton();
            this.rbRectangle = new System.Windows.Forms.RadioButton();
            this.rbLine = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbBrushes.SuspendLayout();
            this.gbPen.SuspendLayout();
            this.gbShape.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1100, 836);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(415, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(682, 830);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.gbBrushes);
            this.panel1.Controls.Add(this.gbPen);
            this.panel1.Controls.Add(this.gbShape);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 830);
            this.panel1.TabIndex = 0;
            // 
            // gbBrushes
            // 
            this.gbBrushes.Controls.Add(this.rbLinear);
            this.gbBrushes.Controls.Add(this.rbTexture);
            this.gbBrushes.Controls.Add(this.rbHash);
            this.gbBrushes.Controls.Add(this.rbSolid);
            this.gbBrushes.Location = new System.Drawing.Point(28, 417);
            this.gbBrushes.Name = "gbBrushes";
            this.gbBrushes.Size = new System.Drawing.Size(319, 242);
            this.gbBrushes.TabIndex = 2;
            this.gbBrushes.TabStop = false;
            this.gbBrushes.Text = "Brushes";
            // 
            // rbLinear
            // 
            this.rbLinear.AutoSize = true;
            this.rbLinear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLinear.Location = new System.Drawing.Point(54, 180);
            this.rbLinear.Name = "rbLinear";
            this.rbLinear.Size = new System.Drawing.Size(201, 26);
            this.rbLinear.TabIndex = 3;
            this.rbLinear.TabStop = true;
            this.rbLinear.Text = "LinearGradientBrush";
            this.rbLinear.UseVisualStyleBackColor = true;
            // 
            // rbTexture
            // 
            this.rbTexture.AutoSize = true;
            this.rbTexture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTexture.Location = new System.Drawing.Point(54, 133);
            this.rbTexture.Name = "rbTexture";
            this.rbTexture.Size = new System.Drawing.Size(144, 26);
            this.rbTexture.TabIndex = 2;
            this.rbTexture.TabStop = true;
            this.rbTexture.Text = "TextureBrush";
            this.rbTexture.UseVisualStyleBackColor = true;
            // 
            // rbHash
            // 
            this.rbHash.AutoSize = true;
            this.rbHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHash.Location = new System.Drawing.Point(54, 83);
            this.rbHash.Name = "rbHash";
            this.rbHash.Size = new System.Drawing.Size(129, 26);
            this.rbHash.TabIndex = 1;
            this.rbHash.TabStop = true;
            this.rbHash.Text = "HatchBrush";
            this.rbHash.UseVisualStyleBackColor = true;
            // 
            // rbSolid
            // 
            this.rbSolid.AutoSize = true;
            this.rbSolid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSolid.Location = new System.Drawing.Point(54, 38);
            this.rbSolid.Name = "rbSolid";
            this.rbSolid.Size = new System.Drawing.Size(122, 26);
            this.rbSolid.TabIndex = 0;
            this.rbSolid.TabStop = true;
            this.rbSolid.Text = "SolidBrush";
            this.rbSolid.UseVisualStyleBackColor = true;
            // 
            // gbPen
            // 
            this.gbPen.Controls.Add(this.btnColor);
            this.gbPen.Controls.Add(this.textBox1);
            this.gbPen.Controls.Add(this.label1);
            this.gbPen.Location = new System.Drawing.Point(28, 214);
            this.gbPen.Name = "gbPen";
            this.gbPen.Size = new System.Drawing.Size(319, 175);
            this.gbPen.TabIndex = 1;
            this.gbPen.TabStop = false;
            this.gbPen.Text = "Pen";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(76, 106);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(133, 41);
            this.btnColor.TabIndex = 2;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            // 
            // gbShape
            // 
            this.gbShape.Controls.Add(this.rbEllipse);
            this.gbShape.Controls.Add(this.rbRectangle);
            this.gbShape.Controls.Add(this.rbLine);
            this.gbShape.Location = new System.Drawing.Point(28, 21);
            this.gbShape.Name = "gbShape";
            this.gbShape.Size = new System.Drawing.Size(319, 165);
            this.gbShape.TabIndex = 0;
            this.gbShape.TabStop = false;
            this.gbShape.Text = "Shape";
            // 
            // rbEllipse
            // 
            this.rbEllipse.AutoSize = true;
            this.rbEllipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEllipse.Location = new System.Drawing.Point(54, 119);
            this.rbEllipse.Name = "rbEllipse";
            this.rbEllipse.Size = new System.Drawing.Size(88, 26);
            this.rbEllipse.TabIndex = 2;
            this.rbEllipse.TabStop = true;
            this.rbEllipse.Text = "Ellipse";
            this.rbEllipse.UseVisualStyleBackColor = true;
            // 
            // rbRectangle
            // 
            this.rbRectangle.AutoSize = true;
            this.rbRectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRectangle.Location = new System.Drawing.Point(54, 76);
            this.rbRectangle.Name = "rbRectangle";
            this.rbRectangle.Size = new System.Drawing.Size(116, 26);
            this.rbRectangle.TabIndex = 1;
            this.rbRectangle.TabStop = true;
            this.rbRectangle.Text = "Rectangle";
            this.rbRectangle.UseVisualStyleBackColor = true;
            // 
            // rbLine
            // 
            this.rbLine.AutoSize = true;
            this.rbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLine.Location = new System.Drawing.Point(54, 34);
            this.rbLine.Name = "rbLine";
            this.rbLine.Size = new System.Drawing.Size(69, 26);
            this.rbLine.TabIndex = 0;
            this.rbLine.TabStop = true;
            this.rbLine.Text = "Line";
            this.rbLine.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 836);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbBrushes.ResumeLayout(false);
            this.gbBrushes.PerformLayout();
            this.gbPen.ResumeLayout(false);
            this.gbPen.PerformLayout();
            this.gbShape.ResumeLayout(false);
            this.gbShape.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbBrushes;
        private System.Windows.Forms.RadioButton rbTexture;
        private System.Windows.Forms.RadioButton rbHash;
        private System.Windows.Forms.RadioButton rbSolid;
        private System.Windows.Forms.GroupBox gbShape;
        private System.Windows.Forms.RadioButton rbEllipse;
        private System.Windows.Forms.RadioButton rbRectangle;
        private System.Windows.Forms.RadioButton rbLine;
        private System.Windows.Forms.GroupBox gbPen;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.RadioButton rbLinear;
    }
}

