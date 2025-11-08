using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bai01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.List;
            this.Text = "Form Lifetime";
            this.Load += LoadForm;
            this.Shown += ShownForm;
            this.Activated += ActivatedForm;
            this.Deactivate += DeactivatedForm;
            this.FormClosing += ClosingForm;
            this.FormClosed += ClosedForm;


        }
        private void LoadForm(object sender, EventArgs e)
        {
            string txt = $"Load: Form đang tải (chuẩn bị dữ liệu)";
            listView1.Items.Add(txt);
        }

        private void ActivatedForm(object sender, EventArgs e)
        {
            string txt = $"Activated: Form được kích hoạt (focus)";
            listView1.Items.Add(txt);
        }

        private void ShownForm(object sender, EventArgs e)
        {
            string txt = $"Shown: Form đã hiển thị lần đầu";


            listView1.Items.Add(txt);
            txt = $"Tips: Nhấn 'Open Modal' để xem Deactivated -> Activated";
            listView1.Items.Add(txt);

        }
        private void DeactivatedForm(object sender, EventArgs args)
        {
            string txt = $"Deactivated: Form tắt kích hoạt (lost focus)";
            listView1.Items.Add(txt);
        }
        private void ClosedForm(object sender, EventArgs e)
        {
            string txt = $"Closed: Form đã đóng";
            MessageBox.Show(txt);
            listView1.Items.Add(txt);
        }

        private void ClosingForm(object sender, FormClosingEventArgs args)
        {
            string txt = $"Closing: Form đang đóng";
            MessageBox.Show(txt);
            listView1.Items.Add(txt);
        }
        private void OpenModal(object sender, EventArgs e)
        {
            string txt = $"Tips: Nhấn 'Open Modal' để xem Deactivated -> Activated";
            listView1.Items.Add(txt);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }

        }


    }
}
