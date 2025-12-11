using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
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
            var shape = gbShape.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            if (shape == "Line")
                lines.Add(new MyLine { start = StartPoint, end = EndPoint, shape = shape, pen = new Pen (currentColor, int.Parse(textBox1.Text))});
            else
                lines.Add(new MyLine { start = StartPoint, end = EndPoint, shape = shape, brush = CreateBrush(StartPoint, EndPoint) });
            panel2.Invalidate();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int w = 1;
            foreach (MyLine line in lines)
            {                         
                switch (line.shape)
                {
                    case "Line":
                        g.DrawLine(line.pen,line.start, line.end);
                        break;
                    case "Ellipse":
                        g.FillEllipse(line.brush, CreateRectangle(line.start, line.end));
                        break;
                    case "Rectangle":
                        g.FillRectangle(line.brush, CreateRectangle(line.start, line.end));
                        break;
                }
            }

            if (IsDrawing)
            {                
                string shape = gbShape.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)?.Text;
                Brush brush = CreateBrush(StartPoint, EndPoint);              
                Rectangle rect = CreateRectangle(StartPoint, EndPoint);
                if (shape == "Line")
                { 
                    w = int.Parse(textBox1.Text);
                    g.DrawLine(new Pen(currentColor, w), StartPoint, EndPoint);
                }                   
                else if (shape == "Ellipse")
                    g.FillEllipse(brush, rect);
                else
                    g.FillRectangle(brush, rect);               
            }
        }
       
        private Rectangle CreateRectangle (Point a, Point b)
        {
            int x = Math.Min(a.X, b.X);
            int y = Math.Min(a.Y, b.Y);
            int w = Math.Abs(a.X - b.X);
            int h = Math.Abs(a.Y - b.Y);

            if (w == 0) w = 1;
            if (h == 0) h = 1;  

            return new Rectangle(x, y, w, h);
        }
        private Brush CreateBrush (Point a, Point b)
        {
            Rectangle rect = CreateRectangle(a, b);
            Brush brush;
            if (rbSolid.Checked)
                brush = new SolidBrush(Color.Green);
            else if (rbHash.Checked)
                brush = new HatchBrush(HatchStyle.Horizontal, Color.Blue, Color.Green);
            else if (rbLinear.Checked)
                brush = new LinearGradientBrush(rect, Color.Red, Color.Green, LinearGradientMode.Vertical);
            else
                brush = new TextureBrush(img);
            return brush;
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

            if (string.IsNullOrEmpty(textBox1.Text) && rbLine.Checked)
            {
                MessageBox.Show("Vui lòng chọn width");
                return false;
            }

            if (!rbTexture.Checked && !rbSolid.Checked && !rbHash.Checked && !rbLinear.Checked && (rbEllipse.Checked || rbRectangle.Checked))
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
        public string shape;
        public Brush brush;
        public Pen pen;
    }
}
