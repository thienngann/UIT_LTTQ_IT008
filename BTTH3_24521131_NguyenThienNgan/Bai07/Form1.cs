using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai07
{
    public partial class Form1 : Form
    {
        private float Sum = 0;
        private List<Button> btns = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            textBoxMoney.Text = Sum.ToString();
            foreach (Control ctrl in tableLayoutPanel2.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Click += AllButtons_Click;
                }
            }
        }

        private void AllButtons_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor == Color.Yellow)
                MessageBox.Show("Vị trí này đã được bán");
            else if (btn.BackColor == SystemColors.ControlLightLight)
            {
                btn.BackColor = SystemColors.Highlight;
                btns.Add(btn);
            }
            else if (btn.BackColor == SystemColors.Highlight)
            {
                btn.BackColor = SystemColors.ControlLightLight;
                btns.Remove(btn);
            }
            Sum = 0;
            foreach (var b in btns)
            {
                switch (b.Text)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                        Sum += 5000;
                        break;
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                        Sum += 6500;
                        break;
                    case "11":
                    case "12":
                    case "13":
                    case "14":
                    case "15":
                        Sum += 8000;
                        break;
                }
            }
            textBoxMoney.Text = Sum.ToString();
        }

        private void buttonChon_Click(object sender, EventArgs e)
        {
            if (btns.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn vị trí");
                return;
            }
            string temp = "";
            foreach (var btn in btns)
            {
                temp += $"ghế số {btn.Text}, ";
                btn.BackColor = Color.Yellow;

            }
            MessageBox.Show($"Bạn đã chọn mua {temp}\nTổng tiền: {Sum}");

            btns.Clear();
            Sum = 0;
            textBoxMoney.Text = Sum.ToString();
        }

        private void buttonHuyBo_Click(object sender, EventArgs e)
        {
            if (btns.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn vị trí");
                return;
            }
            foreach (var btn in btns)
                btn.BackColor = SystemColors.ControlLightLight;
            btns.Clear();
            Sum = 0;
            textBoxMoney.Text = Sum.ToString();
        }

        private void buttonKetThuc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
