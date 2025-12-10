using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "Select Shape";
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            string type = comboBox1.SelectedItem?.ToString();
            if (type == null) return;
            switch (type)
            {
                case "Circle":
                    g.DrawEllipse(Pens.Blue, new Rectangle(100,30,200,200));
                    break;
                case "Square":
                    g.DrawRectangle(Pens.Blue, new Rectangle(100, 30, 200, 200));
                    break;
                case "Ellipse":
                    g.DrawEllipse(Pens.Blue, new Rectangle(100, 30, 300, 200));
                    break;
                case "Pie":
                    g.DrawPie(Pens.Blue, new Rectangle(100,30,200,200), 0, -90);
                    break;
                case "Filled Circle":
                    g.FillEllipse(Brushes.Blue, new Rectangle(100, 30, 200, 200));
                    break;
                case "Filled Square":
                    g.FillRectangle(Brushes.Blue, new Rectangle(100, 30, 200, 200));
                    break;
                case "Filled Ellipse":
                    g.FillEllipse(Brushes.Blue, new Rectangle(100, 30, 300, 200));
                    break;
                case "Filled Pie":
                    g.FillPie(Brushes.Blue, new Rectangle(100, 30, 200, 200), 0, -90);
                    break;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel.Invalidate();
        }
    }
}
