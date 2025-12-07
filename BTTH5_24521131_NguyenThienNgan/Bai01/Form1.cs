using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Form1 : Form
    {
        /*private Font font;
        private C*/
        StringFormat strFormat = new StringFormat();
        public Form1()
        {
            InitializeComponent();          
            foreach (FontFamily f in FontFamily.Families)
            {
                comboBoxFont.Items.Add(f.Name);
            }
            int[] size = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int i in size)
            {
                comboBoxSize.Items.Add(i);
            }    

            comboBoxFont.SelectedIndex = 353;
            comboBoxSize.SelectedIndex = 5;
            richTextBox1.Font = new Font("Tahoma", 14);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
                button1.BackColor = colorDialog1.Color;
            } 
                
        }

        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFont.SelectedItem == null || comboBoxSize.SelectedItem == null) return;          
            
           richTextBox1.Font = new Font(comboBoxFont.SelectedItem.ToString(), (int)comboBoxSize.SelectedItem, FontStyle.Regular);            
        }

        private void comboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSize.SelectedItem == null || comboBoxFont.SelectedItem == null) return;          
            richTextBox1.Font = new Font(comboBoxFont.SelectedItem.ToString(), (int)comboBoxSize.SelectedItem, FontStyle.Regular);
        }
        private void UpdateStyle(FontStyle style)
        {
            FontStyle oldStyle = richTextBox1.Font.Style;
            FontStyle newStyle;
            if (!oldStyle.HasFlag(style))
            {
                newStyle = oldStyle | style;
            }
            else
                newStyle = oldStyle & ~ style;
            richTextBox1.Font = new Font(comboBoxFont.SelectedItem.ToString(), (int)comboBoxSize.SelectedItem, newStyle);
        }

        private void checkBoxBold_CheckedChanged(object sender, EventArgs e)
        {
           UpdateStyle(FontStyle.Bold);
        }

        private void checkBoxItalic_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStyle(FontStyle.Italic);
        }

        private void checkBoxUnderline_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStyle(FontStyle.Underline);
        }   

        private void radioButtonLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            }
        }

        private void radioButtonCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        private void radioButtonRight_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            }
        }
    }
}
