using System;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Mouse and Keyboard";
            this.KeyPreview = true;
            this.MouseClick += Form1_MouseClick;            
            this.KeyDown += Form1_KeyDown;            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {          
            if (e.Button == MouseButtons.Left)
                MessageBox.Show($"Bạn vừa nhận chuột trái. Tọa độ chuột là {e.X}; {e.Y}");                
            else if (e.Button == MouseButtons.Right)
                MessageBox.Show($"Bạn vừa nhận chuột phải. Tọa độ chuột là {e.X}; {e.Y}");
            else
                MessageBox.Show($"Bạn vừa nhận chuột giữa. Tọa độ chuột là {e.X}; {e.Y}");         
        }     
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show($"Keycode: {e.KeyCode}, KeyValue: {e.KeyValue}, KeyData:{e.KeyData}");           
        }       
    }
}
