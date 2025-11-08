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

namespace Bai08
{
    public partial class Form1 : Form
    {
        private List<string> stks = new List<string>();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Quản lý tài khoản";
            listViewKH.Columns.Add("STT", 70);
            listViewKH.Columns.Add("Mã tài khoản", 180);
            listViewKH.Columns.Add("Tên khách hàng", 230);
            listViewKH.Columns.Add("Địa chỉ", 250);
            listViewKH.Columns.Add("Số tiền", 110);
        }

        private void TongTien()
        {
            double tong = 0;
            foreach (ListViewItem item in listViewKH.Items)
            {
                double tien;
                if (double.TryParse(item.SubItems[4].Text, out tien))
                    tong += tien;
            }
            textBoxSum.Text = tong.ToString();
        }
        private void CapNhatLaiSTT()
        {
            for (int i = 0; i < listViewKH.Items.Count; i++)
            {
                listViewKH.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSTK.Text) || string.IsNullOrWhiteSpace(textBoxTKH.Text) || string.IsNullOrWhiteSpace(textBoxDCKH.Text)
                || string.IsNullOrWhiteSpace(textBoxST.Text))
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            else
            {
                string stk = textBoxSTK.Text;
                string ten = textBoxTKH.Text;
                string diachi = textBoxDCKH.Text;
                string tien = textBoxST.Text;

                int index = -1;
                for (int i = 0; i < listViewKH.Items.Count; i++)
                {
                    string s = listViewKH.Items[i].SubItems[1].Text;
                    if (s == stk)
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                {

                    var item = listViewKH.Items[index];
                    item.SubItems[2].Text = ten;
                    item.SubItems[3].Text = diachi;
                    item.SubItems[4].Text = tien;
                    TongTien();
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                }
                else
                {
                    int stt = listViewKH.Items.Count + 1;
                    ListViewItem item = new ListViewItem(stt.ToString());
                    item.SubItems.Add(stk);
                    item.SubItems.Add(ten);
                    item.SubItems.Add(diachi);
                    item.SubItems.Add(tien);
                    listViewKH.Items.Add(item);
                    TongTien();
                    MessageBox.Show("Thêm mới dữ liệu thành công!");

                }
                textBoxSTK.Clear();
                textBoxTKH.Clear();
                textBoxDCKH.Clear();
                textBoxST.Clear();

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSTK.Text))
                MessageBox.Show("Vui lòng nhập số tài khoản cần xóa!");
            else
            {
                string stk = textBoxSTK.Text;
                string ten = textBoxTKH.Text;
                string diachi = textBoxDCKH.Text;
                string tien = textBoxST.Text;

                int index = -1;
                for (int i = 0; i < listViewKH.Items.Count; i++)
                {
                    string s = listViewKH.Items[i].SubItems[1].Text;
                    if (s == stk)
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                {
                    DialogResult result = MessageBox.Show("Bạn muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        listViewKH.Items.Remove(listViewKH.Items[index]);
                        CapNhatLaiSTT();
                        TongTien();
                        MessageBox.Show("Xóa tài khoản thành công");
                        textBoxSTK.Clear();
                        textBoxTKH.Clear();
                        textBoxDCKH.Clear();
                        textBoxST.Clear();
                    }

                }

                else
                {
                    MessageBox.Show("Không tìm thấy số tài khoản cần xóa!");
                }

            }

        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                this.Close();
        }

        private void listViewKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewKH.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewKH.SelectedItems[0];
                textBoxSTK.Text = item.SubItems[1].Text;
                textBoxTKH.Text = item.SubItems[2].Text;
                textBoxDCKH.Text = item.SubItems[3].Text;
                textBoxST.Text = item.SubItems[4].Text;
            }

        }
    }
}
