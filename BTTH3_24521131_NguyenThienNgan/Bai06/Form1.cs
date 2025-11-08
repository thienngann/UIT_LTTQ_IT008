using System;
using System.Data;
using System.Windows.Forms;

namespace Bai06
{
    public partial class Form1 : Form
    {
        double MemoryValue = 0;
        public Form1()
        {
            InitializeComponent();
            buttonMR.Enabled = false;
            buttonMC.Enabled = false;

        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
            textBox1.Select(textBox1.Text.Length, 0);
        }

        private void button_CLick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text += btn.Text;

        }

        private void buttonBang_Click(object sender, EventArgs e)
        {
            try
            {
                string s = textBox1.Text;
                double result = Convert.ToDouble(new DataTable().Compute(s, ""));

                if (double.IsInfinity(result) || double.IsNaN(result))
                {
                    textBox1.Text = "ERROR!!!";
                }
                else
                {
                    textBox1.Text = result.ToString();
                }
            }
            catch
            {
                textBox1.Text = "ERROR!!!";
            }

        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            if (s.Length == 0) return;
            int index = Math.Max(s.LastIndexOf('+'), Math.Max(s.LastIndexOf('-'),
                        Math.Max(s.LastIndexOf('*'), Math.Max(s.LastIndexOf('/'), -1))));
            if (index >= 0 && index < s.Length - 1)
            {
                if (s[index - 1] == '+' || s[index - 1] == '-' || s[index - 1] == '*' || s[index - 1] == '/')
                    textBox1.Text = s.Substring(0, index);
                else textBox1.Text = s.Substring(0, index + 1);
            }

            else
            {
                textBox1.Clear();
            }
        }

        private void buttonPhantram_Click(object sender, EventArgs e)
        {
            try
            {
                string s = textBox1.Text;
                int index = Math.Max(s.LastIndexOf('+'), Math.Max(s.LastIndexOf('-'),
                      Math.Max(s.LastIndexOf('*'), Math.Max(s.LastIndexOf('/'), -1))));
                if (index == -1)
                {
                    double value = Convert.ToDouble(s) / 100;
                    textBox1.Text = value.ToString();
                }

                else if (index == 0)
                {
                    char op = s[0];
                    string res = s.Substring(1);
                    double value = Convert.ToDouble(res) / 100;
                    textBox1.Text = op + value.ToString();
                }
                if (index == s.Length - 1)
                    textBox1.Text = "ERROR!!!";
                else
                {
                    if (index > 0 && index <= s.Length - 1)
                    {
                        string first = s.Substring(0, index + 1);
                        double sec = Convert.ToDouble(s.Substring(index + 1));
                        double percent = sec / 100;
                        textBox1.Text = first + percent.ToString();

                    }
                }

            }
            catch
            {
                textBox1.Text = "ERROR!!!";
            }
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            try
            {
                string s = textBox1.Text;
                int index = Math.Max(s.LastIndexOf('+'), Math.Max(s.LastIndexOf('-'),
                     Math.Max(s.LastIndexOf('*'), Math.Max(s.LastIndexOf('/'), -1))));
                if (index == -1)
                {
                    double value = Math.Sqrt(Convert.ToDouble(s));
                    textBox1.Text = value.ToString();
                }
                else if (index == s.Length - 1)
                {
                    textBox1.Text = "ERROR!!!";
                }
                else if (index == 0)
                {
                    char op = s[0];
                    string res = s.Substring(1);
                    double value = Math.Sqrt(Convert.ToDouble(res));
                    textBox1.Text = op + value.ToString();
                }
                else
                {
                    if (index > 0 && index <= s.Length - 1)
                    {
                        string first = s.Substring(0, index + 1);
                        double sec = Convert.ToDouble(s.Substring(index + 1));
                        double sqrt = Math.Sqrt(sec);
                        textBox1.Text = first + sqrt.ToString();
                    }
                }

            }
            catch
            {
                textBox1.Text = "ERROR!!!";
            }
        }

        private void buttonPhanso_Click(object sender, EventArgs e)
        {
            try
            {
                string s = textBox1.Text;
                int index = Math.Max(s.LastIndexOf('+'), Math.Max(s.LastIndexOf('-'),
                     Math.Max(s.LastIndexOf('*'), Math.Max(s.LastIndexOf('/'), -1))));
                if (index == -1)
                {
                    double value = 1 / (Convert.ToDouble(s));
                    textBox1.Text = (!double.IsInfinity(value)) ? value.ToString() : "ERROR!!!";
                }
                else if (index == s.Length - 1)
                {
                    textBox1.Text = "ERROR!!!";
                }
                else if (index == 0)
                {
                    char op = s[0];
                    string res = s.Substring(1);
                    double value = 1 / (Convert.ToDouble(res));
                    textBox1.Text = op + value.ToString();
                }
                else
                {
                    if (index > 0 && index <= s.Length - 1)
                    {
                        string first = s.Substring(0, index + 1);
                        double sec = Convert.ToDouble(s.Substring(index + 1));
                        if (sec == 0)
                        {
                            textBox1.Text = "ERROR!!!";
                            return;
                        }
                        double ps = 1 / (sec);
                        textBox1.Text = first + ps.ToString();
                    }
                }

            }
            catch
            {
                textBox1.Text = "ERROR!!!";
            }
        }

        private void buttonCongTru_Click(object sender, EventArgs e)
        {
            try
            {
                string s = textBox1.Text;
                int index = Math.Max(s.LastIndexOf('+'), Math.Max(s.LastIndexOf('-'),
                      Math.Max(s.LastIndexOf('*'), Math.Max(s.LastIndexOf('/'), -1))));
                if (index == -1 || index == 0)
                {
                    if (s.StartsWith("-"))
                        textBox1.Text = s.Substring(1);
                    else
                        textBox1.Text = "-" + s;
                }
                else if (index == s.Length - 1)
                {
                    textBox1.Text = "ERROR!!!";
                }
                else
                {
                    if (index > 0 && index <= s.Length - 1)
                    {
                        string first = s.Substring(0, index + 1);
                        // MessageBox.Show(first);
                        string second = "";


                        if (s[index - 1] == '-' || s[index - 1] == '+' || s[index - 1] == '*' || s[index - 1] == '/')
                        {
                            second = s.Substring(index);
                            first = first.Substring(0, index);
                        }
                        else
                            second = s.Substring(index + 1);


                        if (second.StartsWith("-"))
                        {
                            second = second.Substring(1);
                            textBox1.Text = first + second;
                        }
                        else
                        {
                            second = "-" + second;
                            textBox1.Text = first + second;
                        }
                    }
                }

            }
            catch
            {
                textBox1.Text = "ERROR!!!";
            }
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {

                string s = textBox1.Text;
                s = s.Substring(0, s.Length - 1);
                textBox1.Text = s;
            }

        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            MemoryValue = 0;
            buttonMR.Enabled = false;

        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            textBox1.Text += MemoryValue.ToString();
        }

        private void buttonMS_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            try
            {
                double result = Convert.ToDouble(new DataTable().Compute(s, ""));
                MemoryValue = result;
                buttonMR.Enabled = true;
                buttonMC.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Biểu thức không hợp lệ");
            }

        }

        private void buttonM_Click(object sender, EventArgs e)
        {

            string s = textBox1.Text;
            try
            {
                double result = Convert.ToDouble(new DataTable().Compute(s, ""));
                MemoryValue += result;
                buttonMR.Enabled = true;
                buttonMC.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Biểu thức không hợp lệ");
            }

        }


    }
}
