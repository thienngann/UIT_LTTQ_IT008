using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           

        }     

        private void buttonCong_Click(object sender, EventArgs e)
        {
            float num1, num2;
            if (float.TryParse(textBox1.Text, out num1) && float.TryParse(textBox2.Text, out num2))
            {
                float res = num1 + num2;
                textBoxAns.Text = res.ToString();
            }
            else
                textBoxAns.Text = "ERROR";
        }

        private void buttonHieu_Click(object sender, EventArgs e)
        {
            float num1, num2;
            if (float.TryParse(textBox1.Text, out num1) && float.TryParse(textBox2.Text, out num2))
            {
                float res = num1 - num2;
                textBoxAns.Text = res.ToString();
            }
            else
                textBoxAns.Text = "ERROR";           
        }

        private void buttonNhan_Click(object sender, EventArgs e)
        {
            float num1, num2;
            if (float.TryParse(textBox1.Text, out num1) && float.TryParse(textBox2.Text, out num2))
            {
                float res = num1 * num2;
                textBoxAns.Text = res.ToString();
            }
            else
                textBoxAns.Text = "ERROR";
        }

        private void buttonChia_Click(object sender, EventArgs e)
        {
            float num1, num2;
            if (float.TryParse(textBox1.Text, out num1) && float.TryParse(textBox2.Text, out num2))
            {
                if (num2 == 0)
                    textBoxAns.Text = "ERROR";
                else
                {
                    float res = num1 / num2;
                    textBoxAns.Text = res.ToString();
                }
                
            }
            else
                textBoxAns.Text = "ERROR";        
           
        }
    }
}
