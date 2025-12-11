using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;
            this.Width = 600;
            this.Height = 600;

            Timer t = new Timer();
            t.Interval = 1000;
            t.Tick += (s, e) => this.Invalidate();
            t.Start();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cx = Width / 2;
            int cy = Height / 2;
            int radius = Math.Min(cx, cy) - 50;

            // --- Vẽ 60 chấm
            for (int i = 0; i < 60; i++)
            {
                double angle = i * Math.PI / 30;
                int r = (i % 5 == 0) ? 10 : 4;  // chấm lớn cho giờ
                int x = cx + (int)(Math.Cos(angle) * (radius - 10));
                int y = cy + (int)(Math.Sin(angle) * (radius - 10));
                g.FillEllipse(Brushes.White, x - r, y - r, r * 2, r * 2);
            }

            // Lấy thời gian
            DateTime now = DateTime.Now;
           
            DrawHand(g, now.Hour * 30 + now.Minute * 0.5, radius * 0.5, 6);            
            DrawHand(g, now.Minute * 6, radius * 0.75, 4);
            DrawHand(g, now.Second * 6, radius * 0.85, 2);
        }

        void DrawHand(Graphics g, double angleDeg, double length, int thickness)
        {
            double angle = (Math.PI / 180) * (angleDeg - 90);
            int cx = Width / 2;
            int cy = Height / 2;

            int x = cx + (int)(Math.Cos(angle) * length);
            int y = cy + (int)(Math.Sin(angle) * length);

            using (Pen p = new Pen(Color.White, thickness))
            {
                p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                g.DrawLine(p, cx, cy, x, y);
            }
        }

    }
}
