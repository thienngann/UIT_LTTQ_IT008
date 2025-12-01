using System;
using System.Globalization;
using System.Windows.Forms;


namespace Bai03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Chương tình Windows Media";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("dd/MMMM/yyyy", CultureInfo.InvariantCulture);
            string time = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
            toolStripStatusLabel1.Text = $"Hôm nay là ngày {date} - Bây giờ là {time}";
            statusStrip1.Items.Add(toolStripStatusLabel1);
        }     

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media Files | *.avi; *.mpeg; *.wav; *.midi; *.mp4; *.mp3";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer1.URL = openFileDialog.FileName;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }

        }
    }
}
