using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Bai11
{
    public partial class Form1 : Form
    {
        List<MyLine> lines = new List<MyLine>();
        Point StartPoint;
        Point EndPoint;
        bool IsDrawing;
        Color currentColor = Color.White;
        Image img = Image.FromFile("Asset/Texture.jpg");
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            panel2.MouseDown += Mouse_Down;
            panel2.MouseMove += Mouse_Move;
            panel2.MouseUp += Mouse_Up;
            panel2.Paint += panel2_Paint;
            
        }

        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            if (!ValidateSelections())
                return;
            IsDrawing = true;
            StartPoint = e.Location;
        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (IsDrawing)
            {
                EndPoint = e.Location;
                panel2.Invalidate(new Rectangle(Math.Min(StartPoint.X, EndPoint.X) -20, Math.Min(StartPoint.Y, EndPoint.Y)-20, 
                                                Math.Abs(StartPoint.X - EndPoint.X) + 40,Math.Abs(StartPoint.Y - EndPoint.Y)+40));
            }
        }

        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            IsDrawing = false;
            EndPoint = e.Location;
            ItemDrawing item = CreateItem();
            if (item == null) return;
            lines.Add(new MyLine { start = StartPoint, end = EndPoint, itemdrawing = item});
            panel2.Invalidate();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (MyLine line in lines)
            {
                Brush brush = Brushes.Black;
               
                switch (line.itemdrawing.shape)
                {
                    case "Line":
                        g.DrawLine(line.itemdrawing.pen, line.start, line.end);
                        break;
                    case "Ellipse":
                        g.FillEllipse(line.itemdrawing.brush, new Rectangle(Math.Min(line.start.X, line.end.X), Math.Min(line.start.Y, line.end.Y) ,
                                                Math.Abs(line.start.X - line.end.X), Math.Abs(line.start.Y - line.end.Y)));
                        break;
                    case "Rectangle":   
                        g.FillRectangle(line.itemdrawing.brush, new Rectangle(Math.Min(line.start.X, line.end.X), Math.Min(line.start.Y, line.end.Y),
                                              Math.Abs(line.start.X - line.end.X), Math.Abs(line.start.Y - line.end.Y)));
                        break;
                }
            }

            if (IsDrawing)
            {
                int w = int.Parse(textBox1.Text);
                string shape = gbShape.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)?.Text;
                Brush brush;
                if (rbSolid.Checked)
                    brush = new SolidBrush(currentColor);
                else if (rbHash.Checked)
                    brush = new HatchBrush(HatchStyle.Cross, currentColor, Color.White);
                else if (rbLinear.Checked)
                    brush = new LinearGradientBrush(StartPoint, EndPoint, currentColor, Color.White);
                else
                    brush = new TextureBrush(img);
                Rectangle rect = new Rectangle(Math.Min(StartPoint.X, EndPoint.X),
                                                Math.Min(StartPoint.Y, EndPoint.Y),
                                                Math.Abs(StartPoint.X - EndPoint.X),
                                                Math.Abs(StartPoint.Y - EndPoint.Y));
                if (shape == "Line")
                    g.DrawLine(new Pen(currentColor, w), StartPoint, EndPoint);
                else if (shape == "Ellipse")
                    g.FillEllipse(brush, rect);
                else
                    g.FillRectangle(brush, rect);               
            }
        }
        private ItemDrawing CreateItem()
        {
            ColorDialog colorDialog = new ColorDialog();
                      
            var shape = gbShape.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            Brush brush;
            if (rbSolid.Checked)
                brush = new SolidBrush(currentColor);
            else if (rbHash.Checked)
                brush = new HatchBrush(HatchStyle.Cross, currentColor, Color.White);
            else if (rbLinear.Checked)
                brush = new LinearGradientBrush(StartPoint, EndPoint, currentColor, Color.White);
            else
                brush = new TextureBrush(img);

            Pen p = new Pen(currentColor, float.Parse(textBox1.Text));          
            return new ItemDrawing
            {
                pen = p,
                brush = brush,
                shape = shape
            };
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                currentColor = colorDialog.Color;
        }
        private bool ValidateSelections()
        {
            if (!rbEllipse.Checked && !rbLine.Checked && !rbRectangle.Checked)
            {
                MessageBox.Show("Vui lòng chọn shape");
                return false;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn width");
                return false;
            }

            if (!rbTexture.Checked && !rbSolid.Checked && !rbHash.Checked && !rbLinear.Checked)
            {
                MessageBox.Show("Vui lòng chọn brush");
                return false;
            }

            return true;
        }

    }
    class MyLine
    {
        public Point start;
        public Point end;
        public ItemDrawing itemdrawing;        
    }

    class ItemDrawing
    {
        public Pen pen;
        public Brush brush;
        public string shape;       
    }


}
