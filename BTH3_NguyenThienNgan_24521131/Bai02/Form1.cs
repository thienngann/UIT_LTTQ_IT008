using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Bai02
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Paint Event";
            this.Paint += Form1_Paint;
        }       

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Color color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Font font = this.Font;
            string text = "Paint Event";
            SizeF textsize = g.MeasureString(text,font);
            int maxX = (int)(this.ClientSize.Width - textsize.Width);
            int maxY = (int)(this.ClientSize.Height - textsize.Height);
            Point position = new Point(rnd.Next(0, maxX + 1), rnd.Next(0, maxY + 1));

            using (Brush brush = new SolidBrush(color))
            {
                g.DrawString("Paint Event",font, brush, position);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {            
            this.Refresh();            
        }
      
    }
}
