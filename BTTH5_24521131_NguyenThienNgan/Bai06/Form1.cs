using System.Drawing;
using System.Windows.Forms;

namespace Bai06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (FontFamily f in FontFamily.Families)
            {                   
                listBox1.Items.Add(f.Name);
            }
            this.Text = "All Fonts";          
            listBox1.DrawItem += ListBox1_DrawItem;

        }
        public void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            string fontName = listBox1.Items[e.Index].ToString();
            Font font;
            try
            {
                font = new Font(fontName, 12);
            }
            catch
            {
                font = e.Font;
            }              

            e.DrawBackground();
            e.Graphics.DrawString(fontName, font, Brushes.Black, e.Bounds);          
            
        }
    }
}
