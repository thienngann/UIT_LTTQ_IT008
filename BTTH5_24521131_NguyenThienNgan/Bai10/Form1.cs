using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Bai10
{
    public partial class Form1 : Form
    {
        List<MyLine> lines = new List<MyLine>();
        Point startPoint;
        Point endPoint;
        bool isDrawing = false;
        public Form1()
        {
            InitializeComponent();  
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
        private Pen CreatePen()
        {
           // Graphics g = e.Graphics;
            if (string.IsNullOrEmpty(cbDashStyle.Text) ||
               string.IsNullOrEmpty(cbLineJoin.Text) ||
               string.IsNullOrEmpty(cbDashCap.Text) ||
               string.IsNullOrEmpty(cbStartCap.Text) ||
               string.IsNullOrEmpty(cbEndCap.Text) ||
               string.IsNullOrEmpty(cbWidth.Text))
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin");
                    return null;
                }

            string dashstyle = cbDashStyle.Text;
            int width = int.Parse(cbWidth.Text);
            string linejoin = cbLineJoin.Text;
            string dashcap = cbDashCap.Text;
            string startcap = cbStartCap.Text;
            string endcap = cbEndCap.Text;

            Pen pen = new Pen (Color.Red, width);                       
            switch (dashstyle)
            {
                case "Solid":
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; break;
                case "Dot":
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot; break;
                case "Dash":
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; break;
                case "Dash Dot":
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot; break;
                case "Dash Dot Dot":
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot; break;
                case "Custom":
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom; break;
                default:
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; break;
            }

            switch (linejoin)
            {
                case "Miter":
                    pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Miter; break;
                case "Miter Clipped":
                    pen.LineJoin = System.Drawing.Drawing2D.LineJoin.MiterClipped; break;
                case "Bevel":
                    pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel; break;
                case "Round":
                    pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round; break;            
                default:
                    pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round; break;
            }

            switch (dashcap)
            {
                case "Triangle":
                    pen.DashCap = System.Drawing.Drawing2D.DashCap.Triangle; break;
                case "Round":
                    pen.DashCap = System.Drawing.Drawing2D.DashCap.Round; break;
                case "Flat":
                    pen.DashCap = System.Drawing.Drawing2D.DashCap.Flat; break;               
                default:
                    pen.DashCap = System.Drawing.Drawing2D.DashCap.Flat; break;
            }

            switch (startcap)
            {
                case "Triangle":
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.Triangle; break;
                case "Round":
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.Round; break;
                case "Flat":
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.Flat; break;
                case "Square":
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.Square; break;
                default:
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.Flat; break;
            }

            switch (endcap)
            {
                case "Triangle":
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.Triangle; break;
                case "Round":
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.Round; break;
                case "Flat":
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.Flat; break;
                case "Square":
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.Square; break;
                default:
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.Flat; break;
            }
            return pen;
         
        }
      
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startPoint = e.Location;
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                endPoint = e.Location;
                //panel2.Invalidate();
                panel2.Invalidate(new Rectangle(
                                Math.Min(startPoint.X, endPoint.X) - 20,
                                Math.Min(startPoint.Y, endPoint.Y) - 20,
                                Math.Abs(endPoint.X - startPoint.X) + 40,
                                Math.Abs(endPoint.Y - startPoint.Y) + 40));

            }
        }
        private void panel2_MouseUp (object sender, MouseEventArgs e)
        {
            isDrawing = false;
            endPoint = e.Location;
            Pen pen = CreatePen();
            if (pen == null) return;
            lines.Add(new MyLine { Start = startPoint, End = endPoint, Pen = pen });
            panel2.Invalidate();
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (MyLine line in lines)
            {
                g.DrawLine(line.Pen, line.Start, line.End);
            }

            if (isDrawing)
            {
                Pen pen = CreatePen();
                if (pen == null) return;
                g.DrawLine(pen, startPoint, endPoint);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            lines.Clear();
            panel2.Invalidate();
        }
    }
    class MyLine
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public Pen Pen { get; set; }
    }
}
