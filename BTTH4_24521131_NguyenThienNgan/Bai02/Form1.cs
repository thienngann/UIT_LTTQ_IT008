using System;
using System.Globalization;
using System.Windows.Forms;

namespace Bai02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Simple Clock";            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
        }
    }
}
